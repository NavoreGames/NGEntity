using NGConnection.Interfaces;
using NGEntity.Interfaces;
using System;

namespace NGEntity.Models
{
    public abstract class EntityData
    {
        internal CommandData CommandData { get; set; }

        internal EntityData() { }
        internal EntityData(CommandData commandData) { CommandData = commandData; }
    }
}
