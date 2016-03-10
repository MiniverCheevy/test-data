using System;
using System.Collections.Generic;
using System.Reflection;

namespace Voodoo.TestData.Strategy.TypeStrategy
{
	public class DefaultStringGenerationStrategy : GenerationByTypeStrategy<string>
	{
		public const string SSN = "SSN";
		public const string FirstName = "FirstName";
		public const string LastName = "LastName";
		public const string MiddleInitial = "MiddleInitial";
		public const string MiddleName = "MiddleName";
		public const string Prefix = "Prefix";
		public const string EmailAddress = "EmailAddress";
		public const string Address1 = "Address1";
		public const string Address2 = "Address2";
		public const string City = "City";
		public const string County = "County";
		public const string State = "State";
		public const string ZipCode = "ZipCode";
		public const string PhoneNumber = "PhoneNumber";
		public const string FullName = "FullName";
		public const string UserName = "UserName";
		public const string BirthDay = "BirthDay";
		public const string Gender = "Gender";
		public const string Initials = "Initials";
		public const string Suffix = "Suffix";
		public const string Date = "Date";
		public const string Number = "Number";
		public const string Latitude = "Latitude";
		public const string Longitude = "Longitude";
		public const string NickName = "NickName";
		private RandomDataGenerator _generator;
		private RandomPerson _person;

		public DefaultStringGenerationStrategy()
		{
		}

		public DefaultStringGenerationStrategy(RandomPerson person)
		{
			Person = person;
		}

		public RandomDataGenerator Generator
		{
			get { return _generator ?? (_generator = new RandomDataGenerator()); }
			set { _generator = value; }
		}

		public RandomPerson Person
		{
			get { return _person ?? (_person = TestHelper.Data.Person()); }
			set { _person = value; }
		}

		public object[] CollectAllAttributes<T>()
		{
			var listOfAttributes = new List<object>();
			foreach (var propertyInfo in typeof (T).GetProperties())
			{
				listOfAttributes.AddRange(propertyInfo.GetCustomAttributes(false));
			}
			return listOfAttributes.ToArray();
		}

		//RangeAttribute 
		//StringLengthAttribute 


		//mvc data-val DataAnnotationsModelValidatorProvider


		public override string GenerateValue()
		{
			throw new NotImplementedException();
		}

		public override void SetValue(object @object, PropertyInfo info)
		{
			var name = info.Name;
			var value = string.Format("{0} {1}", Generator.GetAdjective(), Generator.Grocery());
			SetPropertyValue(@object, info, value);
			foreach (var item in TestHelper.Data.RandomData.autofill)
			{
				if (HasMatch(name, item.Value))
				{
					chooseValue(@object, info, item.Key);
					break;
				}
			}
			var stringValue = value;

			var stringLength = GetStringLength(info);
			var range = GetRangeAttribute(info);

			//TODO build this in so values aren't set multiple times
			if (stringLength != null)
			{
				var max = stringLength.MaximumLength == 0 ? int.MaxValue : stringLength.MaximumLength;

				if (stringValue.Length > max)
				{
					stringValue = stringValue.Substring(0, max);
					SetPropertyValue(@object, info, stringValue);
				}
			}
			if (range != null)
			{
				var newValue = RangeGenerationStrategyFactory.GetStrategyForRangeAttribute(range);
				if (newValue != null)
					SetPropertyValue(@object, info, newValue.ToString());
			}
		}

		private void chooseValue(object @object, PropertyInfo info, string key)
		{
			switch (key)
			{
				case SSN:
					SetPropertyValue(@object, info, Person.SSN);
					break;
				case FirstName:
					SetPropertyValue(@object, info, Person.FirstName);
					break;
				case LastName:
					SetPropertyValue(@object, info, Person.LastName);
					break;
				case MiddleInitial:
					SetPropertyValue(@object, info, Person.MiddleInitial.ToString());
					break;
				case MiddleName:
					SetPropertyValue(@object, info, Person.MiddleName);
					break;
				case Prefix:
					SetPropertyValue(@object, info, Person.Prefix);
					break;
				case EmailAddress:
					SetPropertyValue(@object, info, Person.EmailAddress);
					break;
				case Address2:
					SetPropertyValue(@object, info, Person.Address.Address2);
					break;
				case Address1:
					SetPropertyValue(@object, info, Person.Address.Address1);
					break;
				case City:
					SetPropertyValue(@object, info, Person.Address.City);
					break;
				case County:
					SetPropertyValue(@object, info, Person.Address.County);
					break;
				case State:
					SetPropertyValue(@object, info, Person.Address.State);
					break;
				case ZipCode:
					SetPropertyValue(@object, info, Person.Address.ZipCode);
					break;
				case PhoneNumber:
					if (info.PropertyType == typeof (string))
						SetPropertyValue(@object, info, Generator.NumericString(10));
					break;
				case FullName:
					SetPropertyValue(@object, info, Person.FullName);
					break;
				case UserName:
					SetPropertyValue(@object, info, Person.EmailAddress);
					break;
				case BirthDay:
					SetPropertyValue(@object, info, Person.BirthDay.ToShortDateString());
					break;
				case Gender:
					SetPropertyValue(@object, info, Person.Gender.ToString());
					break;
				case Initials:
					SetPropertyValue(@object, info, Person.Initials);
					break;
				case Suffix:
					SetPropertyValue(@object, info, Person.Suffix);
					break;
				case Date:
					SetPropertyValue(@object, info, TestHelper.Data.RecentDate().ToShortDateString());
					break;
				case Number:
					SetPropertyValue(@object, info, TestHelper.Data.Int(1, 100).ToString());
					break;
				case Latitude:
					SetPropertyValue(@object, info, Person.Address.Latitude.ToString());
					break;
				case Longitude:
					SetPropertyValue(@object, info, Person.Address.Longitude.ToString());
					break;
				case NickName:
					SetPropertyValue(@object, info, TestHelper.Data.Grocery());
					break;
				default:
					SetPropertyValue(@object, info, TestHelper.Data.Text());
					break;
			}
		}

		private void SetPropertyValue(object @object, PropertyInfo info, string value)
		{
			info.SetValue(@object, value, null);
		}

		private bool HasMatch(string name, string[] names)
		{
			foreach (var item in names)
			{
				if (name.ToLower().Contains(item))
					return true;
			}
			return false;
		}
	}
}