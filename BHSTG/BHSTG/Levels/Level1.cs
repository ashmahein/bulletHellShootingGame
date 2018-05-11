using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BHSTG.Levels
{
    class Level1
    {
        int startTime, endTime;
        Vector2 start, end;
        EntityManager EM = new EntityManager();

        public Level1(int startTime, int endTime, Vector2 startPosition, Vector2 endPostion, string spriteFile, string movementType, string shootingType)
        {
        }

        //Level1 spawn grunts
        public void Level1()
        {

            //checks to see if level 1 has already started then sets the lvl1StartTime to the current time on Timer
            if (!lvl1Started)
            {
                lvl1StartTime = sr.startTimer;
                lvl1StartTime = timerSeconds;
                lvl1Started = true; //wont go in here more than 1 time.
            }

            //Only has 4 lvl1 grunts spawned at a time. Will spawn more lvl1 grunts if at least 1 second has passed.
            if (entityManager.enemies.Count < 4 && (timerSeconds - lastSpawn >= 1))
            {
                entityManager.addEnemy(factory.getGrunt1());
                lastSpawn = timerSeconds;
            }

            //15 second duration for level 2
            if (timerSeconds - lvl1StartTime > 15)
            {
                entityManager.removeAllEnemies();
                entityManager.removeAllBullets();
                curLevel = 2;
            }
        }

    }
}
