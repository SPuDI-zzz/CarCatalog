namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class CarBodyType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    ICollection<CarConfiguration> CarConfigurations { get; set; }
}

