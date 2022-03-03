namespace WBML.Core.GodPowers;

public abstract class Power
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }

    public Power(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}