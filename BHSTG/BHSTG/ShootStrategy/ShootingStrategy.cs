using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.ShootStrategy
{
    public interface ShootingStrategy
    {

        List<Bullet> Shoot(Vector2 position, Texture2D Texture, Texture2D bulletTexture, KeyboardState previousKey, GameTime gameTime);
        void updateBullets(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
