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

        private Powerup shotgun = new Powerup();
        private Powerup superSpin = new Powerup();
        private Powerup uzi = new Powerup();
        private Powerup nuke = new Powerup();
        private Powerup invincible = new Powerup();


        public static void SpawnPowerUp(int x, int y)
        {
            Rectangle Destination = new Rectangle(x, y, 100, 100);
            if (true)
            {
                Sprite newPowerup = new Sprite(
                new Vector2(Destination.X, Destination.Y),
               
                new Rectangle(64, 128, 32, 32),
                Vector2.Zero);
                
                newPowerup.CollisionRadius = 14;
                newPowerup.AddFrame(new Rectangle(172, 0, 55, 40));
                
                newPowerup.Frame = 1;
                PowerUps.Add(newPowerup);
                timeSinceLastPowerup = 0.0f;
            }
        }

        private static void checkPowerupSpawns(float elapsed)
        {
            timeSinceLastPowerup += elapsed;
            if (timeSinceLastPowerup >= timeBetweenPowerups)
            {
                timeSinceLastPowerup = 0;
                SpawnPowerUp(
                    rand.Next(0, 600),
                    rand.Next(0, 300));
            }
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





















        //public Powerup shotgun
        //{
        //    get
        //    {

        //    }
        //    set
        //    {
        //         private void HandleKeyboardInput(KeyboardState keyState)
        //{
        //        if (keyState.IsKeyDown(Keys.Space))
        //        {
        //            FireShot(playerSprite.Center + vel * 10,
        //            vel + 10,
        //            true);
        //            FireShot(playerSprite.Center + vel * 10,
        //            vel + 5,
        //            true);
        //            FireShot(playerSprite.Center + vel * 10,
        //            vel - 5,
        //            true);
        //            FireShot(playerSprite.Center + vel * 10,
        //            vel - 10,
        //            true);
        //        }
        //    }
    }
}
