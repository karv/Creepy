using NUnit.Framework;
using Creepy;
using System;

namespace Tests
{
	[TestFixture]
	public class Structs
	{
		[Test]
		public void SizeEqual ()
		{
			var s = new Creepy.Size (1, 3);
			Assert.AreEqual (1, s.Height);
			Assert.AreEqual (3, s.Width);

			var s2 = new Creepy.Size (1, 3);
			Assert.AreEqual (s, s2);

			Assert.True (s == s2);

			var s3 = new Creepy.Size (2, 3);
			Assert.AreNotEqual (s, s3);
			Assert.True (s != s3);
		}

		[Test]
		public void SizeNoNegative ()
		{
			Assert.Throws<Exception> (delegate
			{
				new Size (-1, 0);
			});
			Assert.Throws<Exception> (delegate
			{
				new Size (0, -1);
			});
		}
	}
}