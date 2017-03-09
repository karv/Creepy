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
			throw new NotImplementedException ();
		}

		#endregion

		public Size (int height, int width)
		{
			Height = height;
			Width = width;
		}
	}
}