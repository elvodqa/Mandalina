using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Mandalina.Core.Core.Screens
{
	public class SplashScreen : GameScreen
	{
        private new GameBase Game => (GameBase)base.Game;

        public SplashScreen(GameBase game) : base(game)
        {
            _logo = Game.Content.Load<Texture2D>("EmirLogo");
        }

        private Texture2D _logo;

        public override void Update(GameTime gameTime)
        {
            // wait 3 seconds than switch to the main menu
            if (gameTime.TotalGameTime.TotalSeconds > 3)
                Game.ScreenManager.LoadScreen(new MainMenu(Game), new FadeTransition(GraphicsDevice, Color.Black));

        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            Game.SpriteBatch.Begin();
            // draw the sprite at middle, its size is 320x160
            Game.SpriteBatch.Draw(_logo, new Vector2(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f, new Vector2(_logo.Width / 2, _logo.Height / 2), 1f, SpriteEffects.None, 0f);
            Game.SpriteBatch.End();
        }

    }
}

