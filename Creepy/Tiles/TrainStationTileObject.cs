namespace Creepy
{
	public class TrainStationTileObject : ITileObject
	{
		/// <summary>
		/// Gets the tile where this object belongs
		/// </summary>
		public ITile Tile { get; }

		/// <summary>
		/// Gets the train network
		/// </summary>
		/// <value>The network.</value>
		public TrainNetwork Network { get; }
	}
}