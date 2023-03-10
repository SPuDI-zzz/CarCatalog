namespace CarCatalog.Context.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[Index("Uid", IsUnique = true)]
public class User : IdentityUser<int>
{
    [Required]
    public virtual Guid Uid { get; set; } = Guid.NewGuid();

    public DateOnly Birthday { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<CarForSale> CarForSales { get; set; }
}
