using System;
using System.ComponentModel.DataAnnotations;

namespace Voodoo.TestData.Tests.TestClasses
{
	public class RangeTester
	{
		[Range(0, 1000)]
		public int max { get; set; }

		[Range(100, 200)]
		public int min { get; set; }

		[Range(typeof (DateTime), "1/1/1990", "12/31/1990")]
		public DateTime maxDate { get; set; }
	}
}