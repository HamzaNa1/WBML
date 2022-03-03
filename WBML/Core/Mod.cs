namespace WBML.Core;

public abstract class Mod
{
    public abstract ModInfo Info { get; }

    public abstract void Initialize();

    public abstract void Update();
}