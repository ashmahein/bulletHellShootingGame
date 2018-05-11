using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace BHSTG.Controls
{
    public class Button : Component
    {
        #region Fields

        private MouseState currentMouse;
        private MouseState previousMouse;
        private SpriteFont font;
        private bool isHovering;
        private Texture2D texture;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColor { get; set; }

        public Vector2 Position;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }

            
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button()
        {

        }

        public Button(Texture2D _texture, SpriteFont _font)
        {
            texture = _texture;
            font = _font;
            PenColor = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if(isHovering ==  true)
            {
                color = Color.Gray;
            }
            Rectangle rec = new Rectangle(Rectangle.X, Rectangle.Y, 450, 90);
            spriteBatch.Draw(texture, rec, color);
            //spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, Rectangle.Width, Rectangle.Height),Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2)+70;
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2)+3;

                spriteBatch.DrawString(font, Text, new Vector2(x, y), PenColor);
            }
                  
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if(mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;

                if(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());                  
                }
            }
        }

        #endregion
    }
}
