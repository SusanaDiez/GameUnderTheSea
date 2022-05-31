using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_UnderTheSea
{
    class Bubble : Sprite
    {
        public Bubble(ContentManager contentManager) : this(contentManager, new Point())
        {

        }

        public Bubble(ContentManager contentManager, Point location) : base("Bubble", location, new Point(50))
        {
            this.LoadContent(contentManager);
            this.Location = new Point(this.Location.X + 230, this.Location.Y + 100);
        }

        public void MoveRight()
        {
            this.Location = new Point(this.Location.X + 10, this.Location.Y);
        }

        public Rectangle Rectangle
        {
            get
            {
                return Rectangle;
            }
        }
    }
}
