using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Models;

public class FurnishingType: BaseEntity
{
    [Required]
    public string Name { get; set; }
}