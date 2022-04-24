using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_UnderTheSea
{
    class Enemy : Sprite
    {
        public List<Fangs>fangs;
        public Enemy() : base("Shark", new Point(1000, 200), new Point(200, 200))
        {
            fangs = new List<Fangs>();
        }

        public void Shoot(ContentManager content, Point location)
        {
            fangs.Add(new Fangs(content, location));

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