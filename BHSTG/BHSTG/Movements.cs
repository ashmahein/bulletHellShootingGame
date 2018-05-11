using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//this class basically encapsulate different types of movement methods that we can use with any concrete entity class 
namespace BHSTG
{

    public class Movements
    {
        private bool moveReverseY = false;
        private bool moveReverseX = false;
        private bool catchFirst = false;
        // for the finalBoss Level 1 movements
        private double angle = 0, radius = 100;
        private double savedTimeinSeconds = 0;
		private bool facingRight;


		public bool flip = false; // used to indicate when player needs to flip left


        //resets every property !
        public void resetProperties()
        {
            moveReverseY = false;
            moveReverseX = false;
        }

        // passing all the parameters by reference so it all ways refers to the variables in calling class and saves up some memory too ;)
        // this function will move the sprite along with user controlls, defaultly used with the player
        public Vector2 PlayerMovement(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate)
        {
            //Vector2 pos = new Vector2(sprite.position.X, sprite.position.Y);
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) //DOWN
            {
                sprite.position.Y += speedRate;   
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) //UP
            {
                sprite.position.Y -= speedRate;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)) //Left
            {
                sprite.position.X -= speedRate;

                facingRight = false;
				flip = true;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)) //Right
            {
				flip = false;
                sprite.position.X += speedRate;
				facingRight = true;
            }
            return sprite.position;	
        }

        //this is our basic enemy movement which moves the enemy in circles (Level 1)
        public void basicEnemyMovement(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end)
        {
            if (sprite.position.Y < end.Y && moveReverseY == false)
            {
                sprite.position.Y += speedRate;
                if (sprite.position.Y == end.Y)
                    moveReverseY = true;
            }
            else if (sprite.position.X < end.X && moveReverseX == false)
            {
                sprite.position.X += speedRate;
                if (sprite.position.X == end.X)
                {
                    moveReverseX = true;
                }
            }
            else if (sprite.position.Y > start.Y && moveReverseY)
            {
                sprite.position.Y -= speedRate;
            }
            else if (sprite.position.X > start.X && moveReverseX)
            {
                sprite.position.X -= speedRate;

                if (sprite.position.Y == start.Y && sprite.position.X == start.X) //reset variables
                {
                    //System.Threading.Thread.Sleep(1000);
                    moveReverseY = false;
                    moveReverseX = false;
                }
            }
        }


        //this method manipulate how Midboss moves  (Level 2)
        public Vector2 MidBossLv1(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end)
        {
            if (sprite.position.X == end.X && !moveReverseX)
            {
                sprite.position.X -= speedRate;
                moveReverseX = true;

            }
            else if (sprite.position.X == 0 && moveReverseX)
            {
                sprite.position.X += speedRate;
                moveReverseX = false;
            }
            else
            {
                if (moveReverseX)
                {
                    sprite.position.X -= speedRate;
                }
                else
                {
                    sprite.position.X += speedRate;
                }
            }
            return sprite.position;
        }


        //this method manipulate how FinalBoss moves  (Level 4)
        public void FinalBossLv1(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end)
        {
            if (sprite.position.X == end.X && !moveReverseX)
            {
                sprite.position.X -= speedRate;
                moveReverseX = true;
            }
            else if (sprite.position.X == 0 && moveReverseX)
            {
                sprite.position.X += speedRate;
                moveReverseX = false;
            }
            else
            {
                if (moveReverseX)
                {
                    sprite.position.X -= speedRate;
                }
                else
                {
                    sprite.position.X += speedRate;
                }
            }

            sprite.position.Y = (int)(200 + Math.Sin(angle) * radius);

            angle += .05;
        }

        //this function will manipultate characters comes down to a certain position of the screen and goes back up
        public void Movement1(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end, int waitTime)
        {
            if (sprite.position.Y < end.Y && moveReverseY == false)
            {
                sprite.position.Y += speedRate;
                if (sprite.position.Y >= end.Y)
                    moveReverseY = true;
            }
            else if (sprite.position.Y > start.Y && moveReverseY)
            {
                
                if(!catchFirst) 
                {
                    Console.WriteLine("Game Time = " + gameTime.TotalGameTime.TotalSeconds);
                    savedTimeinSeconds = gameTime.TotalGameTime.TotalSeconds;
                    catchFirst = true;

                }
                // using this condition I,m going to make the chracters wait for a given time
                if(gameTime.TotalGameTime.TotalSeconds - savedTimeinSeconds >= waitTime)
                    sprite.position.Y -= speedRate;
            }
        }

        public void Movement4(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end)
        {
			
			if (moveReverseY == false && sprite.position.Y < end.Y )
            {
				
				sprite.position.Y += speedRate;
                sprite.position.X -= speedRate;
				
                if (sprite.position.Y >= end.Y)
                {
                    moveReverseY = true;
                }
                    
            }else if(moveReverseX == false &&  sprite.position.X < end.X  )
            {
                
                sprite.position.X += speedRate;
                if (sprite.position.X >= end.X)
                {
                    moveReverseX = true;
                }
                    
            }
            else if (moveReverseY && moveReverseX)
            {
                sprite.position.Y -= speedRate;
                sprite.position.X -= speedRate;
                if (sprite.position.Y == start.Y)
                {
                    moveReverseY = moveReverseX = false;
                }
                    

            }
        }

		public void circlePattern(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end, float moveH)
		{
			end.X += moveH;

			
			if (moveReverseY == false && sprite.position.Y < end.Y)
			{

				sprite.position.Y += speedRate;
				sprite.position.X -= speedRate;

				if (sprite.position.Y >= end.Y)
				{
					moveReverseY = true;
				}

			}
			else if (moveReverseX == false && sprite.position.X < end.X)
			{

				sprite.position.X += speedRate;
				if (sprite.position.X >= end.X)
				{
					moveReverseX = true;
				}

			}
			else if (moveReverseY && moveReverseX)
			{
				sprite.position.Y -= speedRate;
				sprite.position.X -= speedRate;
				if (sprite.position.Y == start.Y)
				{
					moveReverseY = moveReverseX = false;
				}


			}
			
		}



	}



	}

