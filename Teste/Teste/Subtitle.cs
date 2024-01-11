using NGEntity.Attributes;
using NGEntity.Enum;
using NGEntity.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGEntity
{
	public class Subtitle : Entity<Subtitle>, IEntity, INotifyPropertyChanged
	{
		[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, false)]
		public int? IdSubtitle { get; set; }
		[FieldsAttributes(VariableType.String, 100, true, Key.None)]
		public string Header { get; set; }
		[FieldsAttributes(VariableType.String, 500, true, Key.None)]
		public string Description { get; set; }
		[FieldsAttributes(VariableType.String, 100, true, Key.None)]
		public string Question { get; set; }
		[FieldsAttributes(VariableType.Bool, 0, true, Key.None)]
		public bool Flag { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Scene { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string Parent { get; set; }
		[FieldsAttributes(VariableType.String, 50, true, Key.None)]
		public string GameObject { get; set; }
		[FieldsAttributes(VariableType.Int, 0, true, Key.None)]
		public int Type { get; set; }
		[FieldsAttributes(VariableType.Int, 0, true, Key.None)]
		public int FkLanguage { get; set; }

		#region CONSTRUCTORS 
		public Subtitle() { }
		public Subtitle(int? pIdSubtitle, string pHeader, string pDescription, string pQuestion, bool pFlag, string pScene, string pParent, string pGameObject, int pType, int pFkLanguage)
		{
			IdSubtitle = pIdSubtitle;
			Header = pHeader;
			Description = pDescription;
			Question = pQuestion;
			Flag = pFlag;
			Scene = pScene;
			Parent = pParent;
			GameObject = pGameObject;
			Type = pType;
			FkLanguage = pFkLanguage;
		}
		#endregion

	}
}
