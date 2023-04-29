namespace CarCatalog.Web.Pages.CarsFilter;

public class CarTransmissonItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public override bool Equals(object? obj)
    {
        var other = obj as CarTransmissonItem;
        return other?.Name == Name;
    }

    public override int GetHashCode() => Name?.GetHashCode() ?? 0;

    public override string ToString() => Name;
}
