using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework;

namespace ContentPipeline
{
    [ContentProcessor(DisplayName = "TilemapProcessor")]
    public class TilemapProcessor : ContentProcessor<TilemapContent, TilemapContent>
    {
        public float Scale { get; set; } = 1.0f;

        public override TilemapContent Process(TilemapContent input, ContentProcessorContext context)
        {
            input.Texture = context.BuildAndLoadAsset<TextureContent, Texture2DContent>(new ExternalReference<TextureContent>(input.ImageFileName), "TextureProcessor");

            int columns = input.Texture.Mipmaps[0].Width / input.TileWidth;
            int rows = input.Texture.Mipmaps[0].Height / input.TileHeight;

            input.Tiles = new Rectangle[columns * rows];
            context.Logger.LogMessage($"{input.Tiles.Length} Tiles");

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    input.Tiles[y * columns + x] = new Rectangle(x * input.TileWidth, y * input.TileHeight, input.TileWidth, input.TileHeight);
                }
            }

            input.TileWidth = (int)(input.TileWidth * Scale);
            input.TileHeight = (int)(input.TileHeight * Scale);

            return input;
        }
    }
}