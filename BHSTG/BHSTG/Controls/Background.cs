using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BHSTG.Controls
{
    class Background : Component
    {
        #region Properties

        private float bgWidth;
        private float bgHeight;
        private Texture2D bTexture;
        private Vector2[] bPosition;

        #endregion

        #region Methods
        public Background()
        {

        }

        public void changeTexture(Texture2D _texture)
        {
            bTexture = _texture;
        }

        public void Init(float screenWidth, float screenHeight, Texture2D _texture)
        {
            bTexture = _texture;
            bgHeight = screenHeight;
            bgWidth = bTexture.Width * (screenHeight / bTexture.Height);
            bPosition = new Vector2[(int)screenWidth / (int)bgWidth + 2];

            for (int index = 0; index < bPosition.Length; index++)
            {
                bPosition[index] = new Vector2(index * bgWidth, 0);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int index = 0; index < bPosition.Length; index++)
            {
                Rectangle rectangle = new Rectangle((int)bPosition[index].X, (int) bPosition[index].Y, (int)bgWidth, (int)bgHeight);
                spriteBatch.Draw(bTexture, rectangle, Color.Azure);
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int index = 0; index < bPosition.Length; index++)
            {
                if(bPosition[index].X <= -bgWidth)
                {
                    bPosition[index].X = (bPosition.Length - 1) * bgWidth;
                }
            }
        }

        #endregion
    }

}
