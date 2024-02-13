using System.Collections.Generic;

namespace NGEntity.Models
{
    public class DataBase
    {
        public List<Table> Tables { get; private set; }
        public DataBase(List<Table> tables){ Tables = tables; }
    }
}
