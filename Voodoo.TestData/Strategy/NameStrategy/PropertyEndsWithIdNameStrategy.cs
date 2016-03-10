using System.Reflection;

namespace Voodoo.TestData.Strategy.NameStrategy
{
	public class PropertyEndsWithIdNameStrategy : GenerationByNameStrategy<int>
	{
		public override int SortOrder
		{
			get { return 4; }
		}

		public override bool Matches(PropertyInfo info)
		{
			var name = info.Name;
			return name.ToLower().EndsWith("id");
		}

		public override int GenerateValue()
		{
			return 0;
		}

		public override void SetValue(object @object, PropertyInfo info)
		{
		}
	}
}