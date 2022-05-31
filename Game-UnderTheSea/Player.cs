using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_UnderTheSea
{
    class Player : Sprite
    {
        public List<Bubble> bubbles;

        public Rectangle rectangle;

        private Point location;

        private string sourceImageName;

        private Point size;

        public Player() : base("Dolphin", new Point(0, 150), new Point(250, 250))
        {
            bubbles = new List<Bubble>();
        }

        public void Shoot(ContentManager content, Point location)
        {
            bubbles.Add(new Bubble(content, location));
        }

        /// <summary>
        /// Move the object vertically
        /// </summary>
        /// <param name="direction"></param> Enum that defines the movement of the object up and down.

        public void Move(Direction direction)
        {
            var maxUpPosition = 0;
            var maxDownPosition = 520;
            int position;
            var newPoint = false;

            if (direction == Direction.Up)
            {
                if(Location.Y >= maxUpPosition)
                {
                    position = Location.Y - 5;
                    newPoint = true;
                }
                else
                {
                    position = maxUpPosition;
                }
            }
            else
            {
                if (Location.Y <= maxDownPosition)
                {
                    position = Location.Y + 5;
                    newPoint = true;
                }
                else
                {
                    position = maxUpPosition;
                }
            }

            if (newPoint)
            {
                Location = new Point(Location.X, position);
            }
        }

        public Player(string sourceImageName, Point location, Point size)
        {
            this.sourceImageName = sourceImageName;
            this.location = location;
            this.size = size;
            this.rectangle = new Rectangle(this.Location, this.Size);
        }

    }

}
    enum Direction
    {
        Up,
        Down
    }
