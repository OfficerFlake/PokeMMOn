using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PokeMMOn
{
    public class Layer
    {
        public int mapSizeX = 32*32;
        public int mapSizeY = 32*32;
        public int tileWidth = 0;
        public int tileHeight = 0;

        public List<Tile> tiles = new List<Tile>();

        public void Loadt32(string filename)
        {
            tileHeight = 32;
            tileWidth = 32;

            StreamReader streamReader = new StreamReader(filename);
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            text = text.Replace("" + (char)13 + (char)10, "#");

            foreach (string Line in text.Split('#'))
            {
                if (Line == "") continue;
                int test0 = Line.IndexOf("Left:");
                int test1 = 0;
                int test2 = Line.IndexOf("!Top:");
                string test3 = Line.Substring(Line.IndexOf("Left:") + "Left:".Length, Line.IndexOf("!Top:") - (Line.IndexOf("Left:") + "Left:".Length));
                int Left = Int32.Parse(Line.Substring(Line.IndexOf("Left:") + "Left:".Length, Line.IndexOf("!Top:") - (Line.IndexOf("Left:") + "Left:".Length)));
                int Top = Int32.Parse(Line.Substring(Line.IndexOf("Top:") + "Top:".Length, Line.IndexOf("!X:") - (Line.IndexOf("Top:") + "Top:".Length)));
                int X = Int32.Parse(Line.Substring(Line.IndexOf("X:") + "X:".Length, Line.IndexOf("!Y:") - (Line.IndexOf("X:") + "X:".Length)));
                int Y = Int32.Parse(Line.Substring(Line.IndexOf("Y:") + "Y:".Length, Line.Length - 1 - (Line.IndexOf("Y:") + "Y:".Length)));
                Tile newtile = new Tile(Game.Tiles32x32, Left, Top, X, Y);
                tiles.Add(newtile);
            }
        }
        public void Loadt16(string filename)
        {
            tileHeight = 16;
            tileWidth = 16;

            StreamReader streamReader = new StreamReader(filename);
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            text = text.Replace("" + (char)13 + (char)10, "#");

            foreach (string Line in text.Split('#'))
            {
                if (Line == "") continue;
                int test0 = Line.IndexOf("Left:");
                int test1 = Line.IndexOf("Left:") + "Left:".Length;
                int test2 = Line.IndexOf("!Top:");
                string test3 = Line.Substring(Line.IndexOf("Left:") + "Left:".Length, Line.IndexOf("!Top:") - (Line.IndexOf("Left:") + "Left:".Length));
                int Left = Int32.Parse(Line.Substring(Line.IndexOf("Left:") + "Left:".Length, Line.IndexOf("!Top:") - (Line.IndexOf("Left:") + "Left:".Length)));
                int Top = Int32.Parse(Line.Substring(Line.IndexOf("Top:") + "Top:".Length, Line.IndexOf("!X:") - (Line.IndexOf("Top:") + "Top:".Length)));
                int X = Int32.Parse(Line.Substring(Line.IndexOf("X:") + "X:".Length, Line.IndexOf("!Y:") - (Line.IndexOf("X:") + "X:".Length)));
                int Y = Int32.Parse(Line.Substring(Line.IndexOf("Y:") + "Y:".Length, Line.Length - 1 - (Line.IndexOf("Y:") + "Y:".Length)));
                Tile newtile = new Tile(Game.Tiles16x16, Left, Top, X, Y);
                tiles.Add(newtile);
            }
        }
    }
}
