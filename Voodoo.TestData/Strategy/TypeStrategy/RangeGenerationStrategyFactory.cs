using System;
using System.ComponentModel.DataAnnotations;
using Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy;

namespace Voodoo.TestData.Strategy.TypeStrategy
{
	public class RangeGenerationStrategyFactory
	{
		public static object GetStrategyForRangeAttribute(RangeAttribute range)
		{
			var min = range.Minimum;
			var max = range.Maximum;
			var test = min ?? max;
			if (test == null)
				return null;

			if (test is byte)
				return
					new ByteStrategy
					{
						MinValue = min?.To<byte>() ?? byte.MinValue,
						MaxValue = max?.To<byte>() ?? byte.MaxValue
					}.GenerateValue();
			if (test is short)
				return
					new ShortStrategy
					{
						MinValue = min?.To<short>() ?? short.MinValue,
						MaxValue = max?.To<short>() ?? short.MaxValue,
					}.GenerateValue();

			if (test is int)
				return
					new IntStrategy
					{
						MinValue = min?.To<int>() ?? int.MinValue,
						MaxValue = max?.To<int>() ?? Int16.MaxValue
					}.GenerateValue();

			if (test is long)
				return
					new LongStrategy
					{
						MinValue = min?.To<long>() ?? long.MinValue,
						MaxValue = max?.To<long>() ?? long.MaxValue
					}.GenerateValue();

			if (test is float)
				return
					new SingleStrategy
					{
						MinValue = min?.To<float>() ?? float.MinValue,
						MaxValue = max?.To<float>() ?? float.MaxValue
					}.GenerateValue();

			if (test is double)
				return
					new DoubleStrategy
					{
						MinValue = min?.To<double>() ?? double.MinValue,
						MaxValue = max?.To<double>() ?? double.MaxValue
					}.GenerateValue();

			if (test is decimal)
				return
					new DecimalStrategy
					{
						MinValue = min?.To<decimal>() ?? decimal.MinValue,
						MaxValue = max?.To<decimal>() ?? decimal.MaxValue
					}.GenerateValue();

			if (test is DateTime)
				return
					new DateStrategy
					{
						MinValue = min?.To<DateTime>() ?? DateTime.Parse("1/1/1950"),
						MaxValue = max?.To<DateTime>() ?? DateTime.Parse("1/1/2050")
					}.GenerateValue();


			return null;
		}
	}
}