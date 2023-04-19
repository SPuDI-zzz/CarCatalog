namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class Favorite
{
    public int? IdCarForSale { get; set; }
    public virtual CarForSale CarForSale { get; set; }

    public int? IdUser { get; set; }
    public virtual User User { get; set; }
}
