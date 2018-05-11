using BHSTG.Product;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BHSTG.ShootStrategy
{
    class ShootLikeFinal : ShootingStrategy
    {
        List<SoundEffect> shootingSounds = new List<SoundEffect>();
        List<Bullet> bullets = new List<Bullet>();

        public List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey, GameTime gameTime)
        {
            List<Bullet> bullets = new List<Bullet>();
            Bullet newBullet = new Bullet(bulletTexture);
            Bullet newBullet2 = new Bullet(bulletTexture);
            Bullet newBullet3 = new Bullet(bulletTexture);
            Bullet newBullet4 = new Bullet(bulletTexture);
            Bullet newBullet5 = new Bullet(bulletTexture);
            Bullet newBullet6 = new Bullet(bulletTexture);
            Bullet newBullet7 = new Bullet(bulletTexture);
            Bullet newBullet8 = new Bullet(bulletTexture);

            newBullet.bulletVelocity.X = 0;
            newBullet.bulletVelocity.Y = -3;
            newBullet.damage = 10;

            newBullet2.bulletVelocity.X = 0;
            newBullet2.bulletVelocity.Y = 3;
            newBullet2.damage = 10;

            newBullet3.bulletVelocity.X = 3;
            newBullet3.bulletVelocity.Y = 0;
            newBullet3.damage = 10;

            newBullet4.bulletVelocity.X = -3;
            newBullet4.bulletVelocity.Y = 0;
            newBullet4.damage = 10;

            newBullet5.bulletVelocity.X = (float)1.5;
            newBullet5.bulletVelocity.Y = (float)2.75;
            newBullet5.damage = 10;

            newBullet6.bulletVelocity.X = (float)-1.5;
            newBullet6.bulletVelocity.Y = (float)2.75;
            newBullet6.damage = 10;

            newBullet7.bulletVelocity.X = (float)1.5;
            newBullet7.bulletVelocity.Y = (float)-2.75;
            newBullet7.damage = 10;

            newBullet8.bulletVelocity.X = (float)-1.5;
            newBullet8.bulletVelocity.Y = (float)-2.75;
            newBullet8.damage = 10;

            newBullet.ActivateBullet();
            newBullet2.ActivateBullet();
            newBullet3.ActivateBullet();
            newBullet4.ActivateBullet();
            newBullet5.ActivateBullet();
            newBullet6.ActivateBullet();
            newBullet7.ActivateBullet();
            newBullet8.ActivateBullet();

            newBullet.bulletPosition = newBullet2.bulletPosition = newBullet3.bulletPosition = newBullet4.bulletPosition = newBullet5.bulletPosition = newBullet6.bulletPosition = newBullet7.bulletPosition = newBullet8.bulletPosition = new Vector2(position.X + (Texture.Width / 2) - (bulletTexture.Width / 2), position.Y + (Texture.Height / 2) - (bulletTexture.Height / 2));

            int shoot = gameTime.TotalGameTime.Milliseconds;
            if (shoot == 500 && bullets.Count() < 8)
            {
                bullets.Add(newBullet);
                bullets.Add(newBullet2);
                bullets.Add(newBullet3);
                bullets.Add(newBullet4);
                bullets.Add(newBullet5);
                bullets.Add(newBullet6);
                bullets.Add(newBullet7);
                bullets.Add(newBullet8);
            }
            return bullets;
        }

        // Updates bullet and their new direction
        public void updateBullets(GameTime gameTime)
        {
            for (int i = 0; i < bullets.Count(); i++)
            {
                Bullet bullet = bullets.ElementAt(i);
                bullet.Update(gameTime);
            }

            for (int i = 0; i < bullets.Count(); i++)
            {
                if (!bullets[i].isActive)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
