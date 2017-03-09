using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Creepy
{
	/// <summary>
	/// Represents an object in the tile
	/// </summary>
	public interface ITileObject
	{
		/// <summary>
		/// Gets the tile where this object belongs
		/// </summary>
		/// <value>The tile.</value>
		ITile Tile { get; }
	}

	public class LavaGenerator : ITileObject
	{
		/// <summary>
		/// Gets or sets the lava generation speed
		/// </summary>
		/// <value>The generation speed.</value>
		public float GenerationSpeed { get; set; }

		/// <summary>
		/// Gets the tile where this object belongs
		/// </summary>
		public ITile Tile { get; }
	}

	/// <summary>
	/// represents a tile object that can have population
	/// </summary>
	public class TownTileObject : ITileObject
	{
		/// <summary>
		/// Gets the population of this <see cref="TownTileObject"/>
		/// </summary>
		public int Population { get; protected set; }

		/// <summary>
		/// Gets the tile where this object belongs
		/// </summary>
		public ITile Tile { get; }
	}

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