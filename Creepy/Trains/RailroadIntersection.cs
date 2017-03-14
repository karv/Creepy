using System;
using Microsoft.Xna.Framework;

namespace Creepy.Trains
{
	public class RailroadIntersection:INetworkNode
	{
		public Point Location { get; private set;}

		public RailroadIntersection (float x, float y)
		{
			Location = new Point ((int)Math.Round(x), (int)Math.Round(y));
		}
	}
}

