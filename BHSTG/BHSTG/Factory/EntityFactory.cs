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
    public class EntityFactory
    {
        EntityCreator factory;
        ContentManager content;
        public EntityFactory(ContentManager content)
        {
            this.content = content;
        }
        public Player getPlayer(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            factory = new PlayerCreator(content);
            return (Player)factory.GetEntity(move, shoot, startX, startY, endX, endY, bTexture, eTexture);
        }
        public Grunt1 getGrunt1(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            factory = new Grunt1Creator(content);
            return (Grunt1)factory.GetEntity(move, shoot, startX, startY, endX, endY, bTexture, eTexture);
        }
        public Grunt2 getGrunt2(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            factory = new Grunt2Creator(content);
            return (Grunt2)factory.GetEntity(move, shoot, startX, startY, endX, endY, bTexture, eTexture);
        }
        public MidBoss getMidBoss(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            factory = new MidBossCreator(content);
            return (MidBoss) factory.GetEntity(move, shoot, startX, startY, endX, endY, bTexture, eTexture);
        }

        public FinalBoss getFinalBoss(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            factory = new FinalBossCreator(content);
            return (FinalBoss)factory.GetEntity(move, shoot, startX, startY, endX, endY, bTexture, eTexture);
        }
        public Bomb GetBomb()
        {
            Texture2D bombTexture = content.Load<Texture2D>("Background/tp");

            Bomb b = new Bomb(bombTexture);
            return b;
        }
    }
}
