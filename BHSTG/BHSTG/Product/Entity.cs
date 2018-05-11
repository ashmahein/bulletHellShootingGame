using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG;
using BHSTG.MoveStrategy;
using BHSTG.ShootStrategy;

namespace BHSTG.Product
{
    public abstract class Entity
    {
        #region Data Fields
        //used to get the postion of the sprite.
        protected Vector2 position;
        //Health for the sprite.
        protected int health;
        //Boolean variable to set the speed of the sprite to fast or slow. Fast = true, slow = false
        public bool speed;
        public bool isAlive;
        //speed inwich the character moves (usually default movement is multiplied by this value)
        protected int speedRate = 3;

        protected MovementStrategy characterMovements;
        protected ShootingStrategy characterShooting;
        protected Texture2D Texture;
        protected GameSprite sprite;
        protected ContentManager content; //this will help us to load stuff like music and images

        public bool isDead()
        {
            return !isAlive;
        }
        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X , (int)position.Y, Texture.Width, Texture.Height);
            }
        }

        public Vector2 _position{
            set { _position = value; }
            get { return _position; }
        }

        public int _health
        {
            set { health = value; }
            get { return health; }
        }
        #endregion

        #region Methods

        public abstract void Move(GameTime gameTime); //Kalana
        public abstract List<Bullet> Shoot(GameTime gameTime); //Ash
        //public abstract void Update(Vector2 bulletHitBox, Vector2 entityHitbox); //Deliverable 2
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch); //Both
        public abstract void Update(GameTime gameTime);

        public Entity(Vector2 position, int health, bool speed, GameSprite sprite, ContentManager content, MovementStrategy movement, ShootingStrategy shooting)
        {
            this.position = position;
            this.health = health;
            this.speed = speed;
            this.Texture = sprite.texture;
            this.sprite = sprite;
            this.content = content;
            //creating a new instance of the movements class so all the character classes inherits from this doesn't have a create a new instance every time
            characterMovements = movement;
            characterShooting = shooting;
            isAlive = true;
        }

        ~Entity()
        {

        }
        #endregion


    }
}
