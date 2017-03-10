using Creepy.Tiles;
using Microsoft.Xna.Framework;

namespace Creepy
{
	public class Map
	{
		public readonly Size Size;
		readonly Tile [,] tiles;

		public Tile this [int x, int y]
		{
			get
			{
				// TODO; add checkers
				return tiles [x, y];
			}
		}

		public Tile this [Point p]
		{
			get{ return this [p.X, p.Y]; }
		}

		public Map (Size size)
		{
			Size = size;
			tiles = new Tile[Size.Width, Size.Height] ();
		}
	}
}