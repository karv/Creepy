using System;

namespace Creepy
{
	public struct Size : IEquatable<Size>
	{
		public readonly int Height;
		public readonly int Width;

		#region IEquatable implementation

		bool IEquatable<Size>.Equals (Size other)
		{
			return Width==other.Width&&Height==other.Height;
		}

		public static bool operator != ( Size s1, Size s2 )
		{
			return !s1.Equals(s2);
		}

		public static bool operator == ( Size s1, Size s2 )
		{
			return s1.Equals(s2);
		}

		#endregion

		public Size (int height, int width)
		{
			Height = height;
			Width = width;
		}

		public string ToString(){
			return "Size("+Width+", "+Height+")";
		}
	}
}