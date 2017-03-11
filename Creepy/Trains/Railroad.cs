using System;
using Creepy.Tiles;

namespace Creepy.Trains
{
	public class Railroad
	{
		public TrainStationTileObject Inicio;
		public TrainStationTileObject Fin;
		TrainNetwork Network;
		float Distancia;

		public void Split (TrainStationTileObject nuevaEstacion)
		{
			Network.Conectar (nuevaEstacion, Inicio);
			Network.Conectar (nuevaEstacion, Fin);
			Network.BorrarVia (this);
		}

		public Railroad (TrainNetwork network, TrainStationTileObject inicio, TrainStationTileObject fin)
		{
			this.Inicio = inicio;
			this.Fin = fin;
			this.Network = network;
			Distancia = (float)Math.Sqrt (
				Math.Pow (inicio.Tile.Location.X - fin.Tile.Location.X, 2) +
				Math.Pow (inicio.Tile.Location.Y - fin.Tile.Location.Y, 2)
			);
		}
	}
}

