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
    class ShootLikeGrunt : ShootingStrategy
    {
        List<SoundEffect> shootingSounds = new List<SoundEffect>();
        List<Bullet> bullets = new List<Bullet>();

        public List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey, GameTime gameTime)
        {
            List<Bullet> bullets = new List<Bullet>();
            Bullet newBullet = new Bullet(bulletTexture);

            newBullet.bulletVelocity.X = 0;
            newBullet.bulletVelocity.Y = 6;
            newBullet.damage = 5;
            newBullet.ActivateBullet();

            newBullet.bulletPosition = new Vector2(position.X, position.Y + (Texture.Height / 2) - (bulletTexture.Height / 2));

            int shoot = gameTime.TotalGameTime.Milliseconds;
            if (shoot == 500 && bullets.Count() < 3)
            {
                bullets.Add(newBullet);
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
