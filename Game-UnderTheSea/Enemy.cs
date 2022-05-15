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
        /// Move the object vertically
        /// </summary>
        /// <param name="direction"></param> Enum that defines the movement of the object up and down
        public void Move(DirectionS direction)
        {
            switch (direction)
            {
                case DirectionS.Up:
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    break;
                case DirectionS.Down:
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    break;
                default:
                    break;
            }
        }
    }

    enum DirectionS
    {
        Up,
        Down
    }
}