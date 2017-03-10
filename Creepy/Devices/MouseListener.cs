using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Creepy.Devices
{
	/// <summary>
	/// Captures mouse events
	/// </summary>
	public class MouseListener : IGameComponent, IUpdateable
	{
		#region IGameComponent implementation

		MouseState lastMouseState;

		public void Initialize ()
		{
			lastMouseState = Mouse.GetState ();
		}

		#endregion

		#region IUpdateable implementation

		/// <summary>
		/// Occurs when enabled changed.
		/// </summary>
		protected event EventHandler<EventArgs> EnabledChanged;

		/// <summary>
		/// Occurs when update order changed.
		/// </summary>
		protected event EventHandler<EventArgs> UpdateOrderChanged;

		event EventHandler<EventArgs> IUpdateable.EnabledChanged
		{
			add{ EnabledChanged += value;}
			remove { EnabledChanged -= value;}
		}

		event EventHandler<EventArgs> IUpdateable.UpdateOrderChanged
		{
			add{ UpdateOrderChanged += value;}
			remove { UpdateOrderChanged -= value;}
		}

		/// <summary>
		/// Occurs when the mouse is clicked
		/// </summary>
		public event EventHandler<MouseClickEventArgs> Clicked;

		/// <summary>
		/// Occurs when cursor's position changes
		/// </summary>
		public event EventHandler<MouseMoveEventArgs> CursorMoved;

		public void Update (GameTime gameTime)
		{
			var currMouseState = Mouse.GetState ();
			if (currMouseState.LeftButton == ButtonState.Pressed &&
			    lastMouseState.LeftButton == ButtonState.Released)
				Clicked?.Invoke (this, new MouseClickEventArgs (currMouseState));

			if (currMouseState.Position != lastMouseState.Position)
				CursorMoved?.Invoke (this, new MouseMoveEventArgs (lastMouseState.Position, currMouseState.Position));
			lastMouseState = currMouseState;
		}

		bool enabled;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Creepy.Devices.MouseListener"/> is enabled.
		/// </summary>
		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				EnabledChanged?.Invoke (this, EventArgs.Empty);
				enabled = value;
			}
		}

		int updateOrder;

		/// <summary>
		/// Gets or sets the update order.
		/// </summary>
		protected int UpdateOrder
		{
			get
			{
				return updateOrder;
			}
			set
			{
				UpdateOrderChanged?.Invoke (this, EventArgs.Empty);
				updateOrder = value;
			}
		}

		int IUpdateable.UpdateOrder { get { return UpdateOrder; } }

		#endregion
		
	}
}