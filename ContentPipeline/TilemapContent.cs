using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentPipeline
{
    [ContentSerializerRuntimeType("BicycleGame.Tilemap, BicycleGame")]
    public class TilemapContent
    {
        public int MapWidth;
        public int MapHeight;

        public int TileWidth;
        public int TileHeight;

        public Texture2DContent Texture;

        public Rectangle[] Tiles;

        public int[] Indices;

        [ContentSerializerIgnore]
        public string MapFileName;

        [ContentSerializerIgnore]
        public string ImageFileName;
    }
}
