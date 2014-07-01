using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Voodoo.TestData;
using Voodoo.TestData.Builders;


namespace Voodoo.TestDataTest
{
    /// <summary>
    /// Summary description for TestDataLoading
    /// </summary>
    [TestClass]
    public class TestDataLoading
    {
        public TestDataLoading()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public  void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public  void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

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
            

            Debug.WriteLine ("zipCodes:" + data.zipCodes.Count.ToString());
            Debug.WriteLine ("firstMale:" + data.firstMale.Count.ToString());
            Debug.WriteLine ("firstFemale:" + data.firstFemale.Count.ToString());
            Debug.WriteLine ("lastNames:" + data.lastNames.Count.ToString());
            Debug.WriteLine ("streetParts1:" + data.streetParts1.Count.ToString());
            Debug.WriteLine ("streetParts2:" + data.streetParts2.Count.ToString());
            Debug.WriteLine("streetParts3:" + data.streetParts3.Count.ToString());

        }
        [TestMethod]
        public void TestGeneration()
        {
            var data = new RandomSeedData();
            for (int i = 0; i < 10; i++)
            {
                RandomPerson p = new PersonBuilder().Build(data);
                Debug.WriteLine(p.ToString());
            }
        }

    }
}
