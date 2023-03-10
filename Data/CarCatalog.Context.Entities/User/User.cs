namespace CarCatalog.Context.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index("Uid", IsUnique = true)]
public class User : IdentityUser<int>
{
    [Required]
    public virtual Guid Uid { get; set; } = Guid.NewGuid();

    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<CarForSale> CarForSales { get; set; }
}
