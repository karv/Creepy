using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
			if (currMouseState.Position != lastMouseState.Position)
				CursorMoved?.Invoke (this, new MouseMoveEventArgs (lastMouseState.Position, currMouseState.Position));


			if (currMouseState.LeftButton == ButtonState.Pressed &&
			    lastMouseState.LeftButton == ButtonState.Released)
			{
				var eventType = currMouseState.LeftButton == ButtonState.Pressed ? 
					EventType.ButtonPressed : 
					EventType.ButtonReleased;
				var newEntry = new EventEntry (DateTime.Now, eventType, currMouseState);
				historial.Add (newEntry);
			}

			if (lastEvent.Type == EventType.ButtonPressed && lastEvent.Time + DoubleClickThreshold < DateTime.Now)
			{
				// user clicked
				onClick (currMouseState);
			}
			lastMouseState = currMouseState;
		}

		void onClick (MouseState currMouseState)
		{
			Clicked?.Invoke (this, new MouseClickEventArgs (currMouseState));
			clearHistory ();
		}

		void clearHistory ()
		{
			historial.Clear ();
			historial.Add (new EventEntry (DateTime.Now, EventType.ButtonReleased, Mouse.GetState ()));
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
			public readonly EventType Type;
			public readonly MouseState MouseState;

			public EventEntry (DateTime time, EventType type, MouseState state)
			{
				Time = time;
				Type = type;
				MouseState = state;
			}
		}

		public MouseListener ()
		{
			const int predetMaxEvents = 10;
			historial = new List<EventEntry> (predetMaxEvents);
			DoubleClickThreshold = TimeSpan.FromMilliseconds (100);
		}
	}
}