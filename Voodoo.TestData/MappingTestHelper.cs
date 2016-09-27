using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voodoo.TestData
{
	public class MappingTesterHelper<TSource, TTarget>
	{
		public PropertyInfo[] SourceProperties => typeof (TSource).GetProperties().ToArray();

	    public PropertyInfo[] TargetProperties => typeof (TTarget).GetProperties().ToArray();

	    public PropertyInfo[] CommonProperties
		{
			get
			{
				var sourceProperties = SourceProperties.Where(c => c.PropertyType.IsScalar()).Select(c => c.Name).ToArray();
				var targetProperties = TargetProperties.Where(c => c.PropertyType.IsScalar()).Select(c => c.Name).ToArray();
				var common = sourceProperties.Intersect(targetProperties).ToArray();
				return SourceProperties.Where(c => common.Contains(c.Name)).ToArray();
			}
		}

		public void Compare(TSource source, TTarget message, string[] excludedProperties)
		{
			var propertiesToCheck = CommonProperties.Where(c => !excludedProperties.Contains(c.Name)).ToArray();
			foreach (var property in propertiesToCheck)
			{
				var original = property.GetValue(source, null);
				var mappedProperty = TargetProperties.First(c => c.Name == property.Name);
				var mapped = mappedProperty.GetValue(message, null);
				if (original.To<DateTime?>().HasValue)
				{
					//compensate for sql to .net DateTime precicision issue at ms level
					var orig = original.To<DateTime>();
					var map = mapped.To<DateTime>();

					var origString = $"{orig.ToShortDateString()} {orig.ToShortTimeString()}";
					var mapString = $"{map.ToShortDateString()} {map.ToShortTimeString()}";
                    Assert.AreEqual(origString,mapString, property.Name);
				}
				else
                    Assert.AreEqual(original, mapped, property.Name);
			}
			var sourceCollections =
				SourceProperties.Where(
					c =>
						c.PropertyType.IsEnumerable() && !excludedProperties.Contains(c.Name) &&
						!c.PropertyType.IsScalar()).ToArray();
			foreach (var property in sourceCollections)
			{
				var collection = property.GetValue(source, null);
				Assert.IsNotNull(collection,
				    $"{property.Name} is an uninitialized collection in entity");
			}
			var targetCollections =
				TargetProperties.Where(
					c =>
						c.PropertyType.IsEnumerable() && !excludedProperties.Contains(c.Name) &&
						!c.PropertyType.IsScalar()).ToArray();
			foreach (var property in targetCollections)
			{
				var collection = property.GetValue(message, null);
                Assert.IsNotNull(collection, $"{property.Name} is an uninitialized collection in entity");
			}
		}
	}
}