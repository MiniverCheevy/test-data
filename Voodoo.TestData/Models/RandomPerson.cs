using System;
using System.Collections.Generic;
using System.Text;

namespace Voodoo.TestData.Models
{
	public class RandomPerson
	{
		public override string ToString() => this.ToDebugString();
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

		//public Department Department { get; set; }
		public int? DivisionId { get; set; }
		//public Division Division { get; set; }
		
		//public List<User> Supervisors { get; set; }
		//public List<User> DirectReports { get; set; }
		public string EmployeeNumber { get; set; }
		public DateTime? HireDate { get; set; }
		public string JobTitle { get; set; }		
		public bool IsActive { get; set; }

	}
}