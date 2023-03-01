using System.ComponentModel.DataAnnotations;

namespace AuthService.Dto;

public class LoginDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Avatar { get; set; }
    public string? Bio { get; set; }
    public string? Gender { get; set; }
    public string? Birthday { get; set; }
}