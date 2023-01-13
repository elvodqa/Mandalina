using System;

namespace Mandalina.Core.Core.Items
{
	public class PineWood : Item
	{
		public PineWood()
		{
			ID = 0;
			Name = "Pine Wood";
			Description = "A wood that can be used for crafting.";
			Stackable = true;
			MaxStackCount = 16;
			Texture = "PineWood";
		}
	}
}

