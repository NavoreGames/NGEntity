using System;
using NGEntity.Enum;

namespace NGEntity.Attributes
{
	//////// ATRIBUTO PARA USAR NA CRIAÇÃO DAS CLASSES DAS TABELAS DO BANCO    ///
	//////////////////////////////////////////////////////////////////////////////
	//////// ATRIBUTOS DE PROPRIEDADES DA CLASSE,     ////////////////////////////
	//////// PARA GUARDAR INFORMAÇÕES DAS TABELAS     ////////////////////////////
	//////// COMO CHAVES, TIPO DO CAMPO, NOT NULL.    ////////////////////////////
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class FieldsAttributes : Attribute
	{
		public VariableType Type { get; set; }
		public int Length { get; set; }
		public bool NotNull { get; set; }
		public Key Key { get; set; }
		public bool GetId { get; set; }

		public FieldsAttributes(VariableType type, int length, bool notNull, Key key, bool getId = false)
		{
			Type = type;
			Length = length;
			NotNull = notNull;
			Key = key;
			GetId = getId;
		}
	}
}
