using BHSTG.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Controls;
using BHSTG.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using BHSTG.ShootStrategy;
using BHSTG.MoveStrategy;

namespace BHSTG.Factory
{
    class PlayerCreator : EntityCreator
    {

        Vector2 startPos, endPos;
        int health = 100;
        bool speedMode = false;
        GameSprite sprite;
        Texture2D bulletTexture;
        

        public PlayerCreator(ContentManager content) 
        {
            this.content = content;
            startPos = new Vector2(1920 / 2, 750);
            sprite = new GameSprite(content.Load<Texture2D>("Entities/fly-right-left"), new Vector2(1920 / 2, 750), Color.White);

            bulletTexture = content.Load<Texture2D>("Bullets/blast-up");
        }

		public override Entity GetEntity(string move, string shoot, int startX, int startY, int endX, int endY, string bTexture, string eTexture)
		{
            startPos = new Vector2(startX, startY);
            endPos = new Vector2(endX, endY);
            bulletTexture = content.Load<Texture2D>("Bullets/" + bTexture);
            sprite = new GameSprite(content.Load<Texture2D>("Entities/" + eTexture), startPos, Color.White);



            if (move == "MoveLikeFinal")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Player(startPos, endPos,health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeGrunt());
                } else if (shoot == "ShootLikeMid")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeMid());
                } else if (shoot == "ShootLikePlayer")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikePlayer(this.content));
                } else
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
            } else if (move == "MoveLikeGrunt1")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikePlayer(this.content));
                }
            } else if (move == "MoveLikeMid")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikePlayer(this.content));
                }
            } else if (move == "MoveLikePlayer")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
            } else
            {
                return new Player(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));

            }
        }







		//public override Entity makeEntity(GameSprite sprte, Vector2 pos, Vector2 end, int Health, bool spdMode)
		//{
		//	return new Player(pos, end, Health, spdMode, sprte);

		//}




	}
}
