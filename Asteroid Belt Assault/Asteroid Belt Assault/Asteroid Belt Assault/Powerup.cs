//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class Powerup
    {
        static public List<Sprite> PowerUps = new List<Sprite>();
        static private float timeSinceLastPowerup = 0.0f;
        static private float timeBetweenPowerups = 2.0f;
        static private Random rand = new Random();
        Texture2D WeaponSheet;

        public Powerup(Texture2D weaponSheet)
        {
            this.WeaponSheet = weaponSheet;
        }

        //private Powerup shotgun = new Powerup();
        //private Powerup superSpin = new Powerup();
        //private Powerup uzi = new Powerup();
        //private Powerup nuke = new Powerup();
        //private Powerup invincible = new Powerup();

        public void SpawnPowerUp(int x, int y)
        {
            Rectangle Destination = new Rectangle(x, y, 100, 100);

            Sprite newPowerup = new Sprite(
            new Vector2(Destination.X, Destination.Y),
            WeaponSheet,
            new Rectangle(64, 128, 32, 32),
            Vector2.Zero);

            newPowerup.CollisionRadius = 14;
            newPowerup.AddFrame(new Rectangle(172, 0, 55, 40));

            newPowerup.Frame = 1;
            PowerUps.Add(newPowerup);
            timeSinceLastPowerup = 0.0f;
        }
        
            
    

        private void checkPowerupSpawns(float elapsed)
        {
            timeSinceLastPowerup += elapsed;
            //if (timeSinceLastPowerup >= timeBetweenPowerups)
           // {
                timeSinceLastPowerup = 0;
                SpawnPowerUp(
                    rand.Next(0, 800),
                    rand.Next(0, 600));
           // }
        }

        public void Update(GameTime gameTime)
        {
            checkPowerupSpawns(gameTime.ElapsedGameTime.Seconds);

            foreach (Sprite sprite in PowerUps)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in PowerUps)
            {
                sprite.Draw(spriteBatch);
            }
        }
    
    }
}
