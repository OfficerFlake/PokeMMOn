using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace PokeMMOn
{
        public class TileSet
        {
            public Texture2D texture;
            private int tileWidth;
            private int tileHeight;

            public TileSet(GraphicsDevice graphics, string ImageFile, int TileWidth, int TileHeight)
            {
                using (FileStream fileStream = new FileStream(ImageFile, FileMode.Open))
                {
                    texture = Texture2D.FromStream(graphics, fileStream);
                }
                tileWidth = TileWidth;
                tileHeight = TileHeight;
            }

            public Rectangle GetTile(int x, int y)
            {
                Rectangle bounds = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                return bounds;
                //return specific tile as a graphic.
            }

            public void SetTile(int x, int y)
            {
                //replaces a tile... is this really needed though?
            }
        }
    }
