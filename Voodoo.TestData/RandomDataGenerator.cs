using System;
using System.Linq;
using System.Text;
using Voodoo.TestData.Builders;

namespace Voodoo.TestData
{
	public class RandomDataGenerator
	{
		public RandomDataGenerator()
		{
			RandomData = new RandomSeedData();
		}

		public RandomSeedData RandomData { get; set; }

		private Random rnd
		{
			get { return TestHelper.Random; }
		}

		public RandomPerson Person()
		{
			return new PersonBuilder().WithAgeRange(AgeRange.Adult).Build(RandomData);
		}

		public RandomAddress Address()
		{
			return new AddressBuilder().Build(RandomData);
		}

		public string Grocery()
		{
			return RandomData.groceries.RandomElement();
		}

		public string GetAdjective()
		{
			return RandomData.adjectives.RandomElement();
		}

		public string GetComment()
		{
			return RandomData.adjectives.RandomElement();
		}

		public int Int(int minVal, int maxVal)
		{
			var num = rnd.Next(minVal, maxVal);
			if (num > maxVal)
				num = maxVal;
			return num;
		}

		public double Double(int minVal, int maxVal)
		{
			double num = rnd.Next(minVal, maxVal);
			num = num + rnd.NextDouble();
			return num;
		}

		public string GibberishText(int lenght)
		{
			const int startNum = 97;
			const int endNum = 122;
			var sb = new StringBuilder();
			for (var i = 0; i <= lenght - 1; i++)
			{
				var num = Int(startNum, endNum);
				var c = ((char) num);
				sb.Append(c.ToString());
			}
			var ret = sb.ToString();
			return ret;
		}

		public bool Bool()
		{
			var num = Int(1, 2);
			return num == 1;
		}

		public string TextWithFunkySymbols(int lenght)
		{
			var startNum = 32;
			var endNum = 126;
			var sb = new StringBuilder();
			for (var i = 0; i <= lenght - 1; i++)
			{
				var temp = ((char) Int(startNum, endNum)).ToString();
				while ((temp.Equals(">")) || (temp.Equals("<")))
				{
					temp = ((char) Int(startNum, endNum)).ToString();
				}
				sb.Append(temp);
			}
			return sb.ToString();
		}

		public string Characters(int lenght)
		{
			var startNum = 32;
			var endNum = 47;
			var sb = new StringBuilder();
			for (var i = 0; i <= lenght - 1; i++)
			{
				var temp = ((char) Int(startNum, endNum)).ToString();
				while ((temp.Equals(">")) || (temp.Equals("<")))
				{
					temp = ((char) Int(startNum, endNum)).ToString();
				}
				sb.Append(temp);
			}
			return sb.ToString();
		}

		public string NumericString(int length)
		{
			var sb = new StringBuilder();
			for (var i = 0; i < length; i++)
			{
				sb.Append(Int(0, 9).ToString());
			}
			var toReturn = sb.ToString();
			return toReturn;
		}

		public DateTime Date(DateTime minDate, DateTime maxDate)
		{
			var ts = maxDate.Subtract(minDate);
			var num = Int(0, ts.Days);
			return minDate.AddDays(num);
		}

		public DateTime RecentDate()
		{
			return Date(DateTime.Now.AddMonths(-3), DateTime.Now);
		}

		public DateTime DateNowPlusOrMinusOneMonth()
		{
			return Date(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1));
		}

		public string PhoneNumber(bool includeAreaCode)
		{
			var phoneNumber = "";
			if (includeAreaCode)
				phoneNumber += Int(2, 9) + NumericString(2);
			phoneNumber += Int(1, 9) + NumericString(6);
			return phoneNumber;
		}

		public string Text(int minLength = 0, int maxLength = int.MaxValue)
		{
			var query = RandomData.comments.AsQueryable();
			if (minLength != 0)
				query = query.Where(c => c.Length >= minLength);
			if (maxLength != int.MaxValue)
				query = query.Where(c => c.Length <= maxLength);

			query = query.OrderBy(c => Guid.NewGuid());

			var result = query.FirstOrDefault();
			if (result == null)
				return LoremIpssum(minLength, maxLength);
			return result;
		}

		public string LoremIpssum(int minLength = 0, int maxLength = int.MaxValue)
		{
			//TODO: jumble
			var min = minLength;
			if (min == 0)
				min = 20;

			var max = maxLength;
			var lorem = RandomData.LoremIpsum.Length;
			if (max >= lorem)
				max = lorem;

			if (maxLength == int.MaxValue)
				max = TestHelper.Data.Int(min, max);

			var result = RandomData.LoremIpsum.Substring(0, max);
			return result;
		}

		internal PersonBuilder PersonBuilder()
		{
			return new PersonBuilder();
		}

		internal AddressBuilder AddressBuilder()
		{
			return new AddressBuilder();
		}

		internal Gender RandomGender()
		{
			var num = Int(1, 2);
			return (Gender) Enum.ToObject(typeof (Gender), num);
		}

		internal AgeRange RandomAgeRange()
		{
			var num = Int(1, 2);
			return (AgeRange) Enum.ToObject(typeof (AgeRange), num);
		}
	}
}