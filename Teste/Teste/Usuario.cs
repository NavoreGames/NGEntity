using NGEntity.Attributes;
using NGEntity.Enum;
using NGEntity.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGEntity
{
	public class Usuario : Entity<Usuario>, IEntity, INotifyPropertyChanged
	{
		//[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
		public int? IdUser { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Email { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string UserName { get; set; }
		[FieldsAttributes(VariableType.Bool, 0, true, Key.None)]
		public bool Flag { get; set; }

		public Usuario() { }
		public Usuario(int? idUser) { IdUser = idUser; }
	}
}
