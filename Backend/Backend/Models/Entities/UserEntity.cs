using System.ComponentModel.DataAnnotations;
using Backend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entities;

[Index(nameof(HN), IsUnique = true)]
public class UserEntity : BaseEntity
{
    [Required]
    public string HN { get; set; } = null!;
    [Required]
    public string Firstname { get; set; } = null!;
    [Required]
    public string Lastname { get; set; } = null!;
    [Required]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;

    public User ToUser()
    {
        return new User()
        {
            Id = Id,
            HN = HN,
            Firstname = Firstname,
            Lastname = Lastname,
            PhoneNumber = PhoneNumber,
            Email = Email,
        };
    }
}