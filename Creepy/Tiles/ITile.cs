﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Creepy
{
	/// <summary>
	/// Represents a tile in the map
	/// </summary>
	public interface ITile
	{
		/// <summary>
		/// Gets the tile location inside the map
		/// </summary>
		Point Location { get; }

		/// <summary>
		/// Gets the height of this tile
		/// </summary>
		int Height { get; }

		/// <summary>
		/// Gets the lava height relative to the tile's height
		/// </summary>
		float LavaHeight { get; }

		/// <summary>
		/// Gets the collection of tile objects on this tile
		/// </summary>
		ICollection<ITileObject> Objects { get; }
	}
}