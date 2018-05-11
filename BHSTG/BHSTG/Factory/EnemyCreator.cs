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
	class EnemyCreator : EntityCreator
	{
		public override Entity makeEntity(Vector2 position, int health, bool speedMode, GameSprite sprite, Texture2D bulletTexture)
		{
			throw new NotImplementedException();
		}

		public override Entity makeEntity(Vector2 position, Vector2 end, int health, bool speed, GameSprite sprite)
		{
			throw new NotImplementedException();
		}

		public override Entity makeEntity(Vector2 position, Vector2 end, int health, bool speed, GameSprite sprite, Texture2D newBulletTexture)
		{
			return new Enemy(position, end, health, speed, sprite, newBulletTexture);
		}
	}
}
