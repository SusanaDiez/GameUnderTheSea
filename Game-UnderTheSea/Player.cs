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
            var maxDownPosition = 0;
            var position = this.Location.Y;
            if (direction == Direction.Up)
            {
                position = this.Location.Y > maxUpPosition ? this.Location.Y - 5 : maxUpPosition;
            }
            else
            {
                position = this.Location.Y >= maxDownPosition ? this.Location.Y + 5 : maxDownPosition;
            }
            this.Location = new Point(this.Location.X, position);
        }

        //public void Move(Direction direction)
        //{
        //    switch (direction)
        //    {
        //        case Direction.Up:
        //            this.Location = new Point(this.Location.X, this.Location.Y - 5);
        //            break;
        //        case Direction.Down:
        //            this.Location = new Point(this.Location.X, this.Location.Y + 5);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
    enum Direction
    {
        Up,
        Down
    }
}
