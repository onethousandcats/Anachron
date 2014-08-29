#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Anachron
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Anachron : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private World _world;

        int frameRate = 8; //100 = 1 seconds
        int time = 0;

        public Anachron()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1400;
            graphics.PreferredBackBufferHeight = 800;
            
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D k = Content.Load<Texture2D>("astro");
            Character astro = new Character(k, 100, 100);

            _world.AddPlayer(astro);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().GetPressedKeys().Length == 0)
            {
                //no keys are being pressed, character is not moving
                _world.Player.IsMoving(false);

            }
            

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _world.Player.IsMoving(true);
                _world.Player.IsGoingRight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _world.Player.IsMoving(true);
                _world.Player.IsGoingLeft();
            }

            time++;
            if (time == frameRate)
            { 
                foreach (Character c in _world.AllPlayers)
                {
                    c.Update();
                }
                
                time = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            foreach (Character c in _world.AllPlayers)
            {
                c.Draw(spriteBatch, new Vector2(c.x, c.y));
            }
            base.Draw(gameTime);
        }
    }
}
