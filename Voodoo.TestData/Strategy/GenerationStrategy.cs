using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Voodoo.TestData.Strategy
{
	public abstract class GenerationStrategy
	{
	
		public abstract Type Type { get; }

		protected StringLengthAttribute GetStringLength(PropertyInfo info)
		{
			return
				info.GetCustomAttributes(typeof (StringLengthAttribute), true)
					.Cast<StringLengthAttribute>()
					.FirstOrDefault();
		}

		protected RangeAttribute GetRangeAttribute(PropertyInfo info)
		{
			return info.GetCustomAttributes(typeof (RangeAttribute), true).Cast<RangeAttribute>().FirstOrDefault();
		}

		public abstract void SetValue(object @object, PropertyInfo info);
	}

	public abstract class GenerationByNameStrategy : GenerationStrategy
	{
		public virtual int SortOrder => 5;

		public virtual bool Matches(Type type)
		{
			return false;
		}

		public virtual bool Matches(PropertyInfo info)
		{
			return false;
		}

		public virtual bool Matches(Type type, PropertyInfo info)
		{
			return false;
		}
	}


	public abstract class GenerationByTypeStrategy<T> : GenerationStrategy
	{
		public override Type Type => typeof (T);

		public abstract T GenerateValue();

		public override void SetValue(object @object, PropertyInfo info)
		{
			object value = GenerateValue();
			info.SetValue(@object, value, null);
		}
	}

	public abstract class GenerationByNameStrategy<T> : GenerationByNameStrategy
	{
		public override Type Type => typeof (T);

		public abstract T GenerateValue();

		public override void SetValue(object @object, PropertyInfo info)
		{
			object value = GenerateValue();
			info.SetValue(@object, value, null);
		}
	}
}