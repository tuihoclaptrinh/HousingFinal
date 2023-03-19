using System.ComponentModel.DataAnnotations;

namespace housing_back_end.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [Required]
    public string Country { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public int LastUpdateBy { get; set; }
}