using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.IO;
using System.Linq;

namespace ContentPipeline
{
    [ContentImporter(".tilemap", DisplayName = "TilemapImporter", DefaultProcessor = "TilemapProcessor")]
    public class TilemapImporter : ContentImporter<TilemapContent>
    {
        public override TilemapContent Import(string filename, ContentImporterContext context)
        {
            /*
            // Create a new BasicTilemapContent
            TilemapContent map = new();

            // Read in the map file and split along newlines 
            string data = File.ReadAllText(filename);
            var lines = data.Split('\n');

            // First line in the map file is the image file name,
            // we store it so it can be loaded in the processor
            map.ImageFileName = lines[0].Trim();

            // Second line is the tileset image size
            var secondLine = lines[1].Split(',');
            map.TileWidth = int.Parse(secondLine[0]);
            map.TileHeight = int.Parse(secondLine[1]);

            // Third line is the map size (in tiles)
            var thirdLine = lines[2].Split(',');
            map.MapWidth = int.Parse(thirdLine[0]);
            map.MapHeight = int.Parse(thirdLine[1]);

            // Fourth line is the map data (the indices of tiles in the map)
            // We can use the Linq Select() method to convert the array of strings
            // into an array of ints
            map.Indices = lines[3].Split(',').Select(index => int.Parse(index)).ToArray();

            // At this point, we've copied all of the file data into our
            // BasicTilemapContent object, so we pass it on to the processor
            return map;
            */

            context.Logger.LogMessage("Started Import");

            TilemapContent map = new TilemapContent();

            string input = File.ReadAllText(filename);
            string[] lines = input.Split('\n');
            string line1 = lines[0].Trim();
            string[] line2 = lines[1].Split(',');
            string[] line3 = lines[2].Split(',');
            string line4 = lines[3];

            map.ImageFileName = line1;

            map.TileWidth = int.Parse(line2[0]);
            map.TileHeight = int.Parse(line2[1]);

            map.MapWidth = int.Parse(line3[0]);
            map.MapHeight = int.Parse(line3[1]);

            map.Indices = new int[map.MapWidth * map.MapHeight];

            /*
            for (int y = 0; y < map.MapHeight; y++)
            {
                string[] currentLine = lines[3 + y].Split(',');

                for (int x = 0; x < map.MapWidth; x++)
                {
                    map.Indices[y * map.MapWidth + x] = int.Parse(currentLine[x]);
                }
            }
            */
     
            map.Indices = line4.Split(',').Select(index => int.Parse(index)).ToArray();

            return map;
        }
    }
}