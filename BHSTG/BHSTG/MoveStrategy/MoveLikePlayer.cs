using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.MoveStrategy
{
    class MoveLikePlayer : MovementStrategy
    {
        private bool moveReverseY = false;
        private bool moveReverseX = false;
        private bool catchFirst = false;
        // for the finalBoss Level 1 movements
        private double angle = 0, radius = 100;
        private double savedTimeinSeconds = 0;
        private bool facingRight;
        public bool flip = false;

        public Vector2 Move(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end, int waitTime, float moveH)
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
                sprite.position.X += speedRate;
                facingRight = true;
				flip = false;
            }
            return sprite.position;
        }

        public bool getFlip()
        {
            return flip;
        }

    }
}
