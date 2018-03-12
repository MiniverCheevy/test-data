using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
	public class OrderDetail
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public short Quantity { get; set; }
		public float Discount { get; set; }
		public Order Orders { get; set; }
		public virtual Product Product { get; set; }

		public string Title { get; set; }
	}
}