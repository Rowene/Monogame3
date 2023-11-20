using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Runtime.CompilerServices;

namespace Monogame3
{
    public class Game1 : Game
    {
        Random generator = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D textureBrown;
        Texture2D textureCream;
        Texture2D textureGrey;
        Texture2D textureOrange;
        Rectangle rectangleBrown;
        Rectangle rectangleCream;
        Rectangle rectangleGrey;
        Rectangle rectangleOrange;
        Vector2 speedBrown;
        Vector2 speedCream;
        Vector2 speedGrey; 
        Vector2 speedOrange;
        int numBackGround;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.ApplyChanges();

            rectangleBrown = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            rectangleCream = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100,100);
            rectangleGrey = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            rectangleOrange = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            speedBrown = new Vector2(generator.Next(4), generator.Next(5, 10));
            speedCream = new Vector2(generator.Next(4,9), generator.Next(3));
            speedGrey = new Vector2(0, generator.Next(2, 6));
            speedOrange = new Vector2(generator.Next(3, 8), 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            textureBrown = Content.Load<Texture2D>("tribbleBrown");
            textureCream = Content.Load<Texture2D>("tribbleCream");
            textureGrey = Content.Load<Texture2D>("tribbleGrey");
            textureOrange = Content.Load<Texture2D>("tribbleOrange");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            rectangleBrown.X += (int)speedBrown.X;
            rectangleBrown.Y += (int)speedBrown.Y;

            rectangleCream.X += (int)speedCream.X;
            rectangleCream.Y += (int)speedCream.Y;

            rectangleGrey.X += (int)speedGrey.X;
            rectangleGrey.Y += (int)speedGrey.Y;

            rectangleOrange.X += (int)speedOrange.X;
            rectangleOrange.Y += (int)speedOrange.Y;

            if ((rectangleBrown.Right >= _graphics.PreferredBackBufferWidth)|| (rectangleBrown.Left <= 0)) { speedBrown.X *= -1; numBackGround = 1; }
            if ((rectangleBrown.Bottom >= _graphics.PreferredBackBufferHeight)|| (rectangleBrown.Top <= 0)) { speedBrown.Y *= -1; numBackGround = 1; }

            if ((rectangleCream.Right >= _graphics.PreferredBackBufferWidth) || (rectangleCream.Left <= 0)) { speedCream.X *= -1; numBackGround = 2; }
            if ((rectangleCream.Bottom >= _graphics.PreferredBackBufferHeight) || (rectangleCream.Top <= 0)) { speedCream.Y *= -1; numBackGround = 2; }

            if ((rectangleGrey.Right >= _graphics.PreferredBackBufferWidth) || (rectangleGrey.Left <= 0)) { speedGrey.X *= -1; numBackGround = 3; }
            if ((rectangleGrey.Bottom >= _graphics.PreferredBackBufferHeight) || (rectangleGrey.Top <= 0)) { speedGrey.Y *= -1; numBackGround = 3; }

            if ((rectangleOrange.Right >= _graphics.PreferredBackBufferWidth) || (rectangleOrange.Left <= 0)) { speedOrange.X *= -1; numBackGround = 4; }
            if ((rectangleOrange.Bottom >= _graphics.PreferredBackBufferHeight) || (rectangleOrange.Top <= 0)) { speedOrange.Y *= -1; numBackGround = 4; }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            if (numBackGround == 1) { GraphicsDevice.Clear(Color.SaddleBrown); }
            else if (numBackGround == 2) { GraphicsDevice.Clear(Color.Beige); }
            else if (numBackGround == 3) { GraphicsDevice.Clear(Color.Gray); }
            else { GraphicsDevice.Clear(Color.Orange); }
            _spriteBatch.Begin();
            _spriteBatch.Draw(textureBrown, rectangleBrown, Color.White);
            _spriteBatch.Draw(textureCream, rectangleCream, Color.White);
            _spriteBatch.Draw(textureGrey, rectangleGrey, Color.White);
            _spriteBatch.Draw(textureOrange, rectangleOrange, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}