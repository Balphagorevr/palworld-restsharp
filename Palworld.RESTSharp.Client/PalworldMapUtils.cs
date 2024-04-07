using System.Drawing.Imaging;

namespace Palworld.RESTSharp.Client
{
    internal static class PalworldMapUtils
    {
        internal static void CreateWorldMapChunks(string sourceImagePath, int numTilesX, int numTilesY, string saveDir)
        {
            using (Bitmap sourceImage = new Bitmap(sourceImagePath))
            {
                int tileWidth = sourceImage.Width / numTilesX;
                int tileHeight = sourceImage.Height / numTilesY;

                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                for (int y = 0; y < numTilesY; y++)
                {
                    for (int x = 0; x < numTilesX; x++)
                    {
                        Rectangle cropRect = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                        using (Bitmap tile = new Bitmap(cropRect.Width, cropRect.Height))
                        using (Graphics g = Graphics.FromImage(tile))
                        {
                            g.DrawImage(sourceImage, new Rectangle(0, 0, tile.Width, tile.Height), cropRect, GraphicsUnit.Pixel);
                            string tilePath = Path.Combine(saveDir, $"tile_{y}_{x}.png");
                            tile.Save(tilePath, ImageFormat.Png);
                        }
                    }
                }
            }
        }
    }
}
