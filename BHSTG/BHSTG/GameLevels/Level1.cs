using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BHSTG.Product;

namespace BHSTG
{
    public class Level1 : AbstractLevel
    {
        public Level1(GraphicsDevice graphicDevice,Texture2D backgroundTexture, SpriteBatch spriteBatch) : base(graphicDevice, backgroundTexture, spriteBatch)
        {

        }

        public override void createEnemies(int NumberofGrunts, int NumberofFinalBoss, int NumberofMidboss)
        {
            //this will creates the grunts and adds to the List
            for(int currentGrunts=0;currentGrunts<NumberofGrunts;currentGrunts++)
            {
                //Enemies.Add(new Enemy()
            }
        }

        public override void Draw(GameTime gametime, Texture2D backgroundTextures)
        {

        }
    }
}
