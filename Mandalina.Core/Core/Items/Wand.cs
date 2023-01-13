using System;
namespace Mandalina.Core.Core.Items
{
	public class Wand : Item
	{
		public int Damage;
		public int Speed;
		public int Level;
		public Quality Quality;
		public MaterialType Material;

		public Wand()
		{
		}

		public int GenerateDamage()
		{
			return 0;
		}
	}

	public enum MaterialType
	{
		Birch,
		Pine,
		Spruce,
        Opal
    }
}

