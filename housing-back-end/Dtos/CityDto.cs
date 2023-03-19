using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Dtos;

public class CityDto
{
    public int Id { get; set; }
        
    [Required (ErrorMessage = "Name is mandatory field")]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]        
    public string Name { get; set; }
        
    [Required]
    public string  Country { get; set; }
}