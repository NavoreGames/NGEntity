using System;

namespace NGEntity.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class PropertyChanged(bool changed) : Attribute
	{
        public bool Changed { get; set; } = changed;
    }
}
