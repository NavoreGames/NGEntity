﻿namespace NGEntity.Models;

public abstract class EntityData
{
    internal Guid Identifier { get; set; }

    internal EntityData() { }
    internal EntityData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommandData(Identifier).Select(s=> s.Command.ToString()).Where(w=> w != null && w != ""));
}
