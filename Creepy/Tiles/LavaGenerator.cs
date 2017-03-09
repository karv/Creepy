namespace Creepy
{
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
		public Tile Tile { get; }
	}
}