namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class Comment 
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTimeOffset DateTimeAdded { get; set; }

    public int? IdCarForSale { get; set; }
    public virtual CarForSale CarForSale { get; set; }

    public int? IdUser { get; set; }
    public virtual User User { get; set; }
}
