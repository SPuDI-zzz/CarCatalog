namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class Favorite
{
    [Key]
    public int Id { get; set; }
    public int? IdCarForSale { get; set; }
    public virtual CarForSale CarForSale { get; set; }

    public int? IdUser { get; set; }
    public virtual User User { get; set; }
}
