using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Creepy.Devices
{
	/// <summary>
	/// Mouse movement event arguments.
	/// </summary>
	[Serializable]
	public sealed class MouseMoveEventArgs : EventArgs
	{
		/// <summary>
		/// The start point relative to screen
		/// </summary>
		public readonly Point Origin;
		/// <summary>
		/// The end point relative to screen
		/// </summary>
		public readonly Point Destination;

		public MouseMoveEventArgs (Point origin, Point destination)
		{
			Origin = origin;
			Destination = destination;
		}
	}
	
}