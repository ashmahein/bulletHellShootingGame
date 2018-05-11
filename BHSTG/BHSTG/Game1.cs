using BHSTG.Controls;
using BHSTG.States;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

using System.Timers; //for the timer
using BHSTG.Factory;
using System;

namespace BHSTG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {


        private bool isPlayGameSelected = false;
        private bool PopInGameMenu = false;
        private bool QuitToMain = false;
        

        public bool isPlayGameSelected_
        {
            set { this.isPlayGameSelected = value; }
            get { return this.isPlayGameSelected; }
        }

        public bool PopInGameMenu_
        {
            set { this.PopInGameMenu = value; }
            get { return this.PopInGameMenu; }
        }

        public bool QuitToMain_
        {
            set { this.QuitToMain = value; }
            get { return this.QuitToMain; }
        }


        #region Fields

        private Song menuSong;
        private Song Lvl1to3;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        InGameMenu inGameMenu_ = null;

        GameManager manager;

        public GameManager gameManager_
        {
            get { return manager; }
        }


        System.Timers.Timer aTimer = new System.Timers.Timer(); // init timer
        static int timerSeconds = 0; // keep track of the seconds
	
        Background gameBackground = new Background();
        

        private State currentState;
        private State MenuState_;// this will help us to keep a copy of the previous Main Menu so we can go there if the user wants to go back
        private States.State nextState;

	

        #endregion

        public void ChangeState(State _state)
        {
            nextState = _state;
        }


        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timerSeconds++;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            //graphics.ToggleFullScreen();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {


            //loading the main menu music
            menuSong = Content.Load<Song>("Music/MenuMusic");
            Lvl1to3 = Content.Load<Song>("Music/LevelMusic");
            MediaPlayer.Play(menuSong);

            //initializing timers
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            manager = new GameManager(this.Content);

            //initializing inGame menu
            inGameMenu_ = new InGameMenu(graphics.GraphicsDevice, Content,this,manager);


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            gameBackground.Init(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content.Load<Texture2D>("Background/Level1"));

            // TODO: use this.Content to load your game content here
            MenuState_ =  currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        public void Update_(GameTime gameTime)
        {
            this.Update(gameTime);
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            //this line will prevent updating game1 when we are in the Game Menu
            //Console.WriteLine("Game 1");
            

            if (isPlayGameSelected)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    PopInGameMenu = true;
                    
                    //currentState = MenuState_;
                    isPlayGameSelected = false;
                    manager.pauseGame();
                }
                    

                
                //deals with the inGameMenu popup
                if(PopInGameMenu)
                    inGameMenu_.Update(gameTime, spriteBatch);

                // TODO: Add your update logic here

                if (nextState != null)
                    {
                        currentState = nextState;
                        nextState = null;
                    }


                    //if only play button is selected start game manager
                    if (isPlayGameSelected)
                    {
                        MediaPlayer.Stop();
                        manager.Update(gameTime, spriteBatch);
                    }
            }

            //deals with if we should quit to the main menu
            if (QuitToMain)
            {
                Console.WriteLine("in quit");
                currentState = MenuState_;
                isPlayGameSelected = false;
                QuitToMain = false;
            }

            currentState.Update(gameTime,spriteBatch);
            currentState.PostUpdate(gameTime);


            //manager.Update(gameTime);
            
            base.Update(gameTime);


        }

        //this is an inteface function to call protected function since we dont have access to it from outside
        public void Draw_(GameTime gameTime)
        {
            this.Draw(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            

            gameBackground.Draw(gameTime, spriteBatch);
           
            //if only play button is selected start game manager
            if (isPlayGameSelected)
            {
               MediaPlayer.Stop();
               manager.Draw(gameTime, spriteBatch);
            }

            


            spriteBatch.End();
            // TODO: Add your drawing code here
            currentState.Draw(gameTime, spriteBatch);

            if (PopInGameMenu)
                inGameMenu_.Update(gameTime, spriteBatch);



            base.Draw(gameTime);


        }
    }
}
