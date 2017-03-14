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
		HashSet<TrainStationTileObject> Nodos;

		public void Conectar(INetworkNode inicio, INetworkNode fin){
			Vias.Add(new Railroad(this, inicio, fin));
			Nodos.Add (inicio);
			Nodos.Add (fin);
		}

		public void BorrarVia(Railroad via){
			Vias.Remove (via);
		}

		public TrainNetwork(){

		}
	}
}