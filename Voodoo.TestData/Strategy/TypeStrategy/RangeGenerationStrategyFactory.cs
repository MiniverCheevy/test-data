using System;
using System.ComponentModel.DataAnnotations;

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
						MinValue = min == null ? byte.MinValue : (byte) min,
						MaxValue = max == null ? byte.MinValue : (byte) max
					}.GenerateValue();
			if (test is short)
				return
					new ShortStrategy
					{
						MinValue = min == null ? short.MinValue : (short) min,
						MaxValue = max == null ? short.MaxValue : (short) max
					}.GenerateValue();

			if (test is int)
				return
					new IntStrategy
					{
						MinValue = min == null ? int.MinValue : (int) min,
						MaxValue = max == null ? int.MaxValue : (int) max
					}.GenerateValue();

			if (test is long)
				return
					new LongStrategy
					{
						MinValue = min == null ? long.MinValue : (long) min,
						MaxValue = max == null ? long.MaxValue : (long) max
					}.GenerateValue();

			if (test is float)
				return
					new SingleStrategy
					{
						MinValue = min == null ? float.MinValue : (float) min,
						MaxValue = max == null ? float.MaxValue : (float) max
					}.GenerateValue();

			if (test is double)
				return
					new DoubleStrategy
					{
						MinValue = min == null ? double.MinValue : (double) min,
						MaxValue = max == null ? double.MaxValue : (double) max
					}.GenerateValue();

			if (test is decimal)
				return
					new DecimalStrategy
					{
						MinValue = min == null ? decimal.MinValue : (decimal) min,
						MaxValue = max == null ? decimal.MaxValue : (decimal) max
					}.GenerateValue();

			if (test is DateTime)
				return
					new DateStrategy
					{
						MinValue = min == null ? DateTime.Parse("1/1/1950") : (DateTime) min,
						MaxValue = max == null ? DateTime.Parse("1/1/2050") : (DateTime) max
					}.GenerateValue();


			return null;
		}
	}
}