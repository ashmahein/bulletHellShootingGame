using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.Factory
{
    

    abstract class EntityCreator
    {
        protected ContentManager content;//hleps us to load music and sprites

        public abstract Entity GetEntity(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture);
        

    }
}
