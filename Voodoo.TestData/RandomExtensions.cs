using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Voodoo.TestData;

// ReSharper disable CheckNamespace

namespace Voodoo
{
	public static class RandomExtensions
	{
		public static T RandomElement<T>(this IEnumerable<T> sourceData)
		{
			var length = sourceData.ToArray().Count();
			var index = TestHelper.Data.Int(0, length - 1);
			var array = sourceData.ToArray();
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
	}
}