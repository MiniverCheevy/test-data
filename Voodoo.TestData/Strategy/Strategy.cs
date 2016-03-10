using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Voodoo.TestData.Strategy
{
	public abstract class GenerationStrategy
	{
		protected Dictionary<Type, object> _nonNullDefaults = new Dictionary<Type, object>
		{
			{typeof (string), string.Empty},
			{typeof (bool), false},
			{typeof (DateTime), DateTime.MaxValue},
			{typeof (int), 0}
		};

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

		protected TTarget To<TTarget>(object value)
		{
			var type = typeof (TTarget);
			if (value.GetType() == typeof (TTarget))
				return (TTarget) value;
			//else
			//{
			//    try
			//    {
			//        dynamic val = value;
			//        TTarget converted = val;
			//        return converted;
			//    }
			//    catch { };


			//}


			try
			{
				switch (Type.GetTypeCode(typeof (TTarget)))
				{
					case TypeCode.Boolean:
						return (TTarget) (object) Convert.ToBoolean(value);
					case TypeCode.Byte:
						return (TTarget) (object) Convert.ToByte(value);
					case TypeCode.Char:
						return (TTarget) (object) Convert.ToChar(value);
					case TypeCode.DateTime:
						return (TTarget) (object) Convert.ToDateTime(value);
					case TypeCode.Decimal:
						return (TTarget) (object) Convert.ToDecimal(value);
					case TypeCode.Double:
						return (TTarget) (object) Convert.ToDouble(value);
					case TypeCode.Int16:
						return (TTarget) (object) Convert.ToInt16(value);
					case TypeCode.Int32:
						return (TTarget) (object) Convert.ToInt32(value);
					case TypeCode.Int64:
						return (TTarget) (object) Convert.ToInt64(value);
					case TypeCode.SByte:
						return (TTarget) (object) Convert.ToSByte(value);
					case TypeCode.Single:
						return (TTarget) (object) Convert.ToSingle(value);
					case TypeCode.String:
						return (TTarget) (object) Convert.ToString(value);
					case TypeCode.UInt16:
						return (TTarget) (object) Convert.ToUInt16(value);
					case TypeCode.UInt32:
						return (TTarget) (object) Convert.ToUInt32(value);
					case TypeCode.UInt64:
						return (TTarget) (object) Convert.ToUInt64(value);
					case TypeCode.DBNull:
					case TypeCode.Empty:
					default:
						break;
				}
			}
			catch
			{
			}
			return default(TTarget);
		}
	}

	public abstract class GenerationByNameStrategy : GenerationStrategy
	{
		public virtual int SortOrder
		{
			get { return 5; }
		}

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
		public override Type Type
		{
			get { return typeof (T); }
		}

		public abstract T GenerateValue();

		public override void SetValue(object @object, PropertyInfo info)
		{
			object value = GenerateValue();
			info.SetValue(@object, value, null);
		}
	}

	public abstract class GenerationByNameStrategy<T> : GenerationByNameStrategy
	{
		public override Type Type
		{
			get { return typeof (T); }
		}

		public abstract T GenerateValue();

		public override void SetValue(object @object, PropertyInfo info)
		{
			object value = GenerateValue();
			info.SetValue(@object, value, null);
		}
	}
}