using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PIXLSPLODE
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //XNA
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        SamplerState noFilter = SamplerState.PointClamp;

        // CLASSES
        Player myPlayer = new Player();
        Spawner spawn = new Spawner();
        ProjectileManager projectileManager = new ProjectileManager();

        int resMultiplier = 3; //pixel multiplier

        // LOGIC

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 64*resMultiplier;
            graphics.PreferredBackBufferHeight = 128*resMultiplier;
        }

        protected override void Initialize()
        {

            myPlayer = new Player(new Vector2(100, 100), new Vector2(5*resMultiplier, 7*resMultiplier),
                                    3, 100);
            myPlayer.SetGraphicsDeviceManager(graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D tempSprite = Content.Load<Texture2D>("player");

            myPlayer.SetSprite(tempSprite);
           // myPlayer.ContentLoad(Content);
            spawn.ContentLoad(Content);
            projectileManager.ContentLoad(Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.V)) //SHOOT LASER TEST - WORKS
            {
                projectileManager.ShootLaser(new Vector2(5, 5), 5, 1, new Vector2(0, 0), 0, 0);
            }

            // TODO: Add your update logic here
            projectileManager.Update();
            myPlayer.Update();
            spawn.Update();
            



            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.SamplerStates[0] = noFilter;
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);


            myPlayer.Draw(spriteBatch);
            spawn.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
