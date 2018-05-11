using BHSTG.Controls;
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
    class LevelSelector
    {
        ContentManager tempContent;
        private GraphicsDevice graphics = null; // this will keep a copy of Graphic device stuff
        InGameMenu inGameMenu_ = null;

        Rectangle rec;
        GameManager gameMangerRef; //keeps a reference to our aleardy created gameManager
        Game1 game1Ref;

        Background gameBackground = new Background();
        Background IngameBackground = new Background();

        private List<Component> components;//saves all the buttons
        private bool LVLClicked = false;

        bool PopInGameMenu = false;

        public LevelSelector(GraphicsDevice graphics, ContentManager content, Game1 game1Ref, GameManager gameMangerRef)
        {
            //setting up our ingame menu


            //setting up the variables for the Instructions side
            gameBackground.Init(graphics.Viewport.Width, graphics.Viewport.Height, content.Load<Texture2D>("Background/GameBackground"));
            IngameBackground.Init(graphics.Viewport.Width, graphics.Viewport.Height, content.Load<Texture2D>("Background/Level1"));
            
            this.graphics = graphics;
            this.tempContent = content;
            this.game1Ref = game1Ref;
            this.gameMangerRef = gameMangerRef;

            inGameMenu_ = new InGameMenu(this.graphics, tempContent, this.game1Ref, gameMangerRef);

            rec = new Rectangle(graphics.Viewport.Width / 5, graphics.Viewport.Height / 100, 1080, 965);
            var buttonTexture = content.Load<Texture2D>("Controls/gameButton");
            var buttonFont = content.Load<SpriteFont>("Font/Font");
            int gap = 0;
            int horizontalpading = 0;

            var lvl1 = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 38 + horizontalpading, 300 + gap),
                Text = "Level 1",
            };
            lvl1.Click += LVL1_Clicked;

            var lvl2 = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 38 + horizontalpading, 450 + gap),
                Text = "Level 2",
            };
            lvl2.Click += LVL2_Clicked;

            var lvl3 = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 38 + horizontalpading, 600 + gap),
                Text = "Level 3",
            };
            lvl3.Click += LVL3_Clicked;

            var lvl4 = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(graphics.Viewport.Width / 38 + horizontalpading, 750 + gap),
                Text = "Level 4",
            };
            lvl4.Click += LVL4_Clicked;

            components = new List<Component>()
            {
                lvl1,
                lvl2,
                lvl3,
                lvl4,
            };
        }

        private void LVL1_Clicked(object sender, System.EventArgs e)
        {
            LVLClicked = true;
            game1Ref.gameManager_.LevelSelected = true;
            game1Ref.gameManager_.resetGame();
            //Create a wave object of level = 2
            Wave w = new Wave();
            w.level = 1;
            w.spawnInterval = 25;
            w.startTimer = 0;
            w.endTimer = 50;
            w.enemyType = "gruntLvl1";
            w.enemyAmount = 4;
            w.xEnd = 1500;
            w.xStart = 60;
            w.yEnd = 200;
            w.yStart = 20;
            w.enemySprite = "grunt1";
            w.enemyMovementType = "MoveLikeGrunt1";
            w.enemyShootType = "ShootLikeGrunt";
            w.enemyBullets = "blast2-down";


            //create a level using that wave
            Level L1 = new Level(w, ref game1Ref.gameManager_.entityManager, game1Ref.gameManager_.factory,tempContent);

            //Add wave to levelList in GameManager
            game1Ref.gameManager_.levelList.Add(L1);
            game1Ref.gameManager_.curLevel = game1Ref.gameManager_.levelList[0];
        }

        private void LVL2_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("LVL 2 Selected !\n");
            LVLClicked = true;
            game1Ref.gameManager_.LevelSelected = true;
            game1Ref.gameManager_.resetGame();
            //Create a wave object of level = 2
            Wave w = new Wave();
            w.level = 2;
            w.spawnInterval = 100;
            w.startTimer = 0;
            w.endTimer = 50;
            w.enemyType = "midBoss";
            w.enemyAmount = 1;
            w.xEnd = 1500;
            w.xStart = 0;
            w.yEnd = 200;
            w.yStart = 300;
            w.enemySprite = "mid_boss";
            w.enemyMovementType = "MoveLikeMid";
            w.enemyShootType = "ShootLikeMid";
            w.enemyBullets = "BossBullet";


            //create a level using that wave
            Level L2 = new Level(w, ref game1Ref.gameManager_.entityManager, game1Ref.gameManager_.factory,tempContent);

            //Add wave to levelList in GameManager
            game1Ref.gameManager_.levelList.Add(L2);
            game1Ref.gameManager_.curLevel = game1Ref.gameManager_.levelList[0];

        }

        private void LVL3_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("LVL 3 Selected !\n");
            LVLClicked = true;
            //just tells gameManager that we are coming in through the level selection rather than the regual play game.
            game1Ref.gameManager_.LevelSelected = true;
            game1Ref.gameManager_.resetGame();
            //Create a wave object of level = 3
            Wave w = new Wave();
            w.level = 3;
            w.spawnInterval = 25;
            w.startTimer = 0;
            w.endTimer = 50;
            w.enemyType = "gruntLvl2";
            w.enemyAmount = 5;
            w.xEnd = 1500;
            w.xStart = 60;
            w.yEnd = 200;
            w.yStart = 20;
            w.enemySprite = "grunt1";
            w.enemyMovementType = "MoveLikeGrunt1";
            w.enemyShootType = "ShootLikeGrunt";
            w.enemyBullets = "blast2-down";

            //create a level using that wave
            Level L3 = new Level(w, ref game1Ref.gameManager_.entityManager, game1Ref.gameManager_.factory,tempContent);
            Console.WriteLine(game1Ref.gameManager_.levelList.Count);
            //Add wave to levelList in GameManager
            game1Ref.gameManager_.levelList.Add(L3);
            game1Ref.gameManager_.curLevel = game1Ref.gameManager_.levelList[0];

        }

        private void LVL4_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("LVL 4 Selected !\n");
            LVLClicked = true;
            game1Ref.gameManager_.LevelSelected = true;
            game1Ref.gameManager_.resetGame();
            //Create a wave object of level = 4
            Wave w = new Wave();
            w.level = 4;
            w.spawnInterval = 100;
            w.startTimer = 0;
            w.endTimer = 50;
            w.enemySprite = "finalboss";
            w.enemyAmount = 1;
            w.xEnd = 1500;
            w.xStart = 60;
            w.yEnd = 200;
            w.yStart = 20;
            w.enemySprite = "final_boss";
            w.enemyMovementType = "MoveLikeFinal";
            w.enemyShootType = "ShootLikeFinal";
            w.enemyBullets = "BossBullets";

            //create a level using that wave
            Level L4 = new Level(w, ref game1Ref.gameManager_.entityManager, game1Ref.gameManager_.factory,tempContent);

            //Add wave to levelList in GameManager
            game1Ref.gameManager_.levelList.Add(L4);
            game1Ref.gameManager_.curLevel = game1Ref.gameManager_.levelList[0];
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            IngameBackground.Draw(gameTime, spriteBatch);

            if (!game1Ref.PopInGameMenu_)
            {
                if (LVLClicked)
                {
                    //spriteBatch.Begin();
                    
                    //spriteBatch.End();
                    game1Ref.gameManager_.Draw(gameTime, spriteBatch);


                }
                else
                {
                    gameBackground.Draw(gameTime, spriteBatch);
                    foreach (var component in components)
                        component.Draw(gameTime, spriteBatch);

                    spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/TitleFont"), "Select Level", new Vector2(50, 70), Color.White);
                    spriteBatch.Draw(tempContent.Load<Texture2D>("Background/Goku_UI"), new Rectangle(1170, -50, 1378, 1200), new Rectangle(0, 0, 689, 600), Color.White);
                }
            }
            else
            {
                inGameMenu_.Draw(gameTime, spriteBatch);
            }

            
        }

        public void update(GameTime gameTime, SpriteBatch spriteBatch, ref bool isSelectLevelPressed)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                game1Ref.PopInGameMenu_ = true;
            }



            if(!game1Ref.PopInGameMenu_)
            {
                if (LVLClicked)
                {
                    game1Ref.gameManager_.Update(gameTime, spriteBatch);
                    //also reset game status just in case
                    //game1Ref.gameManager_.resetGame();
                }
                else
                {


                    spriteBatch.Begin();
                    gameBackground.Update(gameTime);

                    foreach (var component in components)
                    {
                        component.Draw(gameTime, spriteBatch);
                        component.Update(gameTime);
                    }

                    spriteBatch.End();
                }
            }else
            {

                inGameMenu_.Update(gameTime,spriteBatch);
            }

            if (game1Ref.QuitToMain_)
            {
                Console.WriteLine("quitting");
                LVLClicked = false;
                isSelectLevelPressed = false;
            }
                


        }
    }
}
