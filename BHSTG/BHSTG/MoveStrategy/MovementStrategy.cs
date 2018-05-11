using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.MoveStrategy
{
    public interface MovementStrategy
    {
        Vector2 Move(ref GameTime gameTime, ref GameSprite sprite, ref int speedRate, ref Vector2 start, ref Vector2 end, int waitTime, float moveH);
        bool getFlip();
    }
}
