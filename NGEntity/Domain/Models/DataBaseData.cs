namespace NGEntity.Models;

public abstract class DataBaseData
{
    internal Guid Identifier { get; set; }

    internal DataBaseData() { }
    internal DataBaseData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommandData(Identifier).Select(s=> s.Command.ToString()).Where(w=> w != null && w != ""));
}
