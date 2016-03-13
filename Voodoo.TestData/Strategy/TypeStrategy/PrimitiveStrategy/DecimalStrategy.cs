using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class DecimalStrategy : RangedGenerationStrategies<decimal>
	{
		public DecimalStrategy()
		{
			MinValue = 0;
			MaxValue = Int16.MaxValue;
		}

		public override decimal GenerateValue()
		{			
			var result= TestHelper.Data.Double(MinValue.To<int>(), MaxValue.To<int>()).To<decimal>();
			result = decimal.Round(result, 2);
			return result;
		}
	}
}