using NGEntity.Attributes;
using NGEntity.Interfaces;

namespace NGEntity
{
	[Primarykey("IdAddress")]
	public class Address : Entity<Address>, IEntity
	{
		public int? IdAddress { get; set; }
		public string Street { get; set; }

        public Address() { }
	}
}
