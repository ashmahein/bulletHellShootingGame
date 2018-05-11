using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace BHSTG.States
{
    public class MenuState : State
    {
        Background gameBackground = new Background();
        GameSprite Goku;

        //making a gameMenuOptions object
        GameMenuOptions gamemenuoptions;
        LevelSelector levelSelector;
        bool isInstructionsPressed = false;//keep track if the Instructions button is clicked
        bool isSelectLevelPressed = false;//keep ttrack of if the Select level button is clicked

        private List<Component> components;


        public MenuState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content) : base(_game, _graphicsDevice, _content)
        {
            
            //initialize instruction object
            gamemenuoptions = new GameMenuOptions(graphicsDevice, content);
            //initializing level selector
            levelSelector = new LevelSelector(_graphicsDevice, _content, _game, _game.gameManager_);


            var buttonTexture = content.Load<Texture2D>("Controls/gameButton");
            var buttonFont = content.Load<SpriteFont>("Font/Font");

            //Goku = new GameSprite(content.Load<Texture2D>("Background/Goku_UI"), new Vector2(900, 100), Color.White);

            gameBackground.Init(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, content.Load<Texture2D>("Background/GameBackground"));

            int gap =50 ;
            var instructionButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 550 + gap),
                Text = "Instructions",
            };
            instructionButton.Click += InstructionButton_Clicked;

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 700 + gap),
                Text = "Quit",
            };
            quitButton.Click += QuitButton_Clicked;

            var playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 250 + gap),
                Text = "Play Game",
            };
            playButton.Click += PlayGameButton_Clicked;

            var levelButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 400 + gap),
                Text = "Select Level",
            };
            levelButton.Click += levelButton_Clicked;

            components = new List<Component>()
            {
                instructionButton,
                playButton,
                quitButton,
                levelButton,
            };
        }

        private void PlayGameButton_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("play button");
            game.isPlayGameSelected_ = true;
            //GameState playState = ;
            //this will makesure game will be reset very time we press the play game button in our main menu
            Console.WriteLine("reset game !");
            game.gameManager_.resetGame();
            game.ChangeState(new GameState(game, graphicsDevice, content));
        }
        private void QuitButton_Clicked(object sender, System.EventArgs e)
        {
            game.Exit();
        }
        private void InstructionButton_Clicked(object sender, System.EventArgs e)
        {
            isInstructionsPressed = true;
            //We will go to a different Game state that shows directions for game play. On this page we will also have a return button.
            //throw new System.NotImplementedException();
        }
        private void levelButton_Clicked(object sender, System.EventArgs e)
        {
            isSelectLevelPressed = true;
            //We will go to a different Game state that shows directions for game play. On this page we will also have a return button.
            //throw new System.NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            gameBackground.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(content.Load<Texture2D>("Background/Goku_UI"), new Rectangle(1170, -50, 1378, 1200), new Rectangle(0, 0, 689, 600), Color.White);
            spriteBatch.DrawString(content.Load<SpriteFont>("Font/TitleFont"), "Goku's Adventure", new Vector2(50, 70), Color.White);

            //if instructions button is pressed then draw 
            if (isInstructionsPressed)
                gamemenuoptions.drawInstructions(gameTime, spriteBatch);
            else if (isSelectLevelPressed)
                levelSelector.Draw(gameTime, spriteBatch);
            else
                foreach (var component in components)
                    component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            //if select Level button is pressed then draw
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Nothing happens here yet.
        }

        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Console.WriteLine("Menu State");
            gameBackground.Update(gameTime);

            //if instructions button is pressed then update 
            if (isInstructionsPressed)
                gamemenuoptions.updatesInstructions(gameTime, ref isInstructionsPressed);
            else if (isSelectLevelPressed)//if select Level button is pressed then update
                levelSelector.update(gameTime, spriteBatch, ref isSelectLevelPressed);
            else
                foreach (var component in components)
                    component.Update(gameTime);

        }
    }
}
