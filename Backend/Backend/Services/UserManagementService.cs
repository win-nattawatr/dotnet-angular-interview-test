
using Backend.Models.Entities;
using Backend.Models.ViewModels;
using Backend.Repositories;

namespace Backend.Services;

public interface IUserManagementService
{
    Task<UserResult> GetUsers(int? size, int? page);
    Task<User> AddUser(UserDto userDto);
    Task<User> UpdateUser(string hn, UserDto userDto);
    Task DeleteUser(string hn);
}

public class UserManagementService(IUserRepository userRepository) : IUserManagementService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> AddUser(UserDto userDto)
    {
        var newUser = new UserEntity()
        {
            HN = Guid.NewGuid().ToString("N"),
            Firstname = userDto.Firstname,
            Lastname = userDto.Lastname,
            PhoneNumber = userDto.PhoneNumber,
            Email = userDto.Email
        };

        newUser = await _userRepository.AddUser(newUser);
        return newUser.ToUser();
    }

    public async Task DeleteUser(string hn)
    {
        var user = await _userRepository.GetUserByHN(hn);
        if (user != null)
        {
            await _userRepository.DeleteUser(user);
        }
    }

    public async Task<UserResult> GetUsers(int? size, int? page)
    {
        return new UserResult()
        {
            Users = (await _userRepository.GetUsers(size, page)).Select(x => x.ToUser()).ToList(),
            Total = await _userRepository.GetTotalUsers()
        };
    }

    public async Task<User> UpdateUser(string hn, UserDto userDto)
    {
        var updateUser = await _userRepository.GetUserByHN(hn) ?? throw new Exception("User not found.");

        updateUser.Firstname = userDto.Firstname;
        updateUser.Lastname = userDto.Lastname;
        updateUser.PhoneNumber = userDto.PhoneNumber;
        updateUser.Email = userDto.Email;

        updateUser = await _userRepository.UpdateUser(updateUser);
        return updateUser.ToUser();
    }
}