using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    class Collidable
    {
        private Texture2D _collidable;

        public int x { get; set; }
        public int y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Collidable(Texture2D image, int x, int y)
        {
            this._collidable = image;

            this.x = x;
            this.y = y;

            this.Width = _collidable.Width;
            this.Height = _collidable.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 location = new Vector2() { X = this.x, Y = this.y };

            Rectangle sourceRectangle = new Rectangle(this.x, this.y, this.Width, this.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, this.Width, this.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(this._collidable, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool CollidesWith(Character c)
        {
            var futureX = c.x + c.vx;
            var futureY = c.Feet + c.vy;

            Console.WriteLine(futureY + "..." + this.y);

            if (this.x < futureX && this.x + this.Width > futureX)
            {
                //is between the object
                if (this.y < futureY && this.y > c.Feet)
                {
                    return true;
                }
            }


            return false;
        }
    }
}
