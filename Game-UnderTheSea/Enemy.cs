using Game_UnderTheSea.commons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Game_UnderTheSea
{
    class Enemy : Sprite
    {
        public List<Fangs> fangs;

        public Enemy() : base("Shark", new Point(1000, 200), new Point(200, 200))
        {
            fangs = new List<Fangs>();
        }

        public void Shoot(ContentManager content, Point location)
        {
            fangs.Add(new Fangs(content, location));

        }

        public void Remove(Fangs fang)
        {
            fangs.Remove(fang);
        }

        /// <summary>
        /// Move the object vertically
        /// </summary>
        /// <param name="direction"></param> Enum that defines the movement of the object up and down
        public void Move(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Up:
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    break;
                case DirectionEnum.Down:
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    break;
                default:
                    break;
            }
        }

        internal void Remove(object fang)
        {
            throw new NotImplementedException();
        }

    }
}