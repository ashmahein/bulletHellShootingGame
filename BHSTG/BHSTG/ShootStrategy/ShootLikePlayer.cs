using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace BHSTG.ShootStrategy
{
    class ShootLikePlayer : ShootingStrategy
    {
        List<SoundEffect> shootingSounds = new List<SoundEffect>();
        List<Bullet> bullets = new List<Bullet>();
		private ContentManager content;

		public ShootLikePlayer(ContentManager content)
		{
			this.content = content;
			//loading firing sound effects to the sound effect list
			shootingSounds.Add(content.Load<SoundEffect>("Music/kiblast"));
			//when creating the object we are adding all the sound effects to the list

		}
		public List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey, GameTime gameTime)
        {
            List<Bullet> bullets = new List<Bullet>();
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
            {
				shootingSounds[0].Play();
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.bulletVelocity.X = 0;
                newBullet.bulletVelocity.Y = -10;
                newBullet.ActivateBullet();
                newBullet.damage = 10;
                newBullet.bulletPosition = new Vector2(position.X, position.Y);
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
