using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Creepy.Devices
{
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

	/// <summary>
	/// Captures mouse events
	/// </summary>
	public class MouseListener : IGameComponent, IUpdateable
	{
		#region IGameComponent implementation

		MouseState lastMouseState;

		public void Initialize ()
		{
			lastMouseState = new MouseState ();
		}

		#endregion

		#region IUpdateable implementation

		public event EventHandler<EventArgs> EnabledChanged;

		public event EventHandler<EventArgs> UpdateOrderChanged;

		public event EventHandler<EventArgs> Clicked;

		public void Update (GameTime gameTime)
		{
			var currMouseState = Mouse.GetState ();
			if (currMouseState.LeftButton == ButtonState.Pressed &&
			    lastMouseState.LeftButton == ButtonState.Released)
			{
				OnClicked (currMouseState);
			}
		}

		protected virtual void OnClicked (MouseState state)
		{
			Clicked?.Invoke (this, new MouseClickEventArgs (state));
		}

		public bool Enabled { get; set; }

		public int UpdateOrder { get; set; }

		#endregion
		
	}
}