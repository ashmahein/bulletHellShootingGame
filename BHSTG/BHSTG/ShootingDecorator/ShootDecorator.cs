using BHSTG.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BHSTG.ShootingDecorator
{
    public abstract class ShootDecorator : Entity
    {
        Entity mEntity;

        public ShootDecorator(Entity e)
        {
            mEntity = e;
        }

        public override List<Bullet> Shoot()
        {
            return null;
        }
    }
}
