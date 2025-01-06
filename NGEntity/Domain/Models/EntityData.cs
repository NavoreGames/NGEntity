namespace NGEntity.Models;

public abstract class EntityData
{
    internal Guid Identifier { get; set; }

    internal EntityData() { }
    internal EntityData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommands(Identifier).ToString());
}
