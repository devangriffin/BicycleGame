using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace BicycleGame
{
    public class Biker
    {
        private KeyboardState keyState;
        private Texture2D texture;

        public Vector2 position;
        public bool flipped = false;

        public Biker()
        {
        }

        public void LoadContent(ContentManager cm)
        {
            texture = cm.Load<Texture2D>("bikeman");
        }

        public void Update()
        {
            keyState = Keyboard.GetState();
            int speed = 6;

            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) { position += new Vector2(0, -speed); }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) { position += new Vector2(0, speed); }
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) { position += new Vector2(-speed, 0); flipped = true; }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) { position += new Vector2(speed, 0); flipped = false; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (flipped) { spriteBatch.Draw(texture, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.FlipHorizontally, 0); }
            else { spriteBatch.Draw(texture, position, Color.White); }
        }
    }
}
