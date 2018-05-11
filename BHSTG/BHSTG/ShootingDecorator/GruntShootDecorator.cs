using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BHSTG.Product;

namespace BHSTG.ShootingDecorator
{
    public class GruntShootDecorator : ShootDecorator
    {
        Entity mEntity;

        public GruntShootDecorator(Entity e) : base(e)
        {
            mEntity = e;   
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            mEntity.Draw(gameTime, spriteBatch);
        }

        public override void Move(GameTime gameTime)
        {
            mEntity.Move(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            mEntity.Update(gameTime);
        }

        public override List<Bullet> Shoot()
        {
            
            return Shoot( mEntity._position, mEntity._texture, mEntity._bulletTexture);
        }

        public List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture)
        {
            List<Bullet> bullets = new List<Bullet>();
            Bullet newBullet = new Bullet(bulletTexture);

            newBullet.bulletVelocity.X = 0;
            newBullet.bulletVelocity.Y = 3;
            newBullet.damage = 5;
            newBullet.ActivateBullet();

            newBullet.bulletPosition = new Vector2(position.X, position.Y + (Texture.Height / 2) - (bulletTexture.Height / 2));

            if (bullets.Count() < 3)
            {
                bullets.Add(newBullet);
            }
            return bullets;
        }
    }
}
