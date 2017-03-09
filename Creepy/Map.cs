using Creepy.Tiles;

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

		public Map (Size size)
		{
			Size = size;
			tiles = new Tile[Size.Width, Size.Height] ();
		}
	}
}