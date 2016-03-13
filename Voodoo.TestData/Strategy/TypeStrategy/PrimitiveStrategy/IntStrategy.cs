using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class IntStrategy : RangedGenerationStrategies<int>
	{
		public IntStrategy()
		{
			MinValue = 0;
			MaxValue = Int16.MaxValue;
		}

		public override int GenerateValue()
		{
			return TestHelper.Data.Int(MinValue.To<int>(), MaxValue.To<int>()).To<int>();
		}
	}
}