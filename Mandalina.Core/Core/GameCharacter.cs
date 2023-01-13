using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mandalina.Core.Core
{
	public class GameCharacter
	{
		public GameBase GameBase;
		public Texture2D SpriteSheet;

		public GameCharacter(GameBase gameBase)
		{
			GameBase = gameBase;
		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(GameTime gameTime)
		{

		} 
	}
}

