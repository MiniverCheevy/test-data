using System;
using System.Collections.Generic;
using System.Text;

namespace Voodoo.TestData
{
    public class RandomPerson
    {
        #region Fields

        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string middleName = string.Empty;
        private string prefix = string.Empty;
        private string suffix = string.Empty;

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
                sb.Append(firstName);
                sb.Append(" ");

                if (middleName.Length > 0)
                {
                    sb.Append(middleName);
                    sb.Append(" ");
                }

                sb.Append(lastName);

                if (suffix.Length > 0)
                {
                    sb.Append(" ");
                    sb.Append(suffix);
                }

                return sb.ToString();
            }
        }

        public string FirstAndLastName
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(firstName);
                sb.Append(" ");
                sb.Append(lastName);
                return sb.ToString();
            }
        }

        public string FirstAndLastNameWithSuffix
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(firstName);
                sb.Append(" ");
                sb.Append(lastName);

                if (suffix.Length > 0)
                {
                    sb.Append(" ");
                    sb.Append(suffix);
                }

                return sb.ToString();
            }
        }

        public string LastThenFirstName
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(lastName);
                sb.Append(", ");
                sb.Append(firstName);
                return sb.ToString();
            }
        }

        public string LastNameThenFirstInitial
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(lastName);
                sb.Append(", ");
                sb.Append(firstName[0]);
                sb.Append(".");
                return sb.ToString();
            }
        }

        public string FirstInitialAndLastName
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(firstName[0]);
                sb.Append(". ");
                sb.Append(lastName);
                return sb.ToString();
            }
        }

        public string Initials
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(firstName[0]);

                if (middleName.Length > 0)
                {
                    sb.Append(middleName[0]);
                }

                sb.Append(lastName[0]);
                return sb.ToString();
            }
        }

        public char? MiddleInitial
        {
            get
            {
                char? middleInitial = null;

                if (middleName.Length > 0)
                {
                    middleInitial = middleName[0];
                }

                return middleInitial;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(FullName);
            sb.Append(" ");
            sb.Append(Gender.ToString());
            sb.Append(" ");
            sb.Append(AgeRange.ToString());
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
            hash.Add("EmailAddress", this.EmailAddress);
            hash.Add("FirstName", this.firstName);
            hash.Add("FullName", this.FullName);
            hash.Add("Gender", this.Gender.ToString());
            hash.Add("Initials", this.Initials);
            hash.Add("LastName", this.lastName);
            hash.Add("MiddleInitial", this.MiddleInitial.ToString());
            hash.Add("MiddleName", this.middleName);
            hash.Add("Prefix", this.prefix);
            hash.Add("SSN", this.SSN);
            hash.Add("Suffix", this.suffix);
            hash.Add("Address1", this.Address.Address1);
            hash.Add("City", this.Address.City);
            hash.Add("County", this.Address.County);
            hash.Add("Latitude", this.Address.Latitude.ToString());
            hash.Add("Longitude", this.Address.Longitude.ToString());
            hash.Add("State", this.Address.State);
            hash.Add("ZipCode", this.Address.ZipCode);
            return hash;
        }
    }
}