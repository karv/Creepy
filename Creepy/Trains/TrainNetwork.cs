using Creepy.Tiles;
using Creepy.Trains;
using System.Collections.Generic;

namespace Creepy.Trains
{
	/// <summary>
	/// Manager for a network of trains and stations
	/// </summary>
	public class TrainNetwork
	{
		PairDictionary<TrainStationTileObject, Railroad> Vias;
		HashSet<TrainStationTileObject> Estaciones;

		public void Conectar (TrainStationTileObject inicio, TrainStationTileObject fin)
		{
			Vias [inicio, fin] = new Railroad (this, inicio, fin);
			Estaciones.Add (inicio);
			Estaciones.Add (fin);
		}

		public void BorrarVia (Railroad via)
		{
			Vias.Remove (via.Inicio, via.Fin);
		}

		public void BorrarVia (TrainStationTileObject puntoA, TrainStationTileObject puntoB)
		{
			Vias.Remove (puntoA, puntoB);
		}

		public TrainNetwork ()
		{
			Vias = new PairDictionary<TrainStationTileObject, Railroad> ();
		}
	}
}