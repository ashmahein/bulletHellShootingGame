using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG
{
    public class Shooting
    {
        //this List will keep all the sound Effects 0.player shoot 
        List<SoundEffect> shootingSounds = new List<SoundEffect>();
        List<Bullet> bullets = new List<Bullet>();
        ContentManager content;


        public Shooting(ContentManager content)
        {
            this.content = content;
            //loading firing sound effects to the sound effect list
            shootingSounds.Add(content.Load<SoundEffect>("Music/kiblast"));
            //when creating the object we are adding all the sound effects to the list
            
        }

        public List<Bullet> ShootLikeGrunt1(Vector2 position, Texture2D Texture, Texture2D bulletTexture)
        {
            List<Bullet> bullets = new List<Bullet>();
            Bullet newBullet = new Bullet(bulletTexture);

            newBullet.bulletVelocity.X = 0;
            newBullet.bulletVelocity.Y = 10;
            newBullet.damage = 5;
            newBullet.ActivateBullet();

            newBullet.bulletPosition = new Vector2(position.X, position.Y + (Texture.Height / 2) - (bulletTexture.Height / 2));
            
            if (bullets.Count() < 3)
            {
                bullets.Add(newBullet);
            }
            return bullets;
        }

        public List<Bullet> ShootLikeGrunt2(Vector2 position, Texture2D Texture, Texture2D bulletTexture)
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

            if (bullets.Count() < 3)
            {
                bullets.Add(newBullet);
                bullets.Add(newBullet2);
                bullets.Add(newBullet3);
            }
            return bullets;
        }

        public List<Bullet> ShootLikeMidBoss(Vector2 position, Texture2D Texture, Texture2D bulletTexture)
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

            if (bullets.Count() < 8)
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

        public List<Bullet> ShootLikePlayer(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey)
        {
            List<Bullet> bullets = new List<Bullet>();
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
            {
                shootingSounds[0].Play();
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.bulletVelocity.X = 0;
                newBullet.bulletVelocity.Y = -9;
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
