using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game_UnderTheSea
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D background;
        Rectangle backgroundRectangle;
        Player dolphin;
        Enemy shark;

        bool mySwitch = false;
        Random myRandom;
        const byte doIShoot = 5;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 700;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();



        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            dolphin = new Player();
            shark = new Enemy();
            myRandom = new Random();

            backgroundRectangle = new Rectangle(0, 0, 1200, 700);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            background = this.Content.Load<Texture2D>("Background");
            dolphin.LoadContent(this.Content);
            shark.LoadContent(this.Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState myKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here


            if (myKeyboard.IsKeyDown(Keys.Up))
            {
                dolphin.Move(Direction.Up);
            }
            else if (myKeyboard.IsKeyDown(Keys.Down))
            {
                dolphin.Move(Direction.Down);
            }
            else if (myKeyboard.IsKeyDown(Keys.Space))
            {
                dolphin.Shoot(this.Content, dolphin.Location);
            }
            

            foreach (var item in dolphin.bubbles)
            {
                item.MoveRight();
            }

            if (mySwitch)
            {
                shark.Move(DirectionS.Up);
            }
            else
            {
                shark.Move(DirectionS.Down);
            }
            if (shark.Location.Y > (this.Window.ClientBounds.Height - shark.Size.Y))
            {
                mySwitch = true;
            }
            if (shark.Location.Y < 0)
            {
                mySwitch = false;
            }

            if (myRandom.Next(1,80) == doIShoot)
            {
                shark.Shoot(this.Content, shark.Location);
            }

            foreach (var item in shark.fangs)
            {
                item.MoveLeft();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Draw(new _spriteBatch("Background"));
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(background, backgroundRectangle, Color.White);

            dolphin.Draw(this._spriteBatch, Color.White);

            foreach (var item in dolphin.bubbles)
            {
                item.Draw(this._spriteBatch, Color.White);
            }

            shark.Draw(this._spriteBatch, Color.White);

            foreach (var item in shark.fangs)
            {
                item.Draw(this._spriteBatch, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
