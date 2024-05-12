using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;

namespace NGEntity
{
	public class Endereco : Entity<Endereco>, IEntity
	{
		//[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
		public int? IdAddress { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Address { get; set; }
        public int FkUser { get; set; }

        public Endereco() { }
	}
}
