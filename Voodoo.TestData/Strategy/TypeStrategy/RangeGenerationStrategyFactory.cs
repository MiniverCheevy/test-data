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

            if (test is Byte)
                return
                    new ByteStrategy
                        {
                            MinValue = min == null ? byte.MinValue : (Byte) min,
                            MaxValue = max == null ? byte.MinValue : (Byte) max
                        }.GenerateValue();
            else if (test is short)
                return
                    new ShortStrategy
                        {
                            MinValue = min == null ? short.MinValue : (short) min,
                            MaxValue = max == null ? short.MaxValue : (short) max
                        }.GenerateValue();

            else if (test is int)
                return
                    new IntStrategy
                        {
                            MinValue = min == null ? int.MinValue : (int) min,
                            MaxValue = max == null ? int.MaxValue : (int) max
                        }.GenerateValue();

            else if (test is long)
                return
                    new LongStrategy
                        {
                            MinValue = min == null ? long.MinValue : (long) min,
                            MaxValue = max == null ? long.MaxValue : (long) max
                        }.GenerateValue();

            else if (test is Single)
                return
                    new SingleStrategy
                        {
                            MinValue = min == null ? Single.MinValue : (Single) min,
                            MaxValue = max == null ? Single.MaxValue : (Single) max
                        }.GenerateValue();

            else if (test is Double)
                return
                    new DoubleStrategy
                        {
                            MinValue = min == null ? Double.MinValue : (Double) min,
                            MaxValue = max == null ? Double.MaxValue : (Double) max
                        }.GenerateValue();

            else if (test is Decimal)
                return
                    new DecimalStrategy
                        {
                            MinValue = min == null ? Decimal.MinValue : (Decimal) min,
                            MaxValue = max == null ? Decimal.MaxValue : (Decimal) max
                        }.GenerateValue();

            else if (test is DateTime)
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