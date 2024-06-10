using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGEntity
{
	public class Subtitle : Entity<Subtitle>, IEntity
	{
		[ColumnProperties(true, Key.Pk, false)]
		public int? IdSubtitle { get; set; }
		[ColumnProperties(100, true)]
		public string Header { get; set; }
		[ColumnProperties(500, true)]
		public string Description { get; set; }
		[ColumnProperties(100)]
		public string Question { get; set; }
		[ColumnProperties(true)]
		public bool Flag { get; set; }
		[ColumnProperties( 50, true)]
		public string Scene { get; set; }
		[ColumnProperties(50, true)]
		public string Parent { get; set; }
		[ColumnProperties(50, true)]
		public string GameObject { get; set; }
		[ColumnProperties(true)]
		public int Type { get; set; }
		[ColumnProperties(false, Key.Fk)]
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
