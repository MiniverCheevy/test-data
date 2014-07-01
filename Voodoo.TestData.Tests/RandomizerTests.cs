using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voodoo.TestData;
using Voodoo.TestData.Strategy.TypeStrategy;

namespace VoodooTestDataTest
{
    [TestClass]
    public class RandomizerTests
    {

        [TestMethod]
        public void RandomizerWorksAsExpectedWithStringLengthAttribute()
        {
            for (int i = 0; i < 100; i++)
            {
                var subject = new IADC_Well();
                TestHelper.Randomizer.Randomize(subject);
                Assert.IsTrue(subject.BlockNumber.Length <= 5);
            }
        }

        [TestMethod]
        public void RandomizerDoesNotThrowExceptionsWithRangeAttribute()
        {
            for (int i = 0; i < 100; i++)
            {
                var subject = new rangeTester();
                TestHelper.Randomizer.Randomize(subject);
              
            }
        }


        [TestMethod]
        public void RandomizerWorksAsExpectedWithWellData()
        {
            var subject = new WellData();
            TestHelper.Randomizer.Randomize(subject);
            Assert.IsNotNull(subject.Contractor);

        }

        [TestMethod]
        public void RandomizerWorksAsExpected()
        {
            var subject = new Order();
            TestHelper.Randomizer.Randomize(subject);
            Assert.IsNotNull(subject.Freight);
            
        }

        [TestMethod]
        public void SequentialCallsGenerateDifferentRandomValues()
        {
            var person1 = new UserProfile ();
            var person2 = new UserProfile();

            TestHelper.Randomizer.Randomize(person1);
            TestHelper.Randomizer.Randomize(person2);

            Assert.AreNotEqual(person1.FirstName, person2.FirstName);

            
        }

       

        [TestMethod]
        public void RandomizerRandomizesNullableInts()
        {
            var subject = new Product();
            TestHelper.Randomizer.Randomize(subject);
            Assert.IsTrue(subject.ReorderLevel.HasValue);
        }

        [TestMethod]
        public void RandomizerDoesNotGenerateComplexTypes()
        {            
            var test = new OrderDetail();
            TestHelper.Randomizer.Randomize(test);
            Assert.IsNull(test.Product);
        }

        [TestMethod]
        public void PredefinedTypeStrategyWorksAsExpected()
        {
            var product1 = new Product() { ProductName = "Test1" };
            var product2 = new Product() { ProductName = "Test2" };
            var strategy = new PredefinedSetTypeStrategy<Product>(new Product[] { product1, product2 });
            TestHelper.Randomizer.AddOrReplaceTypeStrategy<Product>(strategy);

            var test = new OrderDetail();
            TestHelper.Randomizer.Randomize(test);
            Assert.IsNotNull(test.Product);
            Assert.IsTrue(test.Product.ProductName == "Test1" || test.Product.ProductName == "Test2");
            
        }



    }
}
