using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Voodoo.TestData.Models;

namespace Voodoo.TestData
{
	public class RandomSeedData
	{
		public RandomSeedData()
		{
			var path = Environment.CurrentDirectory;
			LastNames = ReadFileLineByLine("last.txt");
			FirstMale = ReadFileLineByLine("male.txt");
			FirstFemale = ReadFileLineByLine("female.txt");
			Comments = ReadFileLineByLine("comment.txt");
			Bussiness = ReadFileLineByLine("business.txt");
			Industry = ReadFileLineByLine("Industry.txt");
			Adjectives = ReadFileLineByLine("Adjective.txt");
			Groceries = ReadFileLineByLine("grocery.txt");
			LoremIpsum = ReadFile("LoremIpsum.txt");
			Address2Parts = ReadFileLineByLine("AddressLine2.txt");
			ZipCodes = new List<CityStateZip>();
			StreetParts1 = new List<string>();
			StreetParts2 = new List<string>();
			StreetParts3 = new List<string>();
			Autofill = new Dictionary<string, string[]>();
			var zipTemp = ReadFileLineByLine("zip5.txt");
			foreach (var s in zipTemp)
			{
				ZipCodes.Add(new CityStateZip(s));
			}


			var streetTemp = ReadFileLineByLine("streetparts.txt");
			foreach (var s in streetTemp)
			{
				var ary = s.Split(',');
				StreetParts1.Add(ary[0]);
				StreetParts2.Add(ary[1]);
				StreetParts3.Add(ary[2]);
			}

			var config = ReadFileLineByLine("AutoFill.txt");
			foreach (var item in config)
			{
				var first = item.Split(':');
				if (first.Length == 2)
				{
					var key = first[0];
					var second = first[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
					var trimmed = new List<string>();
					foreach (var element in second)
					{
						trimmed.Add(element.ToLower().Trim());
					}
					trimmed.Add(key.ToLower());
					Autofill.Add(key, trimmed.ToArray());
				}
			}
		}

		public List<string> Address2Parts { get; set; }
		public List<string> Adjectives { get; set; }
		public Dictionary<string, string[]> Autofill { get; set; }
		public List<string> Bussiness { get; set; }
		public List<string> Comments { get; set; }
		public List<string> FirstFemale { get; set; }
		public List<string> FirstMale { get; set; }
		public List<string> Groceries { get; set; }
		public List<string> Industry { get; set; }
		public List<string> LastNames { get; set; }
		public string LoremIpsum { get; set; }
		public List<string> PrefixFemale { get; set; }
		public List<string> PrefixMale { get; set; }
		public List<string> StreetParts1 { get; set; }
		public List<string> StreetParts2 { get; set; }
		public List<string> StreetParts3 { get; set; }
		public List<string> Suffix { get; set; }
		public List<string> UsedNames { get; set; }
		public List<CityStateZip> ZipCodes { get; set; }

		public string ReadFile(string name)
		{
			var fileName = name;


			string result;
			var assembly = Assembly.GetExecutingAssembly();
			using (var stream = assembly.GetManifestResourceStream(string.Format("Voodoo.TestData.Data.{0}", name)))
			{
				using (var streamReader = new StreamReader(stream))
				{
					result = streamReader.ReadToEnd();
					streamReader.Close();
				}
			}
			return result;
		}

		public List<string> ReadFileLineByLine(string name)
		{
			var fileName = name;
			var line = string.Empty;

			var ret = new List<string>();
			var assembly = Assembly.GetExecutingAssembly();
			using (var stream = assembly.GetManifestResourceStream(string.Format("Voodoo.TestData.Data.{0}", name)))
			{
				using (var streamReader = new StreamReader(stream))
				{
					while (streamReader.Peek() != -1)
					{
						line = streamReader.ReadLine();
						ret.Add(line.Trim());
					}
					streamReader.Close();
				}
			}
			return ret;
		}
	}
}