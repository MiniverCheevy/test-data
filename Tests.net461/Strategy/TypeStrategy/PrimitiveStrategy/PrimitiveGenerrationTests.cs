using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo;
using Voodoo.TestData.Strategy.TypeStrategy.PrimitiveStrategy;

namespace Voodoo.TestData.Tests.Strategy.TypeStrategy.PrimitiveStrategy
{
	[TestClass]
	public class PrimitiveGenerrationTests
	{
		[TestMethod]
		public void GenerateValue_SingleStrategy_IsNotConsitantly0()
		{
			float value = 0;
			for (var i = 0; i < 10; i ++)
			{
				value += new SingleStrategy().GenerateValue();

			}
			value.Should().NotBe((float) 0);
		}
		[TestMethod]
		public void GenerateValue_ByteStrategy_IsNotConsitantly0()
		{
			byte value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new ByteStrategy().GenerateValue();

			}
			value.Should().NotBe((byte)0);
		}
		[TestMethod]
		public void GenerateValue_DecimalStrategy_IsNotConsitantly0()
		{
			decimal value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new DecimalStrategy().GenerateValue();

			}
			value.Should().NotBe((decimal)0);
		}
		[TestMethod]
		public void GenerateValue_DoubleStrategy_IsNotConsitantly0()
		{
			double value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new DoubleStrategy().GenerateValue();

			}
			value.Should().NotBe((double)0);
		}
		[TestMethod]
		public void GenerateValue_IntStrategy_IsNotConsitantly0()
		{
			int value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new IntStrategy().GenerateValue();

			}
			value.Should().NotBe((int)0);
		}
		[TestMethod]
		public void GenerateValue_LongStrategy_IsNotConsitantly0()
		{
			long value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new LongStrategy().GenerateValue();

			}
			value.Should().NotBe((long)0);
		}
		[TestMethod]
		public void GenerateValue_ShortStrategy_IsNotConsitantly0()
		{
			short value = 0;
			for (var i = 0; i < 10; i++)
			{
				value += new ShortStrategy().GenerateValue();

			}
			value.Should().NotBe((short)0);
		}		

	}
}
