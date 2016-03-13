using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class DoubleStrategy : RangedGenerationStrategies<double>
	{
		public DoubleStrategy()
		{
			MinValue = 0;
			MaxValue = Int16.MaxValue;
		}

		public override double GenerateValue()
		{
			return TestHelper.Data.Double(MinValue.To<int>(), MaxValue.To<int>()).To<double>();
		}
	}
}