using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG
{
    public class Wave
    {
        public int level { get; set; }
        public int startTimer { get; set; }
        public int endTimer { get; set; }
        public int xStart { get; set; }
        public int yStart { get; set; }
        public int xEnd { get; set; }
        public int yEnd { get; set; }
        public int enemyAmount { get; set; }
        public int spawnInterval { get; set; }
        public String enemySprite { get; set; }
        public String enemyBullets { get; set; }
        public String enemyMovementType { get; set; }
        public String enemyShootType { get; set; }
        public String enemyType { get; set; }

        public Wave()
        {

        }
    }
}
