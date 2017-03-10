using System;
using System.Collections.Generic;
using Creepy.Tiles;
using Microsoft.Xna.Framework;

namespace Creepy
{
	/// <summary>
	/// Represents and manages 
	/// </summary>
	public class Map : IGameComponent
	{
		/// <summary>
		/// Gets the size of the map, in tile number
		/// </summary>
		public readonly Size Size;

		readonly Tile [,] tiles;

		/// <summary>
		/// Gets the tile in a given point
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Tile this [int x, int y]
		{
			get
			{
				if (x < 0 || y < 0 || x >= Size.Width || y >= Size.Height)
					throw new IndexOutOfRangeException ();
				return tiles [x, y];
			}
		}

		/// <summary>
		/// Gets the tile in a given point
		/// </summary>
		/// <param name="p">A point</param>
		public Tile this [Point p]
		{
			get{ return this [p.X, p.Y]; }
		}

		/// <summary>
		/// Initialize this instance.
		/// </summary>
		public void Initialize ()
		{
			// Initialize tiles
			for (int ix = 0; ix < Size.Width; ix++)
				for (int iy = 0; iy < Size.Height; iy++)
					tiles [ix, iy] = new Tile (new Point (ix, iy));
		}

		/// <summary>
		/// Enumerate the tiles of this map
		/// </summary>
		public IEnumerable<Tile> EnumerateTiles ()
		{
			for (int ix = 0; ix < Size.Width; ix++)
				for (int iy = 0; iy < Size.Height; iy++)
					yield return tiles [ix, iy];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Creepy.Map"/> class.
		/// </summary>
		/// <param name="size">Size of the map</param>
		public Map (Size size)
		{
			Size = size;
			tiles = new Tile[Size.Width, Size.Height];
		}
	}
}