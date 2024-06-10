using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Primitives;
using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;
using System.Collections.Generic;

namespace NGEntity
{
	public partial class User : Entity<User>, IEntity
	{
        string lastNane;

        [ColumnProperties(true, Key.Pk, true)]
        public int? IdUser 
		{ 
			get; 
			set; 
		}
		[ColumnProperties(50, true, Key.Unique)]
        public string Email { get; set; }
		[ColumnProperties(50, true)]
		public string Name { get; set; }
		[ColumnProperties(true)]
		public bool Flag { get; set; }
        [ColumnProperties(false, Key.Fk)]
        public int? FkAddress { get; set; }

		public IEnumerable<Address> Addresses { get; set; }

		public User() { }
		public User(int? idUser) { IdUser = idUser; }
	}
}
