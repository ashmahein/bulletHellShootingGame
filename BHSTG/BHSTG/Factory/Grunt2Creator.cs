using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BHSTG.MoveStrategy;
using BHSTG.ShootStrategy;

namespace BHSTG.Factory
{
    class Grunt2Creator : EntityCreator
    {
        Vector2 startPos = new Vector2(60, 20), endPos = new Vector2(1500, 200);
        int health = 75;
        bool speedMode = true;
        GameSprite sprite;
        Texture2D bulletTexture;

        public Grunt2Creator(ContentManager content)
        {
            this.content = content;
            sprite = new GameSprite(content.Load<Texture2D>("Entities/grunt1"), startPos, Color.White);

            bulletTexture = content.Load<Texture2D>("Bullets/blast2-down");
        }

        public override Entity GetEntity(string move, string shoot, int startX, int startY, int endX, int endY, String bTexture, String eTexture)
        {
            startPos = new Vector2(startX, startY);
            endPos = new Vector2(endX, endY);
            bulletTexture = content.Load<Texture2D>("Bullets/" + bTexture);
            sprite = new GameSprite(content.Load<Texture2D>("Entities/" + eTexture), startPos, Color.White);

            if (move == "MoveLikeFinal")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeFinal(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
            }
            else if (move == "MoveLikeGrunt1")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeGrunt1(), new ShootLikePlayer(this.content));
                }
            }
            else if (move == "MoveLikeMid")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikeMid(), new ShootLikePlayer(this.content));
                }
            }
            else if (move == "MoveLikePlayer")
            {
                if (shoot == "ShootLikeFinal")
                {
                    return new Grunt1(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeFinal());
                }
                else if (shoot == "ShootLikeGrunt")
                {
                    return new Grunt1(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeGrunt());
                }
                else if (shoot == "ShootLikeMid")
                {
                    return new Grunt1(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikeMid());
                }
                else if (shoot == "ShootLikePlayer")
                {
                    return new Grunt1(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
                else
                {
                    return new Grunt1(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));
                }
            }
            else
            {
                return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture, content, new MoveLikePlayer(), new ShootLikePlayer(this.content));

            }
            return new Grunt2(startPos, endPos, health, speedMode, sprite, bulletTexture,content, new MoveLikeGrunt1(), new ShootLikeMid());
        }

    }
}
