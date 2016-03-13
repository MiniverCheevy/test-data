namespace Voodoo.TestData.Models
{
	public struct CityStateZip
	{
		public string City;
		public string County;
		public decimal Latitude;
		public decimal Longitude;
		public string State;
		public string ZipCode;

		public CityStateZip(string s)
		{
			var ary = s.Split(',');
			ZipCode = ary[0];
			City = ary[1];
			State = ary[2];
			Latitude = decimal.Parse(ary[3]);
			Longitude = decimal.Parse(ary[4]);
			County = ary[5];
		}
	}
}