namespace ConsoleQueries.Models;

public class BrandNumber
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int NumProducts { get; set; }
    public BrandNumber(Brand brand,int number)
    {
        Id = brand.Id;
        Name = brand.Name;
        NumProducts = number;
    }
}