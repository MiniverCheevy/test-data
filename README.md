# test-data

[![Version](https://img.shields.io/nuget/v/Voodoo.TestData.svg)](https://www.nuget.org/packages/Voodoo.TestData/)

Test-data is a C# library for random data generation.


##Getting Started

You can reproduce the same set of test data by setting the seed.

```
TestHelper.SetRandomDataSeed(1);
```

there are a series of static methods to generate data of various types

```
TestHelper.Data.Int(1, 10);
```

You can randomize all of the primitives on an object using the randomizer

```
var subject = new Product();
TestHelper.Randomizer.Randomize(subject);
```

You can create new population strategies or replace the existing ones

```
var product1 = new Product() { ProductName = "Test1" };
var product2 = new Product() { ProductName = "Test2" };
var strategy = new PredefinedSetTypeStrategy<Product>(new Product[] { product1, product2 });
TestHelper.Randomizer.AddOrReplaceTypeStrategy<Product>(strategy);

var test = new OrderDetail();
TestHelper.Randomizer.Ranomize(test);
```

##License

[MIT](LICENSE.txt)