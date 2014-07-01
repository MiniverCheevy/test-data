using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Voodoo.TestData;

namespace Voodoo.TestDataTest
{
    /// <summary>
    /// Summary description for RandomTest
    /// </summary>
    [TestClass]
    public class RandomTest
    {
        public RandomTest()
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



        [TestMethod]
        public void TestSettingSeedCausesTheSameValuesToBeGeneratede()
        {
            var num = 0;
            List<int> firstPass = new List<int>();
            List<int> secondPass = new List<int>();
            List<int> thirdPass = new List<int>();

            Debug.WriteLine ("1st Pass");
            TestHelper.SetRandomDataSeed(1);
            for (int i = 0; i < 10; i++) 

            {
               
                num = TestHelper.Data.Int(1, 10);
                firstPass.Add(num);
                Debug.WriteLine(num);
               
            }
            
            Debug.WriteLine ("2nd Pass");
            TestHelper.SetRandomDataSeed(1);
            for (int i = 0; i< 10; i++) 

            {
                num = TestHelper.Data.Int(1, 10);
                secondPass.Add(num);
                Debug.WriteLine(num);
                
            }
            
            Debug.WriteLine ("3rd Pass");
            TestHelper.SetRandomDataSeed(1);
            for (int i = 0; i < 10; i++) 

            {
                num = TestHelper.Data.Int(1, 10);
                thirdPass.Add(num);
                Debug.WriteLine(num);
                
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(firstPass[i], secondPass[i]);
                Assert.AreEqual(firstPass[i], thirdPass[i]);
            }
        }

        [TestMethod]
        public void TestNotSettingSeedCausesTheSameValuesToBeGeneratede()
        {
            var num = 0;
            List<int> firstPass = new List<int>();
            List<int> secondPass = new List<int>();
            List<int> thirdPass = new List<int>();

            Debug.WriteLine("1st Pass");
            
            for (int i = 0; i < 10; i++)
            {

                num = TestHelper.Data.Int(1, 10);
                firstPass.Add(num);
                Debug.WriteLine(num);

            }

            Debug.WriteLine("2nd Pass");
            
            for (int i = 0; i < 10; i++)
            {
                num = TestHelper.Data.Int(1, 10);
                secondPass.Add(num);
                Debug.WriteLine(num);

            }

            Debug.WriteLine("3rd Pass");
            
            for (int i = 0; i < 10; i++)
            {
                num = TestHelper.Data.Int(1, 10);
                thirdPass.Add(num);
                Debug.WriteLine(num);

            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsFalse(firstPass[i] == secondPass[i] && firstPass[i] == thirdPass[i]);
            }
        }

        [TestMethod]
        public void TestRandomSmallRange()
        {
            for (int i = 0; i < 10; i++)
            {
                int num = TestHelper.Data.Int(1, 3);
                Debug.WriteLine(num);
               
                
            }
        }
        [TestMethod]
        public void TestRandomModerateRange()
        {
            for (int i = 0; i < 10; i++)
            {
                int num = TestHelper.Data.Int(1, 100);
                Debug.WriteLine(num);                
            }
        }

      
         
    }
}
