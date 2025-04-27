using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestForEmail.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}

