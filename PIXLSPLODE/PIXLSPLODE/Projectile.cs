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
    class Projectile
    {
        Vector2 position;
        int attackPower;
        int moveType; //0 = direction based, 1 = homing on player, 3 = hybrid of both (like a missile that fires straight then turns towards target
        int team; //the team that the laser is on for collision
        Texture2D sprite;

        Vector2 direction;
        float speed;

        public Projectile(Texture2D a_sprite, Vector2 a_position, int a_attackPower, float a_speed, Vector2 a_direction, int a_moveType, int a_team) //possibly add another variable for hitting other projetiles / cancelling them out
        {
            sprite = a_sprite;
            position = a_position;
            attackPower = a_attackPower;
            speed = a_speed;
            direction = a_direction;
            moveType = a_moveType;
            team = a_team;
        }

        public void Update()
        {
            //movement
            // if movetype = 1
            if (moveType == 0) // straight line
            {
                position.Y++;
                //position += direction * speed;
            }
        
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position, Color.White);
        }

    }
}
