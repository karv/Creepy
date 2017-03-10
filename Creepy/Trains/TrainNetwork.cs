using Creepy.Tiles;
using Creepy.Trains;
using System.Collections.Generic;

namespace Creepy.Tiles
{
	/// <summary>
	/// Manager for a network of trains and stations
	/// </summary>
	public class TrainNetwork
	{
		HashSet<Railroad> Vias;
		HashSet<TrainStationTileObject> Estaciones;

		public void Conectar(TrainStationTileObject inicio, TrainStationTileObject fin){
			Vias.Add(new Railroad(this, inicio, fin));
			Estaciones.Add (inicio);
			Estaciones.Add (fin);
		}

		public void BorrarVia(Railroad via){
			Vias.Remove (via);
		}

		public TrainNetwork(){

		}
	}
}