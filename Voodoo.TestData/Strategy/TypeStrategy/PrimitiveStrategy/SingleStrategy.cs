using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class SingleStrategy : RangedGenerationStrategies<float>
	{
		public SingleStrategy()
		{
			MinValue = 0;
			MaxValue = Int16.MaxValue;
		}

		public override float GenerateValue()
		{
			return TestHelper.Data.Double(MinValue.To<int>(), MaxValue.To<int>()).To<float>();
		}
	}
}