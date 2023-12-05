namespace Backend.Test.Services;

using Backend.Services;

public class FindServiceTest
{
    [Fact]
    public void FindCommonElements_ShouldReturnResult()
    {
        int[] arg1 = [1, 2, 3, 4, 5];
        int[] arg2 = [3, 4, 5, 6, 7];
        var service = new FindService();

        var result = service.FindCommonElements(arg1, arg2);

        Assert.Equal(result, [3, 4, 5]);
    }
}