using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Voodoo.TestData
{
    public class RandomSeedData
    {
        public string LoremIpsum;
        public List<string> adjectives = new List<string>();
        public Dictionary<string, string[]> autofill = new Dictionary<string, string[]>();
        public List<string> bussiness = new List<string>();
        public List<string> comments = new List<string>();
        public List<string> firstFemale = new List<string>();
        public List<string> firstMale = new List<string>();
        public List<string> groceries = new List<string>();
        public List<string> industry = new List<string>();
        public List<string> lastNames = new List<string>();
        public List<string> prefixFemale = new List<string>();
        public List<string> prefixMale = new List<string>();
        public List<string> streetParts1 = new List<string>();
        public List<string> streetParts2 = new List<string>();
        public List<string> streetParts3 = new List<string>();
        public List<string> suffix = new List<string>();
        public List<string> usedNames = new List<string>();
        public List<CityStateZip> zipCodes = new List<CityStateZip>();

        public RandomSeedData()
        {
            var path = Environment.CurrentDirectory;
            lastNames = ReadFileLineByLine("last.txt");
            firstMale = ReadFileLineByLine("male.txt");
            firstFemale = ReadFileLineByLine("female.txt");
            comments = ReadFileLineByLine("comment.txt");
            bussiness = ReadFileLineByLine("business.txt");
            industry = ReadFileLineByLine("Industry.txt");
            adjectives = ReadFileLineByLine("Adjective.txt");
            groceries = ReadFileLineByLine("grocery.txt");
            LoremIpsum = ReadFile("LoremIpsum.txt");

            var zipTemp = ReadFileLineByLine("zip5.txt");
            foreach (var s in zipTemp)
            {
                zipCodes.Add(new CityStateZip(s));
            }


            var streetTemp = ReadFileLineByLine("streetparts.txt");
            foreach (var s in streetTemp)
            {
                var ary = s.Split(',');
                streetParts1.Add(ary[0]);
                streetParts2.Add(ary[1]);
                streetParts3.Add(ary[2]);
            }

            var config = ReadFileLineByLine("AutoFill.txt");
            foreach (var item in config)
            {
                var first = item.ToString().Split(':');
                if (first.Length == 2)
                {
                    var key = first[0];
                    var second = first[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var trimmed = new List<string>();
                    foreach (var element in second)
                    {
                        trimmed.Add(element.ToString().Trim());
                    }
                    autofill.Add(key, trimmed.ToArray());
                }
            }
        }

        public string ReadFile(string name)
        {
            var fileName = name;


            var result = string.Empty;
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

    public enum Gender
    {
        Male = 1,
        Female = 2
    };

    public enum AgeRange
    {
        Child = 1,
        Adult = 2
    };

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
            this.ZipCode = ary[0];
            this.City = ary[1];
            this.State = ary[2];
            this.Latitude = decimal.Parse(ary[3]);
            this.Longitude = decimal.Parse(ary[4]);
            this.County = ary[5];
        }
    }
}