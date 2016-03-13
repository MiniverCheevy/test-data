using System;
using System.Collections.Generic;
using System.Text;

namespace Voodoo.TestData.Models
{
	public class RandomPerson
	{
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append(FullName);
			sb.Append(" ");
			sb.Append(Gender);
			sb.Append(" ");
			sb.Append(AgeRange);
			sb.Append(" ");
			sb.Append(BirthDay.ToShortDateString());
			sb.Append(" ");
			sb.Append(SSN);
			sb.Append(" ");
			sb.Append(Address);

			return sb.ToString();
		}

		public Dictionary<string, string> ToHash()
		{
			var hash = new Dictionary<string, string>();

			hash.Add("BirthDay", "");
			hash.Add("EmailAddress", EmailAddress);
			hash.Add("FirstName", FirstName);
			hash.Add("FullName", FullName);
			hash.Add("Gender", Gender.ToString());
			hash.Add("Initials", Initials);
			hash.Add("LastName", LastName);
			hash.Add("MiddleInitial", MiddleInitial.ToString());
			hash.Add("MiddleName", MiddleName);
			hash.Add("Prefix", Prefix);
			hash.Add("SSN", SSN);
			hash.Add("Suffix", Suffix);
			hash.Add("Address1", Address.Address1);
			hash.Add("City", Address.City);
			hash.Add("County", Address.County);
			hash.Add("Latitude", Address.Latitude.ToString());
			hash.Add("Longitude", Address.Longitude.ToString());
			hash.Add("State", Address.State);
			hash.Add("ZipCode", Address.ZipCode);
			return hash;
		}

		#region Fields

		#endregion

		#region Properties

		public Gender Gender { get; set; }
		public AgeRange AgeRange { get; set; }
		public string EmailAddress { get; set; }
		public string SSN { get; set; }
		public DateTime BirthDay { get; set; }
		public RandomAddress Address { get; set; }

		public string FullName
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(FirstName);
				sb.Append(" ");

				if (MiddleName.Length > 0)
				{
					sb.Append(MiddleName);
					sb.Append(" ");
				}

				sb.Append(LastName);

				if (Suffix.Length > 0)
				{
					sb.Append(" ");
					sb.Append(Suffix);
				}

				return sb.ToString();
			}
		}

		public string FirstAndLastName
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(FirstName);
				sb.Append(" ");
				sb.Append(LastName);
				return sb.ToString();
			}
		}

		public string FirstAndLastNameWithSuffix
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(FirstName);
				sb.Append(" ");
				sb.Append(LastName);

				if (Suffix.Length > 0)
				{
					sb.Append(" ");
					sb.Append(Suffix);
				}

				return sb.ToString();
			}
		}

		public string LastThenFirstName
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(LastName);
				sb.Append(", ");
				sb.Append(FirstName);
				return sb.ToString();
			}
		}

		public string LastNameThenFirstInitial
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(LastName);
				sb.Append(", ");
				sb.Append(FirstName[0]);
				sb.Append(".");
				return sb.ToString();
			}
		}

		public string FirstInitialAndLastName
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(FirstName[0]);
				sb.Append(". ");
				sb.Append(LastName);
				return sb.ToString();
			}
		}

		public string Initials
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append(FirstName[0]);

				if (MiddleName.Length > 0)
				{
					sb.Append(MiddleName[0]);
				}

				sb.Append(LastName[0]);
				return sb.ToString();
			}
		}

		public char? MiddleInitial
		{
			get
			{
				char? middleInitial = null;

				if (MiddleName.Length > 0)
				{
					middleInitial = MiddleName[0];
				}

				return middleInitial;
			}
		}

		public string FirstName { get; set; } = string.Empty;

		public string MiddleName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Suffix { get; set; } = string.Empty;

		public string Prefix { get; set; } = string.Empty;

		#endregion
	}
}