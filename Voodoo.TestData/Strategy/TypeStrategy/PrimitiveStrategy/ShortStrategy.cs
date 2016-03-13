namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class ShortStrategy : RangedGenerationStrategies<short>
	{
		public ShortStrategy()
		{
			MinValue = 0;
			MaxValue = short.MaxValue;
		}

		public override short GenerateValue()
		{			
			return TestHelper.Data.Int(MinValue.To<int>(), MaxValue.To<int>()).To<short>();
		}
	}
}