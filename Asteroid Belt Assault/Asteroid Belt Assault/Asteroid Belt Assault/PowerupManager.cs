using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_Belt_Assault
{
    class PowerupManager
    {
        private Random rand = new Random();
        private int powerupChance;
        private bool powerup;



        public void ChoosePowerup()
        {
            powerupChance = rand.Next(0, 100);
            if (powerupChance > 5)
            {
                powerup = true;
                {


                }
            }
        }
    }
}
