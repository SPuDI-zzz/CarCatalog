namespace CarCatalog.Context.Entities;
public class CarMark : BaseEntity
{
    public string Name { get; set; }

    public int? IdCountry { get; set; }
    public virtual Country Country { get; set; }

    public virtual ICollection<CarModel> CarModels { get; set; }
}
