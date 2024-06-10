using CommunityToolkit.Mvvm.ComponentModel;
using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain
{
    public partial class TesteEntidade :Entity<TesteEntidade>, IEntity
    {
        [ObservableProperty]
        string test;
    }
}
