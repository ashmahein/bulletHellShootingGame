using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSTG.States
{
    public abstract class State
    {
        #region Fields

        protected ContentManager content;
        protected GraphicsDevice graphicsDevice;
        protected Game1 game;

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
        {
            game = _game;
            graphicsDevice = _graphicsDevice;
            content = _content;
        }

        public abstract void Update(GameTime gameTime, SpriteBatch spriteBatch);

        #endregion
    }
}
