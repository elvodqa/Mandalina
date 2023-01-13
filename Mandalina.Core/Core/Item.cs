using System;
namespace Mandalina.Core.Core
{
	public class Item
	{
        public uint ID;
		public string Name;
		public string Description;
		public bool Stackable = true;
		public uint MaxStackCount = 32;
		public string Texture;

        public Item()
		{
			
		}
	}

	public enum Quality
	{
		Trash,
		ReallyBad,
		Bad,
		Normal,
		Good,
		ReallyGood,
		Excellent
	}
}

