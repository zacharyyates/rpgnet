using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Models
{
	public partial class CharacterDto
	{
		public Dnd4Character Character
		{
			get
			{
				if (m_Character == null)
				{
					// Deserialize the characterObject
					BinaryFormatter binFormatter = new BinaryFormatter();
					using (MemoryStream memStream = new MemoryStream(CharacterObject.ToArray()))
					{
						m_Character = binFormatter.Deserialize(memStream) as Dnd4Character;
					}
				}

				return m_Character;
			}
			set
			{
				m_Character = value;
			}
		}
		Dnd4Character m_Character;
	}
}