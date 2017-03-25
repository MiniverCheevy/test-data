using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.TestData;
using Voodoo.TestData.Strategy.TypeStrategy;
using Voodoo.TestData.Tests.TestClasses;

namespace Voodoo.TestData.Tests
{
	[TestClass]
	public class RandomizerTests
	{
		[TestMethod]
		public void Randomize_ClassWithEnum_IsOk()
		{
			var target = new ClassWithEnum();
			TestHelper.Randomizer.Randomize(target);
			Assert.AreNotEqual(default(DayOfWeek?), target.Day);
		}

		[TestMethod]
		public void Randomize_ClassWithStringLengthAttribute_IsOk()
		{
			for (var i = 0; i < 100; i++)
			{
				var subject = new EieioBucket();
				TestHelper.Randomizer.Randomize(subject);
				Assert.IsTrue(subject.BlockNumber.Length <= 5);
			}
		}

		[TestMethod]
		public void Randomize_ClassWithRangeAttribute_IsOk()
		{
			for (var i = 0; i < 100; i++)
			{
				var subject = new RangeTester();
				TestHelper.Randomizer.Randomize(subject);
			}
		}

		[TestMethod]
		public void Randomizer_ProblematicClass_IsOk()
		{
			var subject = new BucketlData();
			TestHelper.Randomizer.Randomize(subject);
			Assert.IsNotNull(subject.Contractor);
		}

		[TestMethod]
		public void Randomizer_ArbitraryClass_IsOk()
		{
			var subject = new OrderDetail();
			TestHelper.Randomizer.Randomize(subject);
			subject.UnitPrice.Should().NotBe(default(decimal));
			subject.Quantity.Should().NotBe(default(short));
			subject.Discount.Should().NotBe(default(float));
			subject.Title.Should().NotBe(default(string));
		}

		[TestMethod]
		public void Randomize_ArbitraryClass_SequentialCallsGenerateDifferentValues()
		{
			var person1 = new UserProfile();
			var person2 = new UserProfile();

			TestHelper.Randomizer.Randomize(person1);
			TestHelper.Randomizer.Randomize(person2);

			Assert.AreNotEqual(person1.FirstName, person2.FirstName);
		}

		[TestMethod]
		public void Randomizer_ClassWithNullableInts_IsOk()
		{
			var subject = new Product();
			TestHelper.Randomizer.Randomize(subject);
			Assert.IsTrue(subject.ReorderLevel.HasValue);
		}

		[TestMethod]
		public void Randomizer_ClassWithComplexTypes_DoesNotGenerateComplexTypes()
		{
			var test = new OrderDetail();
			TestHelper.Randomizer.Randomize(test);
			Assert.IsNull(test.Product);
		}

		[TestMethod]
		public void Randomizer_PredefinedTypeStrategy_WorksAsExpected()
		{
			var product1 = new Product {ProductName = "Test1"};
			var product2 = new Product {ProductName = "Test2"};
			var strategy = new PredefinedSetTypeStrategy<Product>(new[] {product1, product2});
			TestHelper.Randomizer.AddOrReplaceTypeStrategy(strategy);

			var test = new OrderDetail();
			TestHelper.Randomizer.Randomize(test);
			Assert.IsNotNull(test.Product);
			Assert.IsTrue(test.Product.ProductName == "Test1" || test.Product.ProductName == "Test2");
		}
	}
}