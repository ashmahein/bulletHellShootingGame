using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHSTG.Controls;
using BHSTG.States;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BHSTG
{
    public class GameSprite
    {
        public Vector2 position;
        float x;
        float y;
        public Texture2D texture;
        private Color color;

        public GameSprite(Texture2D texture, Vector2 position, Color color)
        {
            this.position = position;
            this.texture = texture;
            this.color = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
