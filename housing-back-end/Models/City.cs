namespace housing_back_end.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public int LastUpdateBy { get; set; }
}