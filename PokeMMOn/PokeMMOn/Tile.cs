using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMMOn
{
    public class Tile
    {
        public TileSet Set = Game.Tiles32x32;
        public Texture2D texture {
            get {
                return Set.texture;
            }
        }
        public int Left;
        public int Top;
        public int X;
        public int Y;

        public Tile(TileSet Set1, int Left1, int Top1, int X1, int Y1)
        {
            Set = Set1;
            Left = Left1;
            Top = Top1;
            X = X1;
            Y = Y1;
        }

        public Rectangle GetTile()
        {
            return Set.GetTile(Left, Top);
        }
    }
}
