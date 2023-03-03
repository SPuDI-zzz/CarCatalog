namespace CarCatalog.Context.Entities;
public class Country : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<CarMark> CarMarks { get; set; }
}
