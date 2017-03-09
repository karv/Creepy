
namespace Creepy
{
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
		public Tile Tile { get; }
	}
}