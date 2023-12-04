
namespace Backend.Services;

public interface IFindService
{
    int[] FindCommonElements(int[] arr1, int[] arr2);
}

public class FindService : IFindService
{
    public int[] FindCommonElements(int[] arr1, int[] arr2)
    {
        return arr1.Intersect(arr2).ToArray();
    }
}