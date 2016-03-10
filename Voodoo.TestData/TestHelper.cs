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
					if (randomizer == null)
					{
						randomizer = new Randomizer();
					}
					return randomizer;
				}
			}
		}

		public static RandomDataGenerator Data
		{
			get
			{
				lock (locker)
				{
					if (generator == null)
					{
						generator = new RandomDataGenerator();
					}
					return generator;
				}
			}
		}

		public static Random Random
		{
			get
			{
				lock (locker)
				{
					if (random == null)
					{
						random = new Random();
					}
					return random;
				}
			}
		}

		//private static void init()
		//{
		//    if (_random == null)
		//        SetRandomDataSeed(12345);

		//    if (_generator == null)
		//        _generator = new RandomDataGenerator();
		//}

		//http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var elements = source.ToArray();
			for (var i = elements.Length - 1; i >= 0; i--)
			{
				var swapIndex = Random.Next(i + 1);
				yield return elements[swapIndex];
				elements[swapIndex] = elements[i];
			}
		}

		public static void SetRandomDataSeed(int seed)
		{
			random = new Random(seed);
		}
	}
}