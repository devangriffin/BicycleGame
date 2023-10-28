using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleGame
{
    public class Tilemap
    {
        public int MapWidth { get; init; }
        public int MapHeight { get; init; }

        public int TileWidth { get; init; }
        public int TileHeight { get; init; }

        public Texture2D Texture { get; init; }

        public Rectangle[] Tiles { get; init; }

        public int[] Indices { get; init; }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    int index = Indices[y * MapWidth + x] - 1;

                    if (index == -1) { continue; }

                    sb.Draw(Texture, new Rectangle(x * TileWidth, y * TileHeight, TileWidth, TileHeight), Tiles[index], Color.White);
                }
            }   
        }
    }
}
