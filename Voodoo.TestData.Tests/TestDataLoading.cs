using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.TestData;
using Voodoo.TestData.Builders;

namespace Voodoo.TestDataTest
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

			Assert.AreNotEqual(0, data.zipCodes.Count);
			Assert.AreNotEqual(0, data.firstMale.Count);
			Assert.AreNotEqual(0, data.firstFemale.Count);
			Assert.AreNotEqual(0, data.lastNames.Count);
			Assert.AreNotEqual(0, data.streetParts1.Count);
			Assert.AreNotEqual(0, data.streetParts2.Count);
			Assert.AreNotEqual(0, data.streetParts3.Count);
			Assert.AreNotEqual(0, data.zipCodes.Count);

			Assert.AreNotEqual(0, data.adjectives.Count);
			Assert.AreNotEqual(0, data.bussiness.Count);
			Assert.AreNotEqual(0, data.comments.Count);
			Assert.AreNotEqual(0, data.groceries.Count);
			Assert.AreNotEqual(0, data.industry.Count);
			Assert.AreNotEqual(0, data.LoremIpsum.Length);


			Debug.WriteLine("zipCodes:" + data.zipCodes.Count);
			Debug.WriteLine("firstMale:" + data.firstMale.Count);
			Debug.WriteLine("firstFemale:" + data.firstFemale.Count);
			Debug.WriteLine("lastNames:" + data.lastNames.Count);
			Debug.WriteLine("streetParts1:" + data.streetParts1.Count);
			Debug.WriteLine("streetParts2:" + data.streetParts2.Count);
			Debug.WriteLine("streetParts3:" + data.streetParts3.Count);
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