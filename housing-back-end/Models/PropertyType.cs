using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Models;

public class PropertyType :BaseEntity
{
    [Required]
    public string Name { get; set; }
}