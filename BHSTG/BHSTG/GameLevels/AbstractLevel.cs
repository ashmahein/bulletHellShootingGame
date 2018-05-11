using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Controls;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BHSTG
{
    public abstract class AbstractLevel
    {
        //this keep track of the background of each level
        protected Texture2D backgroundTexture;
        //this is the spritebatch we want
        protected SpriteBatch spriteBactchCopy;
        //this list keep track of all the enemeies in each level
        protected List<Entity> Enemies = new List<Entity>();
        //keep track of background object
        Background LevelBackground = new Background();

        //constructor
        public AbstractLevel(GraphicsDevice graphicDevice, Texture2D backgroundTexture, SpriteBatch spriteBatch)
        {
            this.spriteBactchCopy = spriteBatch;
            this.backgroundTexture = backgroundTexture;
            LevelBackground.Init(graphicDevice.Viewport.Width, graphicDevice.Viewport.Height, backgroundTexture);

        }

        public abstract void createEnemies(int NumberofGrunts, int NumberofFinalBoss, int NumberofMidboss);
        public abstract void Draw(GameTime gametime, Texture2D backgroundTextures);

    }
}
