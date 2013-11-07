using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    enum PowerupType
    {
        SHOTGUN,
        SUPERSPIN,
        UZI,
        NUKE,
        INVINCIVLE,
        STARTER
    }

    class Powerup : Sprite
    {
        public PowerupType powerupType;

        public Powerup(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity
            ) : base (location, texture, initialFrame, velocity)
        {

            powerupType = PowerupType.UZI;
          
        }

        public override void Update(GameTime gameTime)
        {
            switch (powerupType)
            {
                case PowerupType.UZI:

                    this.frames[0] = new Rectangle(172, 0, 55, 40);

                    break;

                case PowerupType.SHOTGUN:

                    this.frames[0] = new Rectangle(107, 118, 108, 21);

                    break;

                case PowerupType.INVINCIVLE:

                    this.frames[0] = new Rectangle(172, 0, 55, 40);

                    break;

                case PowerupType.NUKE:

                    this.frames[0] = new Rectangle(172, 0, 55, 40);

                    break;

                case PowerupType.SUPERSPIN:

                    this.frames[0] = new Rectangle(172, 0, 55, 40);

                    break;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
