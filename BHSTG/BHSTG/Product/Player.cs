using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using BHSTG.MoveStrategy;
using BHSTG.ShootStrategy;

namespace BHSTG.Product
{
    public class Player : Entity
    {
		//Going to do animations setup in player class
		float elapsedTime; // tracks current time
		float delay = 100f; // 200 Miliseconds = 0.2 secs
		int frames = 0; // iterator that flips through frames
		int yframes = 0;
		Microsoft.Xna.Framework.Rectangle destrec;
		Microsoft.Xna.Framework.Rectangle sourcerec;
        KeyboardState currentKey;
        KeyboardState previousKey;
        List<Bullet> bullets = new List<Bullet>();
        Texture2D bulletTexture;
        internal bool inDanger;
        internal bool powerUpActivated;
        public Player(Vector2 startPos, Vector2 endPos, int pHealth, bool speedMode, GameSprite sprite, Texture2D bulletTexture, ContentManager content, MovementStrategy movement, ShootingStrategy shooting) : base(startPos, pHealth, speedMode, sprite, content, movement, shooting)
        {
            powerUpActivated = false;
            if (speed) {
                speedRate = 5;
            } else {
                speedRate = 10;
            }

            health = pHealth;
            this.bulletTexture = bulletTexture;
            this.characterMovements = movement;
            this.characterShooting = shooting;
            inDanger = false;
        }


        public override void Move(GameTime gameTime)
        {
            Vector2 end = new Vector2(1500, 200);
            position = characterMovements.Move(ref gameTime, ref sprite, ref speedRate, ref position, ref end, 0,0);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //sprite.Draw(spriteBatch);
			
			spriteBatch.Draw(sprite.texture, destrec,sourcerec, Microsoft.Xna.Framework.Color.White);
            characterShooting.Draw(spriteBatch);
        }

        public override List<Bullet> Shoot(GameTime gameTime)
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();
            return characterShooting.Shoot(position, Texture, bulletTexture, previousKey, gameTime);
        }
        
       
        public void Update(GameTime gameTime, List<Entity> enemies)
        {
			
            Move(gameTime);
			destrec = new Microsoft.Xna.Framework.Rectangle((int)sprite.position.X, (int)sprite.position.Y, 70, 40); 
			Animate(gameTime);
            position = sprite.position;
            if (health <50 && powerUpActivated == false)
            {
                powerUpActivated = true;
                inDanger = true;
            }
			//Shoot();
			//characterShooting.updateBullets(gameTime);
		}

		private void Animate(GameTime gameTime)
		{
			elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (elapsedTime >= delay)
			{
				if (frames >= 1)
				{
					frames = 0;
				}
				else
				{
					frames++;
				}

				if (characterMovements.getFlip() == false) 
				{
					yframes = 0; //first row of  sprite sheet
				}
				else if( characterMovements.getFlip() == true)
				{

					yframes = 1; //second row of sprite sheet
				}

				elapsedTime = 0;

			}

			
			sourcerec = new Microsoft.Xna.Framework.Rectangle(46 * frames, 24*yframes, 46, 24);
		}

		public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }

}
