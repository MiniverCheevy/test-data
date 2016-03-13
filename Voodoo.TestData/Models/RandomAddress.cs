using System.Text;

namespace Voodoo.TestData.Models
{
	public class RandomAddress
	{
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public string County { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append(Address1);
			sb.Append(" ");
			sb.Append(City);
			sb.Append(", ");
			sb.Append(State);
			sb.Append(" ");
			sb.Append(ZipCode);

			return sb.ToString();
		}
	}
}