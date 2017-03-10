using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Creepy.Devices
{
	/// <summary>
	/// Captures mouse events
	/// </summary>
	public class MouseListener : IGameComponent, IUpdateable
	{
		MouseState lastMouseState;
		readonly List<EventEntry> historial;

		EventEntry lastEvent { get { return historial [historial.Count - 1]; } }

		TimeSpan doubleClickThreshold;

		/// <summary>
		/// Gets or sets the time to wait after a click to become double
		/// </summary>
		/// <value>The double click threshold.</value>
		public TimeSpan DoubleClickThreshold
		{
			get
			{
				return doubleClickThreshold;
			}
			set
			{
				doubleClickThreshold = value;
				clearHistory ();
			}
		}

		#region IGameComponent implementation

		/// <summary>
		/// Initialize this instance.
		/// </summary>
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

		/// <summary>
		/// Occurs when the mouse double clicked
		/// </summary>
		public event EventHandler<MouseClickEventArgs> DoubleClick;

		/// <summary>
		/// Update
		/// </summary>
		public void Update (GameTime gameTime)
		{
			var currMouseState = Mouse.GetState ();

			// Do not listen when it is not listening
			if (historial.Count == 0)
			if (currMouseState.LeftButton == ButtonState.Pressed)
				return;
			else
			{
				var newEntry = new EventEntry (DateTime.Now, currMouseState);
				historial.Add (newEntry);
			}
			if (currMouseState.Position != lastMouseState.Position)
				CursorMoved?.Invoke (this, new MouseMoveEventArgs (lastMouseState.Position, currMouseState.Position));


			if (currMouseState.LeftButton != lastEvent.Type)
			{
				var newEntry = new EventEntry (DateTime.Now, currMouseState);
				historial.Add (newEntry);
			}

			if (lastEvent.Type == ButtonState.Released &&
			    historial.Count > 1 &&
			    lastEvent.Time + DoubleClickThreshold < DateTime.Now)
			{
				onClick (currMouseState);
			}
			else if (lastEvent.Type == ButtonState.Pressed && historial.Count == 4) // 
			{
				onDoubleClick (currMouseState);
			}

			lastMouseState = currMouseState;
		}

		void onClick (MouseState currMouseState)
		{
			Clicked?.Invoke (this, new MouseClickEventArgs (currMouseState));
			Debug.WriteLine ("Click");
			clearHistory ();
		}

		void onDoubleClick (MouseState currMouseState)
		{
			DoubleClick?.Invoke (this, new MouseClickEventArgs (currMouseState));
			Debug.WriteLine ("2-Click");
			clearHistory ();
		}

		void clearHistory ()
		{
			historial.Clear ();
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

		enum EventType
		{
			ButtonPressed,
			ButtonReleased
		}

		struct EventEntry
		{
			public readonly DateTime Time;

			public ButtonState Type { get { return MouseState.LeftButton; } }

			public readonly MouseState MouseState;

			public EventEntry (DateTime time, MouseState state)
			{
				Time = time;
				MouseState = state;
			}
		}

		public MouseListener ()
		{
			const int predetMaxEvents = 10;
			historial = new List<EventEntry> (predetMaxEvents);
			DoubleClickThreshold = TimeSpan.FromMilliseconds (200);
		}
	}
}