using System;
using NUnit.Framework;
using Creepy;
using Microsoft.Xna.Framework;

namespace Tests
{
	[TestFixture]
	public class Map
	{
		readonly Random _r = new Random ();

		[Test]
		public void TestLocationAssignation ()
		{
			var size = new Size (_r.Next (100), _r.Next (100));
			var map = new Creepy.Map (size);
			for (int ix = 0; ix < size.Width; ix++)
				for (int iy = 0; iy < size.Height; iy++)
				{
					Assert.NotNull (map [ix, iy]);
					Assert.AreEqual (map [ix, iy].Location, new Point (ix, iy));
				}
		}


	}
}