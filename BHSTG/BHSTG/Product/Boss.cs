using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BHSTG;
using Microsoft.Xna.Framework.Content;
using BHSTG.MoveStrategy;
using BHSTG.ShootStrategy;

namespace BHSTG.Product
{
    public class Boss : Entity
    {
        protected bool moveReverseX = false, moveReverseY = false;
        protected Vector2 start, end;


        public Boss(Vector2 position,Vector2 end, int health, bool speed, GameSprite sprite, ContentManager content, MovementStrategy movement, ShootingStrategy shooting) : base(position, health, speed, sprite,content, movement, shooting)
        {
            position = new Vector2(0, 0);
            health = 25;
            speed = false;
            start.X = sprite.position.X; //setting up enemy start point
            start.Y = sprite.position.Y; //setting up enemy start point
            this.end.X = end.X; //setting up enemy start point
            this.end.Y = end.Y; //setting up enemy start point
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Move(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override List<Bullet> Shoot(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
