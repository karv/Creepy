using Microsoft.Xna.Framework;
using Creepy.Trains;

namespace Creepy.Tiles
{
	public class TrainStationTileObject : ITileObject, INetworkNode
	{
		/// <summary>
		/// Gets the tile where this object belongs
		/// </summary>
		public Tile Tile { get; }

		/// <summary>
		/// Gets the train network
		/// </summary>
		/// <value>The network.</value>
		public TrainNetwork Network { get; }

		public Point Location { get; }
	}
}