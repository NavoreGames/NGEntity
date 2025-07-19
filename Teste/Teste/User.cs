using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NGConnection.Attributes;
using NGConnection.Enums;
using NGEntity.Attributes;
using NGEntity.Interfaces;

namespace NGEntity
{
	//[TableProperties("Usr001")]
	public partial class User : Entity<User>
	{
		string lastNane;

		[ColumnPrimarykey(true)]
		public int IdUser
		{
			get;
			set;
		}
		[ColumnUniquekey(50)]
		public string Email { get; set; }
		[ColumnProperties(50)]
		public string Name { get; set; }
		[ColumnProperties(true)]
		public bool Flag { get; set; }
		[ColumnForeignkey(typeof(Address), "IdAddress")]
		public int? FkAddress { get; set; }

		public Address Address { get; set; } =
			MapOne<Address>(x => x.IdAddress, y => y.FkAddress);
		public Address Add { get; set; } =
			MapOne<Address>((x => x.IdAddress, y => y.FkAddress), (x => x.Street, y => y.Name));
		public IEnumerable<Address> Addresses { get; set; } =
			MapMany<Address>(x => x.IdAddress, y => y.FkAddress);

		public User() { }
	}
}
