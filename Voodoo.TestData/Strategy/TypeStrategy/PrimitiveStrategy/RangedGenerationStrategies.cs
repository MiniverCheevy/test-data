using System.Reflection;

namespace Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy
{
	public abstract class RangedGenerationStrategies<T> : GenerationByTypeStrategy<T>
	{
		public T MaxValue { get; set; }
		public T MinValue { get; set; }

		public override void SetValue(object @object, PropertyInfo info)
		{
			var rangeAttribute = GetRangeAttribute(info);
			if (rangeAttribute != null)
			{
				if (rangeAttribute.Maximum != null)
					MaxValue = rangeAttribute.Maximum.To<T>();
				if (rangeAttribute.Minimum != null)
					MinValue = rangeAttribute.Minimum.To<T>();
			}

			base.SetValue(@object, info);
		}
	}
}