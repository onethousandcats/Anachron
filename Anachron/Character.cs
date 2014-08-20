﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    class Character
    {
        private Texture2D _character;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private bool moving;
        private bool right;

        public int acceleration { get; set; }
        public int hop { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public Character(Texture2D character, int x, int y)
        {
            _character = character;
            Rows = 6;
            Columns = 6;
            currentFrame = 0;
            totalFrames = Columns;
            this.x = x;
            this.y = y;

            acceleration = 6;
            //hop = 0;

            moving = false;
            //eventually this should point towards the middle of the screen depending on where the player is initially placed.
            right = true;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void IsGoingRight()
        {
            right = true;
        }

        public void IsGoingLeft()
        {
            right = false;
        }

        public void IsMoving(bool Moving)
        {
            moving = Moving;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = _character.Width / Columns;
            int height = _character.Height / Rows;
            //int row = (int)((float)currentFrame / (float)Columns);
            
            int row = 0;
            Console.WriteLine("right: " + this.right + " -- " +  "moving: " + this.moving);
            
            if (!this.right)
                row += 1;

            int currentAcceleration = acceleration;

            if (this.moving)
            {
                row += 2;

                if (currentFrame % 2 == 0)
                {
                    //currentAcceleration = currentAcceleration;
                    this.y += hop;
                    hop = -hop;
                }

                if (this.right)
                {
                    this.x += currentAcceleration;
                }
                else
                { 
                    this.x -= currentAcceleration;
                }

            }

            Console.WriteLine("row: " + row);

            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(_character, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}