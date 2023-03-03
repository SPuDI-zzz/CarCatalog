namespace CarCatalog.Context.Entities;
public class Comment : BaseEntity
{
    public string Content { get; set; }

    public int? IdCarForSale { get; set; }
    public CarForSale CarForSale { get; set; }

    public int? IdUser { get; set; }
    public User User { get; set; }
}
