using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mandalina.Core.Graphics;

public class RectangleOverlay 
{
    SpriteBatch spriteBatch;
    Texture2D dummyTexture;
    Color Colori;
    private Game _game;
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }

    public RectangleOverlay(Vector2 position, Vector2 size, Color colori, Game game)
    {
        _game = game;
        Position = position;
        Size = size;
        Colori = colori;
    }

    public void LoadContent()
    {
        spriteBatch = new SpriteBatch(_game.GraphicsDevice);
        dummyTexture = new Texture2D(_game.GraphicsDevice, 1, 1);
        dummyTexture.SetData(new Color[] { Color.White });
    }

    public void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(dummyTexture, 
            new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), 
            Colori);
        spriteBatch.End();
    }
}