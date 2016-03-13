namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public class BoolStrategy : GenerationByTypeStrategy<bool>
	{
		public override bool GenerateValue()
		{
			return TestHelper.Data.Bool();
		}
	}
}