namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class CarEgineType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int? IdCarConfiguration { get; set; }
    public CarConfiguration CarConfiguration { get; set; }
}
