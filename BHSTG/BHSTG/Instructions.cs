using BHSTG.Controls;
using BHSTG.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG
{

    public class Instructions
    {
        Background gameBackground = new Background();
        GraphicsDevice graphicsDevice;
        ContentManager content;

        public Instructions(GraphicsDevice _graphicsDevice, ContentManager _content)
        {
            graphicsDevice = _graphicsDevice;
            content = _content;
            //setting up the variables for the Instructions side
            gameBackground.Init(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, content.Load<Texture2D>("Background/LastLevel"));
        }


        public void drawInstructions(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            gameBackground.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(content.Load<Texture2D>("Background/controls_layout"), new Vector2(0, 0), Color.White);
            Console.WriteLine("drawing ins");

           // spriteBatch.End();

        }

        public void updatesInstructions(GameTime gameTime)
        {
            gameBackground.Update(gameTime);
            //spriteBatch.Draw(content.Load<Texture2D>("Background/controls_layout"), new Vector2(0, 0), Color.White);
        }


    }


    
}
