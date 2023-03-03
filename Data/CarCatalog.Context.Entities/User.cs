namespace CarCatalog.Context.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public DateOnly Birthday { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public ICollection<CarForSale> Favorites { get; set; }
}
