using BHSTG.Factory;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework.Media;

namespace BHSTG
{
    public class GameManager
    {
        
        //
        //Spawning has to do with this class
        //
        //this saves a reference to Content
        ContentManager tempContent;
 
        //variables to store music
        private Song Lvl1to3;
        private Song FinalBoss;

        //game timer
        System.Timers.Timer aTimer = new System.Timers.Timer(); // init timer
        static int timerSeconds = 0; // keep track of the seconds

        //property to access timerSeconds
        public int timerSeconds_
        {
            set { this.timerSeconds_ = value; }
            get { return timerSeconds; }
        }

        //this will keep track of if the game is over or not, this helps in enabeling timer in the update function
        bool gameOverStatus = false;        

        public EntityManager entityManager;

        public EntityFactory factory;

        ScriptReader sr; 

        public List<Level> levelList = new List<Level>();
        public Level curLevel;

        public bool LevelSelected = false;

        //this function will reset the timer allowing us to restart the game
        public void resetGame()
        {
            //turining off the timer
            aTimer.Enabled = false;
            timerSeconds = 0;

            entityManager.removeAllBullets();
            entityManager.removeAllEnemies();
            gameOverStatus = false;
            
            //reset everything on the player
            entityManager.player._health = 100;
            entityManager.player.isAlive = true;
            entityManager._drawPlayer = true;
            // we gotta zero out the player score as well !
            entityManager.gameScoreboard.playerScore = 0;
            levelList.Clear();
            if(!LevelSelected)
            {
                Console.WriteLine(LevelSelected);
                foreach (Wave w in sr.waveList)
                {
                    levelList.Add(new Level(w, ref entityManager, factory,tempContent));
                }
            }
            
        }

        //this will pause the timer which will basically pause the game
        public void pauseGame()
        {
            aTimer.Enabled = false;
        }

        //this will resume the timer and resume the game
        public void resumeGame()
        {
            aTimer.Enabled = true;
        }

        //this is event handler to increment time
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timerSeconds++;
        }

        public GameManager(ContentManager content)
        {
            //making a copy of content manager so we can draw time string
            tempContent = content;
            //initializing timers
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;

            //load song
            FinalBoss = tempContent.Load<Song>("Music/FinalBoss");

            //Reading waves from script
            sr = new ScriptReader();

            entityManager = new EntityManager(tempContent);
            factory = new EntityFactory(content);

            entityManager.addPlayer(factory.getPlayer("MoveLikePlayer", "ShootLikePlayer", 1920 / 2, 750, 0,0, "blast-up","fly-right-left"));


            entityManager.addBomb(factory.GetBomb());

            //Creating each level based on the wave information
            foreach(Wave w in sr.waveList)
            {
                levelList.Add(new Level(w, ref entityManager, factory,tempContent));
            }

            //Setting current level to be the first level in the level list
            if(levelList.Count > 0)
            {
                curLevel = levelList[0];
            }
        }

       

        public void GameOver(SpriteBatch spriteBatch)
        {
            //drawing game over sprite
            //spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Game Over ", new Vector2(500, 230), Color.White);
            spriteBatch.Draw(tempContent.Load<Texture2D>("Background/GameOver"), new Vector2(550, 250), Color.White);
            //Console.WriteLine("GameOver\n");
            entityManager.removeAllBullets();
            entityManager.removeAllEnemies();
            entityManager._drawPlayer = false;

            gameOverStatus = true;
            aTimer.Enabled = false;//stoping the timer


        }

        public void HealthMeter(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Player Health : ", new Vector2(20, 10), Color.White);

            int iteratorTime = 0;
            int gap = 0;

            if (entityManager.getPlayer()._health >= 75)
                iteratorTime = 4;
            else if (entityManager.getPlayer()._health >= 50)
                iteratorTime = 3;
            else if (entityManager.getPlayer()._health >= 25)
                iteratorTime = 2;
            else if (entityManager.getPlayer()._health >= 0)
                iteratorTime = 1;
            else
                iteratorTime = 0;

            if(!gameOverStatus)
                for (int loop=0;loop<iteratorTime;loop++)
                {
                    spriteBatch.Draw(tempContent.Load<Texture2D>("Background/health"), new Rectangle(200 + gap, 7, 40, 40), Color.White);
                    gap += 40;
                }
                
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
           // Console.WriteLine("updating game manager !");
            spriteBatch.Begin();
            //this condition makes sure enabeling timer is done only once
            if (!aTimer.Enabled && gameOverStatus== false)
                aTimer.Enabled = true;


            if(levelList.Count == 0)
            {
                gameOverStatus = true;
            }
            else
            {
                if(!curLevel.isLevelOver(timerSeconds))
                {
                    curLevel.Update(timerSeconds);
                }
                else
                {
                    levelList.RemoveAt(0); // if the level is over, remove the first element of the list

                    entityManager.enemies.Clear();
                    entityManager.enemyBullets.Clear();
                    entityManager.playerBullets.Clear();

                    try //try to get the next level in the list
                    {
                        curLevel = levelList[0];
                    }
                    catch // if you can then the game is over
                    {
                        gameOverStatus = true;
                    }
                }
            }

            entityManager.Update(gameTime);

            //this will update the timer 

            //check if game is over
            if (entityManager.player.isDead() || gameOverStatus )
            {
                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/FinalScore"), "Final Score: " + entityManager.gameScoreboard.playerScore.ToString(), new Vector2(830, 700), Color.White);
                GameOver(spriteBatch);
            }else
            {
                //this will draw the players health
                HealthMeter(spriteBatch);

                //this draws the game time
                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Elapsed Time : " + timerSeconds.ToString(), new Vector2(1670, 10), Color.White);

                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Player Score : " + entityManager.gameScoreboard.playerScore.ToString(), new Vector2(880, 10), Color.White);
            }

            

            spriteBatch.End();
           // Console.WriteLine(timerSeconds);

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            entityManager.Draw(gameTime, spriteBatch);
            
            //check if game is over
            if (entityManager.player.isDead() || gameOverStatus)
            {
                //NEED TO FIX THE LOCATION OF WHERE THIS APPEARS ON THE SCREEN.
                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/FinalScore"), "Final Score: " + entityManager.gameScoreboard.playerScore.ToString(), new Vector2(830, 650), Color.White);
                GameOver(spriteBatch);
            }else
            {
                //this will draw the timer 
                HealthMeter(spriteBatch);
                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Elapsed Time : " + timerSeconds.ToString(), new Vector2(1670, 10), Color.White);
                spriteBatch.DrawString(tempContent.Load<SpriteFont>("Font/Font"), "Player Score : " + entityManager.gameScoreboard.playerScore.ToString(), new Vector2(880, 10), Color.White);
            }
        }
    }



}
