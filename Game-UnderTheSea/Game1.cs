using Game_UnderTheSea.commons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Linq;

namespace Game_UnderTheSea
{
    public class Game1 : Game
    {
        private int DolphinLives { get; set; }
        private int SharkLives { get; set; }
        private int Score { get; set; }
        private int MaxScore { get; set; }
        private Player Dolphin { get; set; }
        private Enemy Shark { get; set; }
        public KeyboardState CurrentKey { get; set; }
        public KeyboardState PreviousKey { get; set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private Song Music;
        SoundEffect bubbleSound;
        SoundEffect biteSound;

        Texture2D background;
        Texture2D gameOver;
        Texture2D youWin;
        Rectangle backgroundRectangle;
        Rectangle gameOverRectangle;
        Rectangle youWinRectangle;

        bool mySwitch = false;
        Random myRandom;
        const byte doIShoot = 5;

        public Game1(int dolphinLives, int sharkLives, int score)
        {
            DolphinLives = dolphinLives;
            SharkLives = sharkLives;
            Score = score;
            MaxScore = MaxScore;

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
            Dolphin = new Player();
            Shark = new Enemy();
            myRandom = new Random();
            backgroundRectangle = new Rectangle(0, 0, 1200, 700);
            gameOverRectangle = new Rectangle(0, 0, 1200, 700);
            youWinRectangle = new Rectangle(0, 0, 1200, 700);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Background");
            gameOver = Content.Load<Texture2D>("GameOver");
            youWin = Content.Load<Texture2D>("YouWin");
            Dolphin.LoadContent(Content);
            Shark.LoadContent(Content);
            font = Content.Load<SpriteFont>("File");
            Music = Content.Load<Song>("Theme");
            bubbleSound = Content.Load<SoundEffect>("BubbleSound");
            biteSound = Content.Load<SoundEffect>("BiteSound");
            MediaPlayer.Play(Music);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            ValidateGame();

            Keyboards();

            Collisions();

            TouchShark();

            TouchDolphin();

            EnemyAttack();

            base.Update(gameTime);
        }

        protected void ValidateGame()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }

        protected void Keyboards()
        {
            var myKeyboard = Keyboard.GetState();

            try
            {
                if (myKeyboard.IsKeyDown(Keys.Up))
                {
                    Dolphin.Move(DirectionEnum.Up);
                }
                else if (myKeyboard.IsKeyDown(Keys.Down))
                {
                    Dolphin.Move(DirectionEnum.Down);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            PreviousKey = CurrentKey;
            CurrentKey = Keyboard.GetState();

            if (CurrentKey.IsKeyDown(Keys.Space) && PreviousKey.IsKeyUp(Keys.Space))
            {
                Dolphin.Shoot(this.Content, Dolphin.Location);

                bubbleSound.Play();
            }
        }

        protected void Collisions()
        {
            foreach (var bubble in Dolphin.bubbles)
            {
                var fang = Shark.fangs.FirstOrDefault(x => x.rectangle.Intersects(bubble.rectangle));

                if (fang != null)
                {
                    Dolphin.bubbles.Remove(bubble);
                    Shark.fangs.Remove(fang);
                    Score++;
                    break;
                }
            }

            foreach (var item in Dolphin.bubbles)
            {
                item.MoveRight();
            }
        }

        protected void TouchShark()
        {
            foreach (var bubble in Dolphin.bubbles)
            {
                if (Shark.rectangle.Intersects(bubble.rectangle))
                {
                    Dolphin.bubbles.Remove(bubble);
                    SharkLives--;
                    Score += 5;
                    break;
                }
            }
        }

        protected void TouchDolphin()
        {
            foreach (var fang in Shark.fangs)
            {
                if (Dolphin.rectangle.Intersects(fang.rectangle))
                {
                    Shark.fangs.Remove(fang);
                    DolphinLives--;

                    break;
                }
            }
        }

        protected void EnemyAttack()
        {
            if (mySwitch)
            {
                Shark.Move(DirectionEnum.Up);
            }
            else
            {
                Shark.Move(DirectionEnum.Down);
            }
            if (Shark.Location.Y > (this.Window.ClientBounds.Height - Shark.Size.Y))
            {
                mySwitch = true;
            }
            if (Shark.Location.Y < 0)
            {
                mySwitch = false;
            }

            if (myRandom.Next(1, 80) == doIShoot)
            {
                Shark.Shoot(this.Content, Shark.Location);
                biteSound.Play();
            }

            foreach (var item in Shark.fangs)
            {
                item.MoveLeft();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(background, backgroundRectangle, Color.White);

            _spriteBatch.DrawString(font, "Lives " + DolphinLives, new Vector2(50, 10), Color.Green);

            _spriteBatch.DrawString(font, "Score " + Score, new Vector2(550, 10), Color.White);

            _spriteBatch.DrawString(font, "Lives " + SharkLives, new Vector2(1000, 10), Color.Red);

            _spriteBatch.DrawString(font, "Max Score " + MaxScore, new Vector2(900, 600), Color.White);

            Dolphin.Draw(_spriteBatch, Color.White);

            foreach (var item in Dolphin.bubbles)
            {
                item.Draw(_spriteBatch, Color.White);
            }

            Shark.Draw(_spriteBatch, Color.White);

            foreach (var item in Shark.fangs)
            {
                item.Draw(_spriteBatch, Color.White);
            }

            if (DolphinLives == 0)
            {
                _spriteBatch.Draw(gameOver, gameOverRectangle, Color.White);
            }

            if (SharkLives == 0)
            {
                _spriteBatch.Draw(youWin, gameOverRectangle, Color.White);
                Shark.Remove();
                Dolphin.Remove();
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
