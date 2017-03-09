
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
}