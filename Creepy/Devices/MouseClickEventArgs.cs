using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Creepy.Devices
{
	/// <summary>
	/// Mouse click event arguments.
	/// </summary>
	[Serializable]
	public sealed class MouseClickEventArgs : EventArgs
	{
		/// <summary>
		/// The location of the click relative to the screen
		/// </summary>
		public Point ClickLocation { get { return new Point (MouseState.X, MouseState.Y); } }

		readonly MouseState MouseState;

		/// <summary>
		/// </summary>
		public MouseClickEventArgs (MouseState state)
		{
			MouseState = state;
		}

		/// <summary>
		/// </summary>
		public MouseClickEventArgs ()
		{
			MouseState = Mouse.GetState ();
		}
	}
	
}