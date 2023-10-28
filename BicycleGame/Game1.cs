using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace BicycleGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Tilemap tilemap;

        private Biker biker;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            biker = new Biker();

            if (File.Exists("SaveState.Txt"))
            {
                biker.position = InputData();
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tilemap = Content.Load<Tilemap>("tilemaptest");
            biker.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // When Escape is pressed, the position is saved
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                // Saves the position of the biker
                using (StreamWriter sw = new StreamWriter("SaveState.txt"))
                {
                    string saveState1 = JsonSerializer.Serialize(biker.position.X);
                    string saveState2 = JsonSerializer.Serialize(biker.position.Y);
                    sw.WriteLine(saveState1);
                    sw.WriteLine(saveState2);
                    //Debug.WriteLine(saveState1);
                    //Debug.WriteLine(saveState2);
                }
                Exit();
            }

            biker.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            tilemap.Draw(gameTime, _spriteBatch);
            biker.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private Vector2 InputData()
        {
            Vector2 tempVec = new Vector2();
            using (StreamReader sr = new StreamReader("SaveState.txt"))
            {
                tempVec.X = float.Parse(sr.ReadLine());
                tempVec.Y = float.Parse(sr.ReadLine());
                Debug.WriteLine(tempVec.X);
                Debug.WriteLine(tempVec.Y);
            }

            return tempVec;
        }
    }
}