using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.TestData;

namespace VoodooTestDataTest
{
	[TestClass]
	public class RandomTest
	{
		
		[TestMethod]
		public void SetRandomDataSeed_TestSettingSeed_CausesTheSameValuesToBeGeneratede()
		{
			var num = 0;
			var firstPass = new List<int>();
			var secondPass = new List<int>();
			var thirdPass = new List<int>();

			Debug.WriteLine("1st Pass");
			TestHelper.SetRandomDataSeed(1);
			for (var i = 0; i < 10; i++)

			{
				num = TestHelper.Data.Int(1, 10);
				firstPass.Add(num);
				Debug.WriteLine(num);
			}

			Debug.WriteLine("2nd Pass");
			TestHelper.SetRandomDataSeed(1);
			for (var i = 0; i < 10; i++)

			{
				num = TestHelper.Data.Int(1, 10);
				secondPass.Add(num);
				Debug.WriteLine(num);
			}

			Debug.WriteLine("3rd Pass");
			TestHelper.SetRandomDataSeed(1);
			for (var i = 0; i < 10; i++)

			{
				num = TestHelper.Data.Int(1, 10);
				thirdPass.Add(num);
				Debug.WriteLine(num);
			}

			for (var i = 0; i < 10; i++)
			{
				Assert.AreEqual(firstPass[i], secondPass[i]);
				Assert.AreEqual(firstPass[i], thirdPass[i]);
			}
		}

		[TestMethod]
		public void TestNotSettingSeedCausesTheSameValuesToBeGeneratede()
		{
			var num = 0;
			var firstPass = new List<int>();
			var secondPass = new List<int>();
			var thirdPass = new List<int>();

			Debug.WriteLine("1st Pass");

			for (var i = 0; i < 10; i++)
			{
				num = TestHelper.Data.Int(1, 10);
				firstPass.Add(num);
				Debug.WriteLine(num);
			}

			Debug.WriteLine("2nd Pass");

			for (var i = 0; i < 10; i++)
			{
				num = TestHelper.Data.Int(1, 10);
				secondPass.Add(num);
				Debug.WriteLine(num);
			}

			Debug.WriteLine("3rd Pass");

			for (var i = 0; i < 10; i++)
			{
				num = TestHelper.Data.Int(1, 10);
				thirdPass.Add(num);
				Debug.WriteLine(num);
			}

			for (var i = 0; i < 10; i++)
			{
				Assert.IsFalse(firstPass[i] == secondPass[i] && firstPass[i] == thirdPass[i]);
			}
		}

		[TestMethod]
		public void Int_TestRandomSmallRange_IsOk()
		{
			for (var i = 0; i < 10; i++)
			{
				var num = TestHelper.Data.Int(1, 3);
				Debug.WriteLine(num);
			}
		}

		[TestMethod]
		public void Int_TestRandomModerateRange_IsOk()
		{
			for (var i = 0; i < 10; i++)
			{
				var num = TestHelper.Data.Int(1, 100);
				Debug.WriteLine(num);
			}
		}
	}
}