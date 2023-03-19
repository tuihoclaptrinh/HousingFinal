using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Models;

public class User : BaseEntity
{
    [Required]
    public string Username { get; set; }
    [Required]
    public byte[] Password { get; set; }

    public byte[] PasswordKey { get; set; }
}