namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class ByteStrategy : RangedGenerationStrategies<byte>
	{
		public ByteStrategy()
		{
			MinValue = 0;
			MaxValue = byte.MaxValue;
		}

		public override byte GenerateValue()
		{
			return TestHelper.Data.Int(MinValue.To<int>(), MaxValue.To<int>()).To<byte>();
		}
	}
}