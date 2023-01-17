using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Particles;
using MonoGame.Extended.Particles.Modifiers;
using MonoGame.Extended.Particles.Modifiers.Containers;
using MonoGame.Extended.Particles.Modifiers.Interpolators;
using MonoGame.Extended.Particles.Profiles;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.TextureAtlases;

namespace Mandalina.Core.Core.Screens
{
    enum SelectedOption
    {
        New,
        Load,
        Coop,
        Options,
        Quit
    }
	public class MainMenu : GameScreen
	{
        private new GameBase Game => (GameBase)base.Game;

        public MainMenu(GameBase game) : base(game) { }
        
        private SpriteFont _debugFont;
        private ParticleEffect _particleEffect;
        private Texture2D _particleTexture;

        private Texture2D _gameLogoTexture;
        private Texture2D _newButtonTexture;
        private Texture2D _loadButtonTexture;
        private Texture2D _coopButtonTexture;
        private Texture2D _optionsButtonTexture;
        private Texture2D _quitButtonTexture;
        private SelectedOption _selectedOption = SelectedOption.New;
        private Color _playButtonColor = Color.White;
        private Color _loadButtonColor = Color.White;
        private Color _coopButtonColor = Color.White;
        private Color _optionsButtonColor = Color.White;
        private Color _quitButtonColor = Color.White;
        
        
    
        public override void LoadContent()
        {
            base.LoadContent();
            _debugFont = Game.Content.Load<SpriteFont>("Fonts/OpenSans");
            _newButtonTexture = Game.Content.Load<Texture2D>("Sprites/menu-button-new");
            _loadButtonTexture = Game.Content.Load<Texture2D>("Sprites/menu-button-load");
            _coopButtonTexture = Game.Content.Load<Texture2D>("Sprites/menu-button-coopt");
            _optionsButtonTexture = Game.Content.Load<Texture2D>("Sprites/menu-button-options");
            _quitButtonTexture = Game.Content.Load<Texture2D>("Sprites/menu-button-quit");
            _gameLogoTexture = Game.Content.Load<Texture2D>("Sprites/game-logo-bad");
            
            _particleTexture = new Texture2D(GraphicsDevice, 1, 1);
            _particleTexture.SetData(new[] { Color.White });

            TextureRegion2D textureRegion = new TextureRegion2D(_particleTexture);
            _particleEffect = new ParticleEffect(autoTrigger: false)
            {
                Position = new Vector2(200, 240),
                Emitters = new List<ParticleEmitter>
                {
                    new ParticleEmitter(textureRegion, 500, TimeSpan.FromSeconds(0.5f),
                        Profile.BoxUniform(200,80))
                    {
                        Parameters = new ParticleReleaseParameters
                        {
                            Speed = new Range<float>(0f, 50f),
                            Quantity = 5,
                            Rotation = new Range<float>(-0.1f, 0.1f),
                            Scale = new Range<float>(3.0f, 4.0f)
                        },
                        Modifiers =
                        {
                            new AgeModifier
                            {
                                Interpolators =
                                {
                                    new ColorInterpolator
                                    {
                                        StartValue = Color.Yellow.ToHsl(),
                                        EndValue = Color.Blue.ToHsl()
                                    }
                                }
                            },
                            new RotationModifier {RotationRate = 5f},
                            new RectangleContainerModifier {Width = 800, Height = 480},
                            new LinearGravityModifier {Direction = -Vector2.UnitY, Strength = 30f},
                            new OpacityFastFadeModifier()
                        }
                    }
                }
            };
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.IsKeyPressed(Keys.W, true)|| Input.IsKeyPressed(Keys.Up, true))
            {
                if (_particleEffect.Position.X <= 240)
                {
                    var pos = _particleEffect.Position;
                    pos.Y -= 100;
                    _particleEffect.Position = pos;
                }
                
            }

            if (_particleEffect.Position.Y < 240)
            {
                var pos = _particleEffect.Position;
                pos.Y = 240;
                _particleEffect.Position = pos;
            } 

            if (Input.IsKeyPressed(Keys.S, true)|| Input.IsKeyPressed(Keys.Down, true))
            {
                if (_particleEffect.Position.X <= 640)
                {
                    var pos = _particleEffect.Position;
                    pos.Y += 100;
                    _particleEffect.Position = pos;
                }
            }
            
            if (_particleEffect.Position.Y > 640)
            {
                var pos = _particleEffect.Position;
                pos.Y = 640;
                _particleEffect.Position = pos;
            }

            if (_particleEffect.Position.Y == 240)
            {
                _selectedOption = SelectedOption.New;
            }
            else if (_particleEffect.Position.Y == 340)
            {
                _selectedOption = SelectedOption.Load;
            }
            else if (_particleEffect.Position.Y == 440)
            {
                _selectedOption = SelectedOption.Coop;
            }
            else if (_particleEffect.Position.Y == 540)
            {
                _selectedOption = SelectedOption.Options;
            }
            else if (_particleEffect.Position.Y == 640)
            {
                _selectedOption = SelectedOption.Quit;
            }
            
            switch (_selectedOption)
            {
                case SelectedOption.New:
                    _playButtonColor = new(158, 158, 158);
                    _loadButtonColor = Color.White;
                    _coopButtonColor = Color.White;
                    _optionsButtonColor = Color.White;
                    _quitButtonColor = Color.White;
                    break;
                case SelectedOption.Load:
                    _loadButtonColor = new(158, 158, 158);
                    _playButtonColor = Color.White;
                    _coopButtonColor = Color.White;
                    _optionsButtonColor = Color.White;
                    _quitButtonColor = Color.White;
                    break;
                case SelectedOption.Coop:
                    _coopButtonColor = new(158, 158, 158);
                    _playButtonColor = Color.White;
                    _loadButtonColor = Color.White;
                    _optionsButtonColor = Color.White;
                    _quitButtonColor = Color.White;
                    break;
                case SelectedOption.Options:
                    _optionsButtonColor = new(158, 158, 158);
                    _playButtonColor = Color.White;
                    _loadButtonColor = Color.White;
                    _coopButtonColor = Color.White;
                    _quitButtonColor = Color.White;
                    break;
                case SelectedOption.Quit:
                    _quitButtonColor = new(158, 158, 158);
                    _playButtonColor = Color.White;
                    _loadButtonColor = Color.White;
                    _coopButtonColor = Color.White;
                    _optionsButtonColor = Color.White;
                    break;
            }

            _particleEffect.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Game.ClearColor);
            
            Game.SpriteBatch.Begin();
            
            Game.SpriteBatch.Draw(_newButtonTexture, new Vector2(100, 200), _playButtonColor);
            Game.SpriteBatch.Draw(_loadButtonTexture, new Vector2(100, 300), _loadButtonColor);
            Game.SpriteBatch.Draw(_coopButtonTexture, new Vector2(100, 400), _coopButtonColor);
            Game.SpriteBatch.Draw(_optionsButtonTexture, new Vector2(100, 500), _optionsButtonColor);
            Game.SpriteBatch.Draw(_quitButtonTexture, new Vector2(100, 600), _quitButtonColor);
            Game.SpriteBatch.Draw(_gameLogoTexture, new Vector2(20, 0), Color.White);
            
            Game.SpriteBatch.Draw(_particleEffect);
            
            
            Game.SpriteBatch.DrawString(_debugFont, "Development Build 0.0.1", new Vector2(10, Game.GraphicsDevice.Viewport.Height - 40), Color.White);
            Game.SpriteBatch.DrawString(_debugFont, "Emir Makes Games ", new Vector2(10, Game.GraphicsDevice.Viewport.Height - 20), Color.White);
            // _particleEffect position
            Game.SpriteBatch.DrawString(_debugFont, $"X: {_particleEffect.Position.X} Y: {_particleEffect.Position.Y}", new Vector2(10, 10), Color.White);
            Game.SpriteBatch.End();
        }

    }
}

