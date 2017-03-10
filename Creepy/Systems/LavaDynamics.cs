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

		public void Update (GameTime gameTime)
		{
			updateDeltas (gameTime.ElapsedGameTime);
		}

		void clearDeltas ()
		{
			for (int ix = 0; ix < Map.Size.Width; ix++)
				for (int iy = 0; iy < Map.Size.Height; iy++)
					lavaDelta [ix, iy] = 0;
		}

		public const float ViscosityThreshold = 0.3f;

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

		public void Initialize ()
		{
			lavaDelta = new float[Map.Size.Width, Map.Size.Height];
		}

		public Map Map { get; }

		public bool Enabled { get; set; }

		public int UpdateOrder { get { return 0; } }

		public event EventHandler<EventArgs> EnabledChanged;

		public event EventHandler<EventArgs> UpdateOrderChanged;

		public LavaDynamics (Map map)
		{
			Map = map;
		}
	}
}