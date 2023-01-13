using System;
namespace Mandalina.Core.Core.Items
{
	public class SpruceWood : Item
	{
		public SpruceWood()
		{
            ID = 1;
            Name = "Pine Wood";
            Description = "A wood that can be used for crafting.";
            Stackable = true;
            MaxStackCount = 16;
            Texture = "SpruceWood";
        }
	}
}

