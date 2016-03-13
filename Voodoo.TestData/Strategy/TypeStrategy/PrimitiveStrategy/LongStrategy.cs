using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class LongStrategy : RangedGenerationStrategies<long>
	{
		public LongStrategy()
		{
			MinValue = 0;
			MaxValue = Int16.MaxValue;
		}

		public override long GenerateValue()
		{
			return TestHelper.Data.Int(MinValue.To<int>(), MaxValue.To<int>()).To<long>();
		}
	}
}