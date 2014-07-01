using System;
using System.Collections.Generic;
using System.Linq;

namespace Voodoo.TestData
{
    public static class TestDataExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> sourceData)
        {
            var length = sourceData.ToArray().Count();
            var index = TestHelper.Data.Int(0, length - 1);
            var array = sourceData.ToArray();
            return array[index];
        }
    }

    public static class TestHelper
    {
        private static object lockObject = new object();

        private static Randomizer __randomizer;
        internal static RandomDataGenerator __generator;
        internal static Random __random;

        public static Randomizer Randomizer
        {
            get
            {
                lock (lockObject)
                {
                    if (__randomizer == null)
                    {
                        __randomizer = new Randomizer();
                    }
                    return __randomizer;
                }
            }
        }

        public static RandomDataGenerator Data
        {
            get
            {
                lock (lockObject)
                {
                    if (__generator == null)
                    {
                        __generator = new RandomDataGenerator();
                    }
                    return __generator;
                }
            }
        }

        public static Random Random
        {
            get
            {
                lock (lockObject)
                {
                    if (__random == null)
                    {
                        __random = new Random();
                    }
                    return __random;
                }
            }
        }


        //private static void init()
        //{
        //    if (_random == null)
        //        SetRandomDataSeed(12345);

        //    if (_generator == null)
        //        _generator = new RandomDataGenerator();
        //}

        //http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var elements = source.ToArray();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                var swapIndex = Random.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }


        public static void SetRandomDataSeed(int seed)
        {
            __random = new Random(seed);
        }
    }
}