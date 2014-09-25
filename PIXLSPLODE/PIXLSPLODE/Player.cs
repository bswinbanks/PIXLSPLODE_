using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PIXLSPLODE
{
    class Player
    {   

        // Inherent classes
        ProjectileManager projectileManager = new ProjectileManager();

        public Vector2 position;

        // Dimensions holds our width and height (X =width, and Y = height)
        Vector2 dimensions;

        Texture2D sprite;
        public Vector2 direction;
        float speed;
        float health;
        int spriteType;

        // This stores a GraphicsDeviceManager object, so we can
        // check our m_position against m_graphics.PreferredBackBufferWidth.
        // (We can't just use graphics.PreferredBackBufferWidth in our Player class
        // because it belongs to the Game1 class).
        GraphicsDeviceManager graphics;

        // --- But put your variables before the functions:

        // This is called every time we write 
        // 'Player MyPlayer = new Player()'.
        public Player()
        {
        }

        // This is like the above, except we can pass in values to 'set up'
        // our player class. 
        // E.g. Player MyPlayer = new Player(new Vector2(100, 100),
        // new Vector2(64, 64), 5, 100); 
        // ^ This set up position, dimensions, speed, and health, for a Player
        // object named 'MyPlayer'.
        public Player(Vector2 a_startPosition, Vector2 a_dimensions, float a_speed, float a_health)
        {
            position = a_startPosition;
            dimensions = a_dimensions;
            speed = a_speed;
            health = a_health;
        }

        public void SetSprite(Texture2D a_newSprite)
        {
            sprite = a_newSprite;
        }

        public void ContentLoad(ContentManager content)
        {
            projectileManager.ContentLoad(content);
        }

        public void SetGraphicsDeviceManager(GraphicsDeviceManager a_graphics)
        {
            graphics = a_graphics;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                projectileManager.ShootLaser(new Vector2(5, 5), 5, 1, new Vector2(0, 0), 0, 0);
            }

            UpdateControls();
            ConstrainPlayerToScreen();
        }

    
        void UpdateControls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) // UP
            {
                position.Y -= (int)speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) // DOWN
            {
                position.Y += (int)speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) // LEFT
            {
                position.X -= (int)speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D)) // RIGHT
            {
                position.X += (int)speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) //SHOOT LASER - DOESNT WORK
            {
                projectileManager.ShootLaser(new Vector2(5, 5), 5, 1, new Vector2(0, 0), 0, 0);
            }

        }

        // This function will make sure our player stays on the screen.
        // It uses our GraphicsDeviceManager variable (m_graphics) to compare
        // the Player position to the sides of the screen, and makes sure it
        // doesn't leave it.
        void ConstrainPlayerToScreen()
        {
            // LEFT SIDE
            if (position.X < 0)
            {
                position.X = 0;
            }

            // RIGHT SIDE
            if (position.X + dimensions.X > graphics.PreferredBackBufferWidth)
            {
                position.X = graphics.PreferredBackBufferWidth
                                - dimensions.X;
            }

            // TOP SIDE
            if (position.Y < 0)
            {
                position.Y = 0;
            }

            // BOTTOM SIDE
            if (position.Y + dimensions.Y > graphics.PreferredBackBufferHeight)
            {
                position.Y = graphics.PreferredBackBufferHeight
                                - dimensions.Y;
            }

        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                                   (int)dimensions.X, (int)dimensions.Y);
        }


        public void Draw(SpriteBatch a_spriteBatch)
        {
            a_spriteBatch.Draw(sprite, GetRectangle(), Color.White);     
        }

    }
}
