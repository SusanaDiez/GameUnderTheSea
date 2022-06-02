using Game_UnderTheSea.commons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


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

        public void Remove(Bubble bubble)
        {
            bubbles.Remove(bubble);
        }

        /// <summary>
        /// Move the object vertically
        /// </summary>
        /// <param name="direction"></param> Enum that defines the movement of the object up and down.

        public void Move(DirectionEnum direction)
        {
            var maxUpPosition = 0;
            var maxDownPosition = 520;
            int position;
            var newPoint = false;

            if (direction == DirectionEnum.Up)
            {
                if (Location.Y >= maxUpPosition)
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
    }
}