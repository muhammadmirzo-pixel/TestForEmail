using System.ComponentModel.DataAnnotations;
using TestForEmail.Attributes;
using TestForEmail.Commons;

namespace TestForEmail.Models;

public class Message : Auditable
{
    [Required]
    public string Subject { get; set; }
    [Required]
    [CustomAttribute("Body of the message")]
    public string Body { get; set; }
    [Required]
    [EmailAddress]
    public string To { get; set; }
}
