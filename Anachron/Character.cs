using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    enum Direction { Left, Right };

    public class Astronaut : Character
    {
    }

    public class Character
    {
        private Texture2D _character;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private bool moving;
        public bool falling { get; set; }
        public bool jumping { get; set; }

        private bool alive;

        public int JumpVelocity { get; set; }

        private Direction direction;

        public int speed { get; set; }
        public int strength { get; set; }
        public int range { get; set; }

        public int acceleration { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int vx { get; set; }
        public int vy { get; set; }

        public int Feet { get { return this.y + this.Height; } }

        public Character()
        {

        }

        public Character(Texture2D character, int x, int y)
        {
            _character = character;
            Rows = 6;
            Columns = 4;
            currentFrame = 0;
            totalFrames = Columns;
            this.x = x;
            this.y = y;

            this.vx = 6;
            this.vy = 0;

            this.Width = _character.Width / Columns;
            this.Height = _character.Height / Rows;
            
            moving = false;
            falling = true;

            JumpVelocity = 10;

            //eventually this should point towards the middle of the screen depending on where the player is initially placed.
            direction = Direction.Right;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Jump()
        {
            if (!this.falling)
            { 
                this.vy = -(this.JumpVelocity);
                this.jumping = true;
            }
        }

        public void Grounded()
        {
            this.falling = false;
            this.jumping = false;
        }

        public void IsGoingRight()
        {
            direction = Direction.Right;
        }

        public void IsGoingLeft()
        {
            direction = Direction.Left;
        }

        public void IsMoving(bool Moving)
        {
            moving = Moving;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
           
            //int row = (int)((float)currentFrame / (float)Columns);
            
            int row = 0;
            
            if (this.direction == Direction.Left)
            {
                row += 1;
            }

            //int currentAcceleration = acceleration;

            if (this.moving)
            {
                row += 2;

                if (this.direction == Direction.Right)
                {
                    this.x += this.vx;
                }
                else
                { 
                    this.x -= this.vx;
                }

            }

            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Begin();
            spriteBatch.Draw(_character, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
