using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;
using System.Collections.Generic;

namespace NGEntity
{
	public class User : Entity<User>, IEntity
	{
		[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
		public int? IdUser { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Email { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Name { get; set; }
		[FieldsAttributes(VariableType.Bool, 0, true, Key.None)]
		public bool Flag { get; set; }
		public int? FkAddress { get; set; }
		[Foreignkey("FkAddress")]
		public IEnumerable<Address> Addresses { get; set; }

		public User() { }
		public User(int? idUser) { IdUser = idUser; }
	}
}
