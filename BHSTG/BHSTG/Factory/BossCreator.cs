using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHSTG.Product;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BHSTG.Factory
{
	class BossCreator : EntityCreator
	{
		public override Entity makeEntity(Vector2 position, int health, bool speedMode, GameSprite sprite, Texture2D bulletTexture)
		{
			throw new NotImplementedException();
		}

		public override Entity makeEntity(Vector2 position, Vector2 end, int health, bool speed, GameSprite sprite)
		{
			return new MidBoss(position, end, health, speed, sprite);
		}

		public override Entity makeEntity(Vector2 position, Vector2 end, int health, bool speed, GameSprite sprite, Texture2D newBulletTexture)
		{
			return new FinalBoss(position, end, health, speed, sprite, newBulletTexture);
		}
	}
}
