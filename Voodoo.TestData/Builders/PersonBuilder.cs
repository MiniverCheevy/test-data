using System;
using System.Collections.Generic;

namespace Voodoo.TestData.Builders
{
	public class PersonBuilder
	{
		private readonly string emailSuffix = "@mailinator.com";
		private AgeRange? ageRange;
		private Gender? gender;

		public PersonBuilder WithGender(Gender g)
		{
			gender = g;
			return this;
		}

		public PersonBuilder WithAgeRange(AgeRange a)
		{
			ageRange = a;
			return this;
		}

		public RandomPerson Build(RandomSeedData RandomData)
		{
			var result = new RandomPerson();

			if (gender != null)
				result.Gender = gender.Value;
			else
				result.Gender = TestHelper.Data.RandomGender();

			if (ageRange != null)
				result.AgeRange = ageRange.Value;
			else
				result.AgeRange = TestHelper.Data.RandomAgeRange();

			List<string> nameList;
			if (result.Gender == Gender.Male)
				nameList = RandomData.firstMale;
			else
				nameList = RandomData.firstFemale;

			result.FirstName = nameList.RandomElement();


			result.LastName = RandomData.lastNames.RandomElement();

			result.Address = new AddressBuilder().Build(RandomData);
			var minYear = 0;
			var maxYear = 0;
			if (result.AgeRange == AgeRange.Adult)
			{
				minYear = DateTime.Now.Year - 60;
				maxYear = DateTime.Now.Year - 18;
			}
			else
			{
				minYear = DateTime.Now.Year - 18;
				maxYear = DateTime.Now.Year;
			}

			result.BirthDay = TestHelper.Data.Date(new DateTime(minYear, 1, 1), new DateTime(maxYear, 1, 1));

			result.SSN = TestHelper.Data.NumericString(9);

			result.EmailAddress = string.Format("{0}.{1}{2}", result.FirstName.ToLower(), result.LastName.ToLower(),
				emailSuffix);

			return result;
		}
	}
}