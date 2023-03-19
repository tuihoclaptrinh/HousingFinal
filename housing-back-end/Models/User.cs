using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}