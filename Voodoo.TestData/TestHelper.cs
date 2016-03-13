using System;
using System.Collections.Generic;
using System.Linq;

namespace Voodoo.TestData
{
	public static class TestHelper
	{
		private static readonly object locker = new object();
		private static Randomizer randomizer;
		internal static RandomDataGenerator generator;
		internal static Random random;

		public static Randomizer Randomizer
		{
			get
			{
				lock (locker)
				{
					return randomizer ?? (randomizer = new Randomizer());
				}
			}
		}

		public static RandomDataGenerator Data
		{
			get
			{
				lock (locker)
				{
					return generator ?? (generator = new RandomDataGenerator());
				}
			}
		}

		public static Random Random
		{
			get
			{
				lock (locker)
				{
					return random ?? (random = new Random());
				}
			}
		}

		public static void SetRandomDataSeed(int seed)
		{
			random = new Random(seed);
		}
	}
}