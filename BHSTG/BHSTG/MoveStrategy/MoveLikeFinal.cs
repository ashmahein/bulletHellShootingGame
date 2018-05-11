using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BHSTG.MoveStrategy
{
    class MoveLikeFinal : MovementStrategy
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

            return sprite.position;
        }

        public bool getFlip()
        {
            return flip;
        }
    }
}
