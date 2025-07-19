using NGConnection.Attributes;
using NGConnection.Enums;
using NGEntity.Interfaces;

namespace NGEntity
{
	public class Subtitle : Entity<Subtitle>, IEntity
	{
		public int? IdSubtitle { get; set; }
		public string Header { get; set; }
		public string Description { get; set; }
		public string Question { get; set; }
		public bool Flag { get; set; }
		public string Scene { get; set; }
		public string Parent { get; set; }
		public string GameObject { get; set; }
		public int Type { get; set; }
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
