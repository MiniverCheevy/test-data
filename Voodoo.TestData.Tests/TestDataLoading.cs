using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.TestData;
using Voodoo.TestData.Builders;

namespace Voodoo.TestData.Tests
{
	/// <summary>
	///     Summary description for TestDataLoading
	/// </summary>
	[TestClass]
	public class TestDataLoading
	{
		[TestMethod]
		public void TestLoading()
		{
			var data = new RandomSeedData();

			Assert.AreNotEqual(0, data.ZipCodes.Count);
			Assert.AreNotEqual(0, data.FirstMale.Count);
			Assert.AreNotEqual(0, data.FirstFemale.Count);
			Assert.AreNotEqual(0, data.LastNames.Count);
			Assert.AreNotEqual(0, data.StreetParts1.Count);
			Assert.AreNotEqual(0, data.StreetParts2.Count);
			Assert.AreNotEqual(0, data.StreetParts3.Count);
			Assert.AreNotEqual(0, data.ZipCodes.Count);

			Assert.AreNotEqual(0, data.Adjectives.Count);
			Assert.AreNotEqual(0, data.Bussiness.Count);
			Assert.AreNotEqual(0, data.Comments.Count);
			Assert.AreNotEqual(0, data.Groceries.Count);
			Assert.AreNotEqual(0, data.Industry.Count);
			Assert.AreNotEqual(0, data.LoremIpsum.Length);


			Debug.WriteLine("zipCodes:" + data.ZipCodes.Count);
			Debug.WriteLine("firstMale:" + data.FirstMale.Count);
			Debug.WriteLine("firstFemale:" + data.FirstFemale.Count);
			Debug.WriteLine("lastNames:" + data.LastNames.Count);
			Debug.WriteLine("streetParts1:" + data.StreetParts1.Count);
			Debug.WriteLine("streetParts2:" + data.StreetParts2.Count);
			Debug.WriteLine("streetParts3:" + data.StreetParts3.Count);
		}

		[TestMethod]
		public void TestGeneration()
		{
			var data = new RandomSeedData();
			for (var i = 0; i < 10; i++)
			{
				var p = new PersonBuilder().Build(data);
				Debug.WriteLine(p.ToString());
			}
		}
	}
}