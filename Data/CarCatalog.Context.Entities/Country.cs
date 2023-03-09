namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class Country
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<CarMark> CarMarks { get; set; }
}
