using System;

namespace NGEntity.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class PropertyChanged : Attribute
	{
		public bool Changed { get; set; }
		public PropertyChanged(bool changed) { this.Changed = changed; }
	}
}
