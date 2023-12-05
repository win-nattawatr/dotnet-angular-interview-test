using Backend.Models.ViewModels;
using Backend.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public interface IEmployeeWorkingTimeRepository
{
    List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanByLinQ();
    List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanBySQL();
}

public class EmployeeWorkingTimeRepository(EmployeeWorkingTimeDbContext employeeDbContext) : IEmployeeWorkingTimeRepository
{
    private readonly EmployeeWorkingTimeDbContext _employeeDbContext = employeeDbContext;

    public List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanByLinQ()
    {
        return [.. _employeeDbContext.WorkSchedules
            .Join(_employeeDbContext.CardScans,
                ws => new { ws.EmployeeId, ws.WorkDate.Date },
                cs => new { cs.EmployeeId, cs.Clock.Date },
                (ws, cs) => new { ws, cs })
            .Where(x => x.cs.Clock >= (x.ws.BeginTime.AddHours(-5).Date < x.ws.WorkDate ? x.ws.WorkDate : x.ws.BeginTime.AddHours(-5))
                    && x.cs.Clock < (x.ws.EndTime.AddHours(5).Date > x.ws.WorkDate ? x.ws.WorkDate.AddDays(1) : x.ws.EndTime.AddHours(5)))
            .GroupBy(x => new { x.ws.EmployeeId, x.ws.WorkDate })
            .Select(g => new EmployeeWorkingTimeViewModel
            {
                EmployeeId = g.Key.EmployeeId,
                WorkDate = g.Key.WorkDate,
                ClockIn = g.Min(x => x.cs.Clock),
                ClockOut = g.Min(x => x.cs.Clock) == g.Max(x => x.cs.Clock) ? null : g.Max(x => x.cs.Clock)
            }).OrderBy(e => e.WorkDate)];
    }

    public List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanBySQL()
    {
        return [.. _employeeDbContext.Database.SqlQuery<EmployeeWorkingTimeViewModel>(EmployeeWorkScanSQLQuery)];
    }

    private static readonly FormattableString EmployeeWorkScanSQLQuery =
        $@"select wscs.EmployeeId, 
	        wscs.WorkDate,
	        MIN(wscs.Clock) as ClockIn,
	        case when MIN(wscs.Clock) = MAX(wscs.Clock) then null else MAX(wscs.Clock) end as ClockOut 
        from (
		    select ws.EmployeeId, ws.WorkDate, ws.BeginTime, ws.EndTime, cs.Clock from WorkSchedules ws
		    right Join CardScans cs on ws.EmployeeId = cs.EmployeeId
			    and CONVERT(VARCHAR(10), ws.WorkDate, 103) = CONVERT(VARCHAR(10), cs.Clock, 103)
		    where cs.Clock >= 
			    case when DATEADD(dd, 0, DATEDIFF(dd, 0, DATEADD(hh, -5, ws.BeginTime))) < ws.WorkDate then ws.WorkDate
			    else DATEADD(hh, -5, ws.BeginTime)
			    end
			and cs.Clock <
			    case when DATEADD(dd, 0, DATEDIFF(dd, 0, DATEADD(hh, 5, ws.EndTime))) > ws.WorkDate then DATEADD(dd, 1, ws.WorkDate)
			    else DATEADD(hh, 5, ws.EndTime)
			    end
	    ) wscs

        group by wscs.EmployeeId, wscs.WorkDate";
}