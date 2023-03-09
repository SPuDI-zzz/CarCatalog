namespace CarCatalog.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class Comment 
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; }

    public int? IdCarForSale { get; set; }
    public CarForSale CarForSale { get; set; }

    public int? IdUser { get; set; }
    public User User { get; set; }
}
