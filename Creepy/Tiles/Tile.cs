using System;
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

		/// <summary>
		/// How hard is (locally) for the lava to move to another tile
		/// </summary>
		public float LavaViscosity;

		/// <summary>
		/// Gets the tile height plus the lava height
		/// </summary>
		public float AbsoluteLavaHeight
		{ get { return LavaHeight + Height; } }

		readonly List<ITileObject> objects;

		/// <summary>
		/// Gets the collection of tile objects on this tile
		/// </summary>
		IEnumerable<ITileObject> Objects 
		{ get { return objects; } }

		/// <summary>
		/// Gets the number of <see cref="ITileObject"/> in this tile.
		/// </summary>
		public int ObjectsCount
		{ get { return objects.Count; } }

		/// <summary>
		/// Adds a tile-less tile-object into this tile 
		/// </summary>
		public void Add (ITileObject obj)
		{
			if (obj == null)
				throw new ArgumentNullException ("obj");
			if (obj.Tile != null)
				throw new InvalidOperationException ("Cannot add an object in a tile.");
		}

		/// <summary>
		/// </summary>
		public Tile ()
		{
			objects = new List<ITileObject> ();
		}
	}
}