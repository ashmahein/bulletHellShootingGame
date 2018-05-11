using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.ShootStrategy
{
    public class ShootLikeMid : ShootingStrategy
    {
        List<SoundEffect> shootingSounds = new List<SoundEffect>();
        List<Bullet> bullets = new List<Bullet>();

        public List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey, GameTime gameTime)
        {
            List<Bullet> bullets = new List<Bullet>();
            Bullet newBullet = new Bullet(bulletTexture);
            Bullet newBullet2 = new Bullet(bulletTexture);
            Bullet newBullet3 = new Bullet(bulletTexture);

            newBullet.bulletVelocity.X = 3;
            newBullet.bulletVelocity.Y = 3;
            newBullet.damage = 20;

            newBullet2.bulletVelocity.X = 0;
            newBullet2.bulletVelocity.Y = 3;
            newBullet2.damage = 20;

            newBullet3.bulletVelocity.X = -3;
            newBullet3.bulletVelocity.Y = 3;
            newBullet3.damage = 20;

            newBullet.ActivateBullet();
            newBullet2.ActivateBullet();
            newBullet3.ActivateBullet();

            newBullet.bulletPosition = newBullet2.bulletPosition = newBullet3.bulletPosition = new Vector2(position.X, position.Y + (Texture.Height / 2) - (bulletTexture.Height / 2));

            int shoot = gameTime.TotalGameTime.Milliseconds;
            if (shoot == 500 && bullets.Count() < 9)
            {
                bullets.Add(newBullet);
                bullets.Add(newBullet2);
                bullets.Add(newBullet3);
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
