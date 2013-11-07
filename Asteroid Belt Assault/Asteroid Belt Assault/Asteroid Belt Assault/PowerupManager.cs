//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerupManager
    {
        public List<Sprite> PowerUps = new List<Sprite>();
        static private float timeSinceLastPowerup = 0.0f;
        static private float timeBetweenPowerups = 5.0f;
        static private float powerupTime = 0.0f;
        static private float powerupDuration = 10.0f;
        static private Random rand = new Random();
        private PlayerManager playerManager;
        Texture2D WeaponSheet;

        private bool destroyed;
        public bool Destroyed = false;

        public PowerupManager(Texture2D weaponSheet, PlayerManager playerManager)
        {
            this.WeaponSheet = weaponSheet;
            this.playerManager = playerManager;
        }

        //private Powerup shotgun = new Powerup();
        //private Powerup superSpin = new Powerup();
        //private Powerup uzi = new Powerup();
        //private Powerup nuke = new Powerup();
        //private Powerup invincible = new Powerup();

        

        public void SpawnPowerUp(Vector2 location, PowerupType poweruptype)
        {
            Sprite newPowerup = new Sprite(
            location,
            WeaponSheet,
            new Rectangle(172, 0, 55, 40),
            Vector2.Zero);

            newPowerup.CollisionRadius = 14;
            
            newPowerup.Frame = 1;
            PowerUps.Add(newPowerup);
            timeSinceLastPowerup = 0.0f;
        }

        public void MaybeSpawnPowerups(Vector2 location)
        {
            PowerupType poweruptype;
            if (rand.Next(0, 3) == 1)
            {
                if (rand.Next(1, 5) == 1)
                {
                    poweruptype = PowerupType.UZI;
                }

                else if (rand.Next(1, 5) == 2)
                {
                    poweruptype = PowerupType.SHOTGUN;
                }

                else if (rand.Next(1, 5) == 3)
                {
                    poweruptype = PowerupType.INVINCIVLE;
                }

                else if (rand.Next(1, 5) == 4)
                {
                    poweruptype = PowerupType.NUKE;
                }

                else
                {
                    poweruptype = PowerupType.SUPERSPIN;
                }
                SpawnPowerUp(location, poweruptype);
            }
        }

        public void GetEffects()
        {
            playerManager.minShotTimer = 0.1f;
            powerupTime = 0f;
        }

        public void Clear()
        {
            PowerUps.Clear();
        }


        public void Update(GameTime gameTime)
        {
            timeSinceLastPowerup += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceLastPowerup >= timeBetweenPowerups)
            {
                Clear();
            }

            powerupTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (powerupTime >= powerupDuration)
            {
                playerManager.minShotTimer = 0.2f;
            }


            
            

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
