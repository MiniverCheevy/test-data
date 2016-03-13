using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Voodoo.TestData;

// ReSharper disable CheckNamespace

namespace Voodoo
{
	public static class RandomExtensions
	{

		//http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var elements = source.ToArray();
			for (var i = elements.Length - 1; i >= 0; i--)
			{
				var swapIndex = TestHelper.Random.Next(i + 1);
				yield return elements[swapIndex];
				elements[swapIndex] = elements[i];
			}
		}

		public static T RandomElement<T>(this IEnumerable<T> sourceData)
		{
			var data = sourceData.ToArray();
			var length = data.ToArray().Count();
			var index = TestHelper.Data.Int(0, length - 1);
			var array = data.ToArray();
			return array[index];
		}

		public static object RandomElement(this IEnumerable sourceData)
		{
			var data = new List<object>();
			foreach (var item in sourceData)
			{
				data.Add(item);
			}

			var length = data.ToArray().Count();
			var index = TestHelper.Data.Int(0, length - 1);

			return data[index];
		}

		public static void Randomize(this object @object)
		{
			var randomizer = new Randomizer();
			randomizer.Randomize(@object);

		}
	}
}