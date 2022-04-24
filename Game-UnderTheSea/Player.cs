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
        public Player() : base("Dolphin", new Point(0, 150), new Point(200, 200))
        {
            bubbles = new List<Bubble>();
        }

        public void Shoot(ContentManager content, Point location)
        {
            bubbles.Add(new Bubble(content, location));

        }

        /// <summary>
        /// Move the object horizontally
        /// </summary>
        /// <param name="direction">Boolean, True will move the object to the right, False will move the object to the Left</param>
        public void Move(bool direction)
        {
            if (direction)
            {
                this.Location = new Point(this.Location.X, this.Location.Y + 5);
            }
            else
            {
                this.Location = new Point(this.Location.X, this.Location.Y - 5);
            }
        }



    }
}
