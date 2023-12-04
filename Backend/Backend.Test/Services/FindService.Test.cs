namespace Backend.Test.Services;

using Moq;
using Backend.Services;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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