using System;
using Mandalina.Core.Core.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Mandalina.Core
{
    public class GameBase : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch;
        public ScreenManager ScreenManager;
        public bool DebugMode = false;
        

        public Color ClearColor = new(88, 85, 83);

        public GameBase()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
            Window.Title = "Mandalina";
            ScreenManager = new ScreenManager();
            Components.Add(ScreenManager);
            if (Environment.GetEnvironmentVariable("SKIP-SPLASH") == null)
            {
                ScreenManager.LoadScreen(new SplashScreen(this), new FadeTransition(GraphicsDevice, Color.Black, 0.5f));
            }
            else
            {
                ScreenManager.LoadScreen(new MainMenu(this), new FadeTransition(GraphicsDevice, Color.Black, 0.5f));
            }
            if (Environment.GetEnvironmentVariable("DEBUG") != null)
            {
                DebugMode = true;
            }
            ScreenManager.LoadScreen(new SplashScreen(this), new FadeTransition(GraphicsDevice, Color.Black));
            
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Input.GetKeyboardState();
            Input.GetMouseState();


            
            base.Update(gameTime);
            
            
            Input.FixScrollLater();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);
            
            base.Draw(gameTime);
        }
    }
}
