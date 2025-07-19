using NGConnection.Attributes;
using NGEntity.Interfaces;

namespace NGEntity
{
	public class Address : Entity<Address>
	{
		public int? IdAddress { get; set; }
		public string Street { get; set; }

        public Address() { }
	}
}
