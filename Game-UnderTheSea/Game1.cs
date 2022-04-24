using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Game_UnderTheSea
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player dolphin;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();



        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            dolphin = new Player();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            dolphin.LoadContent(this.Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState myKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here

            if (myKeyboard.IsKeyDown(Keys.Up))
            {
                dolphin.Move(false);
            }
            else if (myKeyboard.IsKeyDown(Keys.Down))
            {
                dolphin.Move(true);
            }
            else if (myKeyboard.IsKeyDown(Keys.Space))
            {
                dolphin.Shoot(this.Content, dolphin.Location);

            }

            foreach (var item in dolphin.bubbles)
            {
                item.MoveRight();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(red,green,blue));
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            dolphin.Draw(this._spriteBatch, Color.White);

            foreach (var item in dolphin.bubbles)
            {
                item.Draw(this._spriteBatch, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
