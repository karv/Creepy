using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Creepy.Tiles
{
	/// <summary>
	/// Represents a tile in the map
	/// </summary>
	public class Tile
	{
		/// <summary>
		/// Gets the tile location inside the map
		/// </summary>
		public Point Location { get; }

		/// <summary>
		/// Gets the height of this tile
		/// </summary>
		public int Height { get; }

		/// <summary>
		/// Gets the lava height relative to the tile's height
		/// </summary>
		public float LavaHeight;

		public float LavaViscosity;

		public float AbsoluteLavaHeight
		{ get { return LavaHeight + Height; } }

		/// <summary>
		/// Gets the collection of tile objects on this tile
		/// </summary>
		ICollection<ITileObject> Objects { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Creepy.Tiles.Tile"/> class.
		/// </summary>
		/// <param name="location">Location in the <see cref="Map"/></param>
		public Tile (Point location)
		{
			Location = location;
		}
	}
}