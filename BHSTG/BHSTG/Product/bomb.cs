using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.Product
{
    public class Bomb : Bullet
    {
        public Bomb(Texture2D nTexture): base(nTexture)
        {
            damage = 25;

            //bulletPosition = ;
            bulletVelocity = new Vector2(0,0);


        }
        public void Explode(List<Entity> enemies, List<Bullet> bullets)
        {
            
            foreach(Bullet bullet in bullets)
            {
                bullet.isActive = false;
            }
            foreach (Entity enemy in enemies)
            {
                enemy._health -= damage;
                if (enemy._health<= 0)
                {
                    enemy.isAlive = false;
                }
            }
        }
    }
}
