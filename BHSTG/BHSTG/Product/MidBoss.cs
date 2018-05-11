using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BHSTG.MoveStrategy;
using BHSTG.ShootStrategy;
using Microsoft.Xna.Framework.Input;

namespace BHSTG.Product
{
    public class MidBoss : Boss
    {
        public double angle = 0, radius = 100;
        public int count = 0, baseX = 200;
        Random r = new Random();
        Texture2D bulletTexture;
        KeyboardState previousKey;

        public MidBoss(Vector2 position, Vector2 end, int mHealth, bool speed, GameSprite sprite, Texture2D newBulletTexture, ContentManager content, MovementStrategy movement, ShootingStrategy shooting) : base(position, end, mHealth, speed, sprite,content, movement, shooting)
        {
            position = new Vector2(0, 0);
            health = mHealth;
            speed = false;
            start.X = sprite.position.X; //setting up enemy start point
            start.Y = sprite.position.Y; //setting up enemy start point
            this.end.X = end.X; //setting up enemy start point
            this.end.Y = end.Y; //setting up enemy start point
            bulletTexture = newBulletTexture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public override void Move(GameTime gameTime)
        {
            //setting up speed rate of the midboss
            speedRate = 5;
            position = characterMovements.Move(ref gameTime, ref sprite, ref speedRate, ref start, ref end, 0, 0);
        }

        public override List<Bullet> Shoot(GameTime gameTime)
        {
            previousKey = Keyboard.GetState();
            return characterShooting.Shoot(position, Texture, bulletTexture, previousKey, gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            Move(gameTime);
            speedRate = 5;
            //position = characterMovements.MidBossLv1(ref gameTime, ref sprite, ref speedRate, ref start, ref end);
        }
    }
}
