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
    class Spawner
    {
        //Lists
        List<Entity> entities = new List<Entity>();
        
        //Sprites
        Texture2D sprite_enemyFighter;
        ProjectileManager pmanage = new ProjectileManager();

        public Spawner(){}

        // UPDATE, CONTENT LOAD, DRAW
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                SpawnFigher();
                pmanage.ShootLaser(new Vector2(5, 5), 5, 1, new Vector2(0, 1), 0, 0);
            }

            foreach (Entity each in entities)
            {
                each.Update();
            }

        }

        public void ContentLoad(ContentManager content)
        {
            sprite_enemyFighter = content.Load<Texture2D>("enemyFighter");
            pmanage.ContentLoad(content);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Entity each in entities)
            {
                each.Draw(spritebatch);
            }
        }

        // CUSTOM FUNCTIONS
        public void SpawnFigher()
        {
            entities.Add(new Entity(sprite_enemyFighter, new Vector2(5, 5), 2));
        }




    
    }
}
