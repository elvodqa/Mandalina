using System;
namespace Mandalina.Core.Core.Items
{
	public class BirchWood : Item
	{
		public BirchWood()
		{
            ID = 2;
            Name = "Birch Wood";
            Description = "A wood that can be used for crafting.";
            Stackable = true;
            MaxStackCount = 16;
            Texture = "PineWood";
        }
	}
}

