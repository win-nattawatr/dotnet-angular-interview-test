using Backend.Models.Entities;
using Backend.Models.ViewModels;
using Backend.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public interface IUserRepository
{
    Task<List<UserEntity>> GetUsers(int? size, int? page);
    Task<UserEntity?> GetUserByHN(string hn);
    Task<int> GetTotalUsers();
    Task<UserEntity> AddUser(UserEntity user);
    Task<UserEntity> UpdateUser(UserEntity user);
    Task DeleteUser(UserEntity user);
}

public class UserRepository(UserDbContext userDbContext) : IUserRepository
{
    private readonly UserDbContext _userDbContext = userDbContext;

    public async Task<UserEntity> AddUser(UserEntity user)
    {
        _userDbContext.Add(user);
        await _userDbContext.SaveChangesAsync();
        await GenerateHN(user);
        return user;
    }

    public async Task DeleteUser(UserEntity user)
    {
        _userDbContext.Users.Remove(user);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task<int> GetTotalUsers()
    {
        return await _userDbContext.Users.CountAsync();
    }

    public async Task<UserEntity?> GetUserByHN(string hn)
    {
        return await _userDbContext.Users.Where(x => x.HN == hn).FirstOrDefaultAsync();
    }

    public async Task<List<UserEntity>> GetUsers(int? size, int? page)
    {
        var q = _userDbContext.Users.OrderBy(x => x.HN).AsQueryable();
        if (size.HasValue)
        {
            if (page.HasValue && page.Value > 0)
            {
                q = q.Skip((page.Value - 1) * size.Value);
            }

            q = q.Take(size.Value);
        }

        return await q.ToListAsync();
    }

    public async Task<UserEntity> UpdateUser(UserEntity user)
    {
        _userDbContext.Users.Update(user);
        await _userDbContext.SaveChangesAsync();
        return user;
    }

    private async Task GenerateHN(UserEntity user)
    {
        if (user.Id > 0)
        {
            user.HN = $"{user.Id:000000}";
            _userDbContext.Users.Update(user);
            await _userDbContext.SaveChangesAsync();
            return;
        }
        throw new Exception("Invalid Id");
    }
}