using System;
using Creepy;
using Creepy.Systems;
using Microsoft.Xna.Framework;
using NUnit.Framework;


namespace Tests
{
	public class TestLavaDynamics
	{
		public LavaDynamics System;

		public Creepy.Map Map;

		public static TimeSpan DefaultDuration = TimeSpan.FromSeconds (1d / 60d);

		[SetUp]
		public void Setup ()
		{
			Map = new Creepy.Map (new Size (100, 100));
			System = new LavaDynamics (Map);

			System.Initialize ();
		}

		public void RunFor (int iterations, TimeSpan durationPerIter)
		{
			var gTime = new GameTime (TimeSpan.Zero, durationPerIter);
			for (int i = 0; i < iterations; i++)
				System.Update (gTime);
		}

		public void RunFor (int iterations)
		{
			RunFor (iterations, DefaultDuration);
		}

		[Test]
		public void TestLavaInTileZero1Sec ()
		{
			Assert.DoesNotThrow (delegate
			{
				Map [0, 0].LavaHeight = 5;
				RunFor (60);
			});
			Assert.True (Map [1, 0].LavaHeight > 0);
			Assert.True (Map [0, 1].LavaHeight > 0);
		}
	}
}