using System;
using Creepy.Systems;
using Creepy.Tiles;
using Microsoft.Xna.Framework;

namespace Creepy.Systems
{
	/// <summary>
	/// The first Lava Dynamics System.
	/// </summary>
	public class LavaDynamics : ILavaDynamics
	{
		float [,] lavaDelta;

		/// <summary>
		/// The delta ob absolute heights between adyacent tiles. Below this limit, lava won't move, 
		/// even if there is it is not in equilibrium
		/// </summary>
		public const float ViscosityThreshold = 0.3f;

		/// <summary>
		/// Updates the system
		/// </summary>
		public void Update (GameTime gameTime)
		{
			updateDeltas (gameTime.ElapsedGameTime);
			apply ();
		}

		void clearDeltas ()
		{
			for (int ix = 0; ix < Map.Size.Width; ix++)
				for (int iy = 0; iy < Map.Size.Height; iy++)
					lavaDelta [ix, iy] = 0;
		}


		void apply ()
		{
			for (int ix = 0; ix < Map.Size.Width; ix++)
				for (int iy = 0; iy < Map.Size.Height; iy++)
					Map [ix, iy].LavaHeight += lavaDelta [ix, iy];
		}

		void updateDeltas (TimeSpan gameTime)
		{
			clearDeltas ();
			var mins = gameTime.TotalMinutes;
			// To avoid duplications, only check rigth and down
			for (int ix = 0; ix < Map.Size.Width; ix++)
				for (int iy = 0; iy < Map.Size.Height; iy++)
				{
					var aTile = Map [ix, iy];
					Tile bTile;
					if (ix < Map.Size.Width - 1)
					{
						bTile = Map [ix + 1, iy];
						if (aTile.AbsoluteLavaHeight < bTile.AbsoluteLavaHeight)
							tryMoveLava (bTile, aTile);
						else
							tryMoveLava (aTile, bTile);
					}

					if (iy < Map.Size.Height - 1)
					{
						bTile = Map [ix, iy + 1];
						if (aTile.AbsoluteLavaHeight < bTile.AbsoluteLavaHeight)
							tryMoveLava (bTile, aTile);
						else
							tryMoveLava (aTile, bTile);
					}
				}
		}

		void tryMoveLava (Tile fromTile, Tile toTile)
		{
			if (toTile == null)
				throw new ArgumentNullException ("toTile");
			if (fromTile == null)
				throw new ArgumentNullException ("fromTile");

			if (toTile == fromTile)
				throw new InvalidOperationException ();
			
			if (fromTile.AbsoluteLavaHeight < toTile.AbsoluteLavaHeight)
				throw new InvalidOperationException ("Lava cannot go upward");

			if (fromTile.LavaHeight > ViscosityThreshold)
			{
				var detaLavaHeight = fromTile.LavaHeight - toTile.LavaHeight;
				var change = Math.Min (
					             detaLavaHeight / fromTile.LavaViscosity,
					             detaLavaHeight / 2);

				lavaDelta [fromTile.Location.X, fromTile.Location.Y] -= change;
				lavaDelta [toTile.Location.X, toTile.Location.Y] += change;
			}
		}

		/// <summary>
		/// Initializes this system
		/// </summary>
		public void Initialize ()
		{
			lavaDelta = new float[Map.Size.Width, Map.Size.Height];
			Enabled = true;
		}

		/// <summary>
		/// Gets the map
		/// </summary>
		public Map Map { get; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Creepy.Systems.LavaDynamics"/> is enabled.
		/// If not enables, <see cref="Update"/> will be no invoked
		/// </summary>
		public bool Enabled { get; set; }

		/// <summary>
		/// Gets the update order for the game components
		/// </summary>
		public int UpdateOrder { get { return 0; } }

		public event EventHandler<EventArgs> EnabledChanged;

		public event EventHandler<EventArgs> UpdateOrderChanged;

		/// <summary>
		/// Initializes a new instance of the <see cref="Creepy.Systems.LavaDynamics"/> class.
		/// </summary>
		/// <param name="map">Map.</param>
		public LavaDynamics (Map map)
		{
			Map = map;
		}
	}
}