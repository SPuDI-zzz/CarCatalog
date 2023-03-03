namespace CarCatalog.Context.Entities;
public class CarModel : BaseEntity
{
    public string Name { get; set; }

    public string Class { get; set; }

    public int? IdCarMark { get; set; }
    public virtual CarMark CarMark { get; set; }

    public virtual ICollection<CarGeneration> Generations { get; set; }
}
