using System;
using Microsoft.Xna.Framework;

namespace Mandalina.Core.Core.Characters
{
	public class Player : GameCharacter
	{
        public Player(GameBase gameBase) : base(gameBase)
		{
		}
        
        public override void Update(GameTime gameTime)
        {
	        base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
	        base.Draw(gameTime);
        }
	}
}

