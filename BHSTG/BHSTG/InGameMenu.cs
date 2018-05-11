using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Controls;
using Microsoft.Xna.Framework.Media;

namespace BHSTG
{
    class InGameMenu
    {
        private GraphicsDevice graphics = null; // this will keep a copy of Graphic device stuff
        ContentManager content;
        Rectangle rec;
        Texture2D gameMenu;
        GameManager gameMangerRef; //keeps a reference to our aleardy created gameManager
        Game1 game1Ref;
        GameMenuOptions instructions;
        private Song menuSong;

        private List<Component> components;//saves all the buttons
        private bool drawIns = false;

        public InGameMenu(GraphicsDevice graphics, ContentManager content, Game1 game1Ref, GameManager gameMangerRef)
        {
            this.graphics = graphics;
            this.content = content;
            this.game1Ref = game1Ref;
            this.gameMangerRef = gameMangerRef;

 
            //initializing instructions object
            instructions = new GameMenuOptions(graphics, content);


            gameMenu = content.Load<Texture2D>("Background/ingameMenu");


            //creating the buttons
            rec = new Rectangle(graphics.Viewport.Width / 5, graphics.Viewport.Height/ 100,1080,965);
            var buttonTexture = content.Load<Texture2D>("Controls/gameButton");
            var buttonFont = content.Load<SpriteFont>("Font/Font");
            int gap = 130;
            int horizontalpading = 310;
            
            var Resume = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 5 + horizontalpading, 300 + gap),
                Text = "Resume",
            };
            Resume.Click += ResumeButton_Clicked;

            var Controls = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 5 + horizontalpading, 450 + gap),
                Text = "Controls",
            };
            Controls.Click += ControlsButton_Clicked;

            var Quit = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 5 + horizontalpading, 600 + gap),
                Text = "Quit",
            };
            Quit.Click += QuitButton_Clicked;

            components = new List<Component>()
            {
                Resume,
                Controls,
                Quit,
            };

        }

        private void ResumeButton_Clicked(object sender, System.EventArgs e)
        {
            game1Ref.isPlayGameSelected_ = true;
            game1Ref.PopInGameMenu_ = false;
            gameMangerRef.resumeGame();
        }

        private void ControlsButton_Clicked(object sender, System.EventArgs e)
        {
            drawIns = true;
        }

        private void QuitButton_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("quit");
            gameMangerRef.resetGame();
            game1Ref.PopInGameMenu_ = false;
            game1Ref.QuitToMain_ = true;
            //and reset everything in the game so we can start fresh when press start in main menu
            
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (!drawIns)
            {
                
                spriteBatch.Draw(gameMenu, rec, Color.White);


                foreach (var component in components)
                {

                    component.Draw(gameTime, spriteBatch);
                    component.Update(gameTime);

                }

                
            }else
            {
                Console.WriteLine("Drawing INs");
                instructions.drawInstructions(gameTime, spriteBatch);
                instructions.updatesInstructions(gameTime, ref drawIns);
            }

            spriteBatch.End();

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


               // Console.WriteLine("in if");
                spriteBatch.Draw(gameMenu, rec, Color.White);
                foreach (var component in components)
                {
                    component.Draw(gameTime, spriteBatch);


                }

            if (drawIns)
            {
                instructions.drawInstructions(gameTime, spriteBatch);
                instructions.updatesInstructions(gameTime, ref drawIns);
            }

        }
    }
}
