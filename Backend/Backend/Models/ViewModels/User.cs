namespace Backend.Models.ViewModels;

public class User : UserDto
{
    public int Id { get; set; }
    public string HN { get; set; } = null!;
}

public class UserDto
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class UserResult
{
    public List<User> Users { get; set; } = [];
    public int Total { get; set; }
}