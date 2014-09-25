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
    class Entity
    {
        //include player class
        Player player;

        //Visual
        Texture2D sprite;

        //Movement
        Vector2 position;
        Vector2 dimensions;
        Vector2 velocity;
        float speed;

        //Logic
        
        int brain; //1 = dumb, 2 = enemy fighter, 3 = enemy bomber

        public Entity(Texture2D a_sprite, Vector2 a_position, int a_brain)
        {
            sprite = a_sprite;
            position = a_position;
            brain = a_brain;


            //initialise entity based off brain
            if (brain == 2)
            {
                speed = 5;
            }

        }

        public void Update()
        {
            //basic AI / Movement
            if (brain == 2) //If enemy fighter
            {
                AIenemyFighter();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position, Color.White);
        }

        void AIenemyFighter()
        {
            position.Y = position.Y + speed;
        }

    }
}

