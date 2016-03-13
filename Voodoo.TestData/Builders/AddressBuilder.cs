using System.Text;
using Voodoo.TestData.Models;

namespace Voodoo.TestData.Builders
{
	public class AddressBuilder
	{
		public RandomAddress Build(RandomSeedData randomData)
		{
			var toReturn = new RandomAddress();
			var num = 0;
			var length = 0;

			num = TestHelper.Data.Int(0, randomData.ZipCodes.Count - 1);
			var csz = randomData.ZipCodes[num];
			toReturn.City = csz.City;
			toReturn.County = csz.County;
			toReturn.ZipCode = csz.ZipCode;
			toReturn.Latitude = csz.Latitude;
			toReturn.Longitude = csz.Longitude;
			toReturn.State = csz.State;

			num = TestHelper.Data.Int(1, 10);


			switch (num)
			{
				case 1:
					length = 2;
					break;

				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					length = 3;
					break;

				case 7:
				case 8:
				case 9:
				case 10:
					length = 4;
					break;
			}

			var sb = new StringBuilder();
			sb.Append(TestHelper.Data.Int(1, 9).ToString());
			sb.Append(TestHelper.Data.NumericString(length - 1));
			sb.Append(" ");

			sb.Append(randomData.StreetParts1.RandomElement());
			sb.Append(" ");

			sb.Append(randomData.StreetParts2.RandomElement());
			sb.Append(" ");

			sb.Append(randomData.StreetParts3.RandomElement());
			sb.Append(" ");

			toReturn.Address1 = sb.ToString();

			if (TestHelper.Data.Int(1, 9) > 6)
				toReturn.Address2 = string.Format("{0} {1}", randomData.Address2Parts.RandomElement(),
					TestHelper.Data.Int(1, 10000));


			return toReturn;
		}
	}
}