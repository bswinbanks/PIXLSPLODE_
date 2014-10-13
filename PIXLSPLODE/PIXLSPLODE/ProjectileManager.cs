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
    class ProjectileManager
    {
        //Lists
        List<Projectile> projectiles = new List<Projectile>();

        //Sprites
        Texture2D spriteLaser;

        //Attributes
        Vector2 position;
        int attackPower;
        int moveType; //0 = direction based, 1 = homing on player, 3 = hybrid of both (like a missile that fires straight then turns towards target
        int team; //the team that the laser is on for collision
        Vector2 direction;
        float speed;



        public ProjectileManager(){}

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                ShootLaser(new Vector2(5,5), 5, 1, new Vector2(0,0), 0, 0);
            }

            foreach (Projectile each in projectiles)
            {
                each.Update();
            }
        }

        public void ContentLoad(ContentManager content)
        {
            spriteLaser = content.Load<Texture2D>("playerLaser");
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Projectile each in projectiles)
            {
                each.Draw(spritebatch);
            }
        }

       public void ShootLaser (Vector2 a_position, int a_attackPower, float a_speed, Vector2 a_direction, int a_moveType, int a_team)
       {

           position = a_position;
           attackPower = a_attackPower;
           speed = a_speed;
           direction = a_direction;
           moveType = a_moveType;
           team = a_team;
    
           projectiles.Add(new Projectile(spriteLaser, position, 5, 2, new Vector2(0,1), 0, 0));
       }

    }

}
