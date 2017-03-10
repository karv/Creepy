using Microsoft.Xna.Framework;

namespace Creepy.Tiles
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
		Tile Tile { get; }
	}

	/// <summary>
	/// Extensions for <see cref="ITileObject"/>
	/// </summary>
	public static class TileObjectExt
	{
		/// <summary>
		/// Gets the location of this <see cref="ITileObject"/>
		/// </summary>
		public static Point Location (this ITileObject obj)
		{
			return obj.Tile.Location;
		}
	}
}