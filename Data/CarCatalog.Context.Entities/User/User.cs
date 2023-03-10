namespace CarCatalog.Context.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public DateOnly Birthday { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<CarForSale> Favorites { get; set; }
}
