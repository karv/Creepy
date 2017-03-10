using System;

namespace Creepy
{
	/// <summary>
	/// A 2-dimentional size immutable struct
	/// </summary>
	public struct Size : IEquatable<Size>
	{
		/// <summary>
		/// The height
		/// </summary>
		public readonly int Height;

		/// <summary>
		/// The width
		/// </summary>
		public readonly int Width;

		#region IEquatable implementation

		bool IEquatable<Size>.Equals (Size other)
		{
			return Width == other.Width && Height == other.Height;
		}

		public static bool operator != (Size s1, Size s2)
		{
			return !s1.Equals (s2);
		}

		public static bool operator == (Size s1, Size s2)
		{
			return s1.Equals (s2);
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Creepy.Size"/>.
		/// </summary>
		public override string ToString ()
		{
			return "Size(" + Width + ", " + Height + ")";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Creepy.Size"/> struct.
		/// </summary>
		/// <param name="height">Height.</param>
		/// <param name="width">Width.</param>
		public Size (int height, int width)
		{
			Height = height;
			Width = width;
		}
	}
}