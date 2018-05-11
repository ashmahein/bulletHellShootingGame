using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BHSTG.Product
{
    public class Bullet
    {
        private Texture2D bulletTexture;
        //private Vector2 bulletTarget;
        public Vector2 bulletPosition;
        public Vector2 bulletVelocity;
        public bool isActive;
        public int damage;
        Rectangle rec = new Rectangle(200, 300, 20, 20);
        public Rectangle bulletRectangle
        {
            get
            {
                return new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTexture.Width, bulletTexture.Height);
            }
        }

        public Bullet(Texture2D nTexture)
        {
            bulletTexture = nTexture;
            bulletVelocity = new Vector2(0, 0);
            isActive = false;
            
        }

        /*
        public Bullet Shoot(Vector2 fromPosition) 
        {
            Bullet newBullet = new Bullet(bulletTexture);
            newBullet.bulletVelocity.X = 2;
            newBullet.bulletVelocity.Y = 3;
            newBullet.damage = 15;
            newBullet.ActivateBullet();
            newBullet.bulletPosition = new Vector2(fromPosition.X, fromPosition.Y - (bulletTexture.Height / 2));
            return newBullet;
        }
        */

        public void ActivateBullet()
        {
            isActive = true;
        }

        public bool isDead()
        {
            return !isActive;
        }

        public void Update(GameTime gameTime)
         {
            bulletPosition += bulletVelocity;
            if (bulletPosition.X < 0 || bulletPosition.X > 1910 || bulletPosition.Y > 1080 || bulletPosition.Y < 0)
            {
               isActive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, bulletPosition, Color.White);
        }

    }
}