using System;
using System.Reflection;

namespace Voodoo.TestData.Strategy.TypeStrategy
{
    //PrimitiveTypeName ::= NumericTypeName | Boolean | Date | Char | String
    //NumericTypeName ::= IntegralTypeName | FloatingPointTypeName | Decimal
    //IntegralTypeName ::= Byte | Short | Integer | Long
    //FloatingPointTypeName ::= Single | Double
    public abstract class RangedGenerationStrategies<T> : GenerationByTypeStrategy<T>
    {
        public T MaxValue { get; set; }
        public T MinValue { get; set; }

        public override void SetValue(object @object, PropertyInfo info)
        {
            var rangeAttribute = GetRangeAttribute(info);
            if (rangeAttribute != null)
            {
                if (rangeAttribute.Maximum != null)
                    MaxValue = To<T>(rangeAttribute.Maximum);
                if (rangeAttribute.Minimum != null)
                    MinValue = To<T>(rangeAttribute.Minimum);
            }

            base.SetValue(@object, info);
        }
    }

    public class ByteStrategy : RangedGenerationStrategies<Byte>
    {
        public ByteStrategy()
        {
            MinValue = 0;
            MaxValue = byte.MaxValue;
        }

        public override byte GenerateValue()
        {
            return To<byte>(TestHelper.Data.Int(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class ShortStrategy : RangedGenerationStrategies<short>
    {
        public ShortStrategy()
        {
            MinValue = 0;
            MaxValue = short.MaxValue;
        }

        public override short GenerateValue()
        {
            return To<short>(TestHelper.Data.Int(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class IntStrategy : RangedGenerationStrategies<int>
    {
        public IntStrategy()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public override int GenerateValue()
        {
            return To<int>(TestHelper.Data.Int(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class LongStrategy : RangedGenerationStrategies<long>
    {
        public LongStrategy()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public override long GenerateValue()
        {
            return To<long>(TestHelper.Data.Int(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class SingleStrategy : RangedGenerationStrategies<Single>
    {
        public SingleStrategy()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public override Single GenerateValue()
        {
            return To<Single>(TestHelper.Data.Double(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class DoubleStrategy : RangedGenerationStrategies<Double>
    {
        public DoubleStrategy()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public override Double GenerateValue()
        {
            return To<Double>(TestHelper.Data.Int(To<int>(MinValue), To<int>(MaxValue)));
        }
    }

    public class DecimalStrategy : RangedGenerationStrategies<Decimal>
    {
        public DecimalStrategy()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public override Decimal GenerateValue()
        {
            var result = To<Decimal>(TestHelper.Data.Double(To<int>(MinValue), To<int>(MaxValue)));
            result = decimal.Round(result, 2);
            return result;
        }
    }

    public class DateStrategy : RangedGenerationStrategies<DateTime>
    {
        public DateStrategy()
        {
            MinValue = DateTime.Now.AddMonths(-1);
            MaxValue = DateTime.Now.AddMonths(1);
        }

        public override DateTime GenerateValue()
        {
            return TestHelper.Data.Date(MinValue, MaxValue);
        }
    }

    public class BoolStrategy : GenerationByTypeStrategy<bool>
    {
        public override bool GenerateValue()
        {
            return TestHelper.Data.Bool();
        }
    }
}