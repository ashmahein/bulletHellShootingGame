using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Factory;
using Microsoft.Xna.Framework.Content;

namespace BHSTG
{
    public class Level
    {
        
        Wave w;
        int lastWaveSpawn, newEnemyCount, lastEnemySpawn, timeLevelStarted;
        bool hasLevelStarted = false;
        bool isBoss = false;
        EntityFactory factory;
        ContentManager content = null;
        EntityManager EM = null;  
        public Level(Wave newW, ref EntityManager em, EntityFactory f, ContentManager content)
        {
            EM = new EntityManager(content);
            EM = em;
            w = newW;
            this.content = content;
            EM.enemies.Clear();
            em.enemyBullets.Clear();
            
            newEnemyCount = 0;//Start with enemyCount = 0 so it populates enemies as soon as level starts
            lastEnemySpawn = 0;
            lastWaveSpawn = -1;

            factory = f;
        }

        public bool isLevelOver(int timerSeconds)
        {
            if(!hasLevelStarted)
            {
                timeLevelStarted = timerSeconds;
                hasLevelStarted = true;
            }
            if(timerSeconds - timeLevelStarted >= (w.endTimer - w.startTimer))
            {
                return true;
            }
            if((isBoss == true) && (EM.enemies.Count == 0))
            {
                return true;
            }
            return false;
        }

        public void Update(int timerSeconds)
        {
            if((timerSeconds - lastWaveSpawn) >= w.spawnInterval)
            {
                newEnemyCount = 0;
                lastWaveSpawn = timerSeconds;
            }

            //Spawn enemyAmount of enemies with a 1 second delay so they arent overlaping one another
            if(newEnemyCount < w.enemyAmount && (timerSeconds - lastEnemySpawn) > 1)
            {
                //Spawn specific types of enemies
                if(w.enemyType == "gruntLvl1")
                {
                    //getGrunt1(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
                    EM.addEnemy(factory.getGrunt1(w.enemyMovementType, w.enemyShootType, w.xStart, w.yStart, w.xEnd, w.yEnd, w.enemyBullets, w.enemySprite));
                }
                else if (w.enemyType == "midBoss")
                {
                    isBoss = true;
                    EM.addEnemy(factory.getMidBoss(w.enemyMovementType, w.enemyShootType, w.xStart, w.yStart, w.xEnd, w.yEnd, w.enemyBullets, w.enemySprite));
                }
                else if (w.enemyType == "gruntLvl2")
                {
                    EM.addEnemy(factory.getGrunt2(w.enemyMovementType, w.enemyShootType, w.xStart, w.yStart, w.xEnd, w.yEnd, w.enemyBullets, w.enemySprite));
                }
                else if (w.enemyType == "finalBoss")
                {

                    isBoss = true;

                    EM.addEnemy(factory.getFinalBoss(w.enemyMovementType, w.enemyShootType, w.xStart, w.yStart, w.xEnd, w.yEnd, w.enemyBullets, w.enemySprite));
                }
                lastEnemySpawn = timerSeconds;
                newEnemyCount++;
            }

            //Wait untill all of the enemies are spawned before starting the spawn interval
            if (newEnemyCount == w.enemyAmount-1)
            {
                lastWaveSpawn = timerSeconds;
            }
        }
    }
}
