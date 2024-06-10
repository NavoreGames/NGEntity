using System.Collections.Generic;

namespace NGEntity.Models
{
    public class DataBase(List<Table> tables)
    {
        public List<Table> Tables { get; private set; } = tables;
    }
}
