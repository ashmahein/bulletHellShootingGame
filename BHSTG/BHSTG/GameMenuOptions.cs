using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BHSTG.Controls;

//this class contains all the UI elements for Instructions and Select level
namespace BHSTG
{
    class GameMenuOptions
    {
        Background gameBackground = new Background();
        GraphicsDevice graphicsDevice;
        ContentManager content;

        //constructor
        public GameMenuOptions(GraphicsDevice _graphicsDevice, ContentManager _content)
        {
            graphicsDevice = _graphicsDevice;
            content = _content;
            //setting up the variables for the Instructions side
            gameBackground.Init(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, content.Load<Texture2D>("Background/LastLevel"));

        }


        public void drawInstructions(GameTime gameTime, SpriteBatch spriteBatch)
        {

            gameBackground.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(content.Load<Texture2D>("Background/controls_layout"), new Vector2(0, 0), Color.White);


        }

        public void updatesInstructions(GameTime gameTime, ref bool isInstructionsPressed)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                isInstructionsPressed = false;
            }
                

            gameBackground.Update(gameTime);

        }

    }
}
