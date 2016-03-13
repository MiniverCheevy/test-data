using System;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
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
}