using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoodooTestDataTest
{


	public class ClassWithEnum
	{
		public DayOfWeek Day { get; set; }

	}

	public class RangeTester
	{
		[Range(0, 1000)]
		public int max { get; set; }

		[Range(100, 200)]
		public int min { get; set; }

		[Range(typeof (DateTime), "1/1/1990", "12/31/1990")]
		public DateTime maxDate { get; set; }
	}

	public class EieioWellMetadata
	{
	}


	[MetadataType(typeof (EieioWellMetadata))]
	public class EieioWell
	{
		public virtual Guid EieioWellId { get; set; }
		public virtual Guid EieioRigId { get; set; }

		[StringLength(64)]
		public virtual string WellName { get; set; }

		[StringLength(20)]
		public virtual string WellNumber { get; set; }

		public virtual int JobNumber { get; set; }

		[StringLength(18)]
		public virtual string ApiWellNumber { get; set; }

		[StringLength(20)]
		public virtual string Lease { get; set; }

		public virtual DateTime? SpudDate { get; set; }

		[StringLength(32)]
		public virtual string Contractor { get; set; }

		[StringLength(64)]
		public virtual string Field { get; set; }

		[StringLength(5)]
		public virtual string BlockNumber { get; set; }

		public virtual int? WaterDepth { get; set; }

		[StringLength(20)]
		public virtual string WaterDepthUnits { get; set; }

		[StringLength(25)]
		public virtual string Parrish { get; set; }

		[StringLength(2)]
		public virtual string State { get; set; }

		[StringLength(250)]
		public virtual string Country { get; set; }

		public virtual bool IsDeleted { get; set; }
		public virtual short WellStatus { get; set; }
		public virtual bool? TightHole { get; set; }
		public virtual DateTime? FirstReportDate { get; set; }
		public virtual bool? IsTwoTour { get; set; }
		public virtual bool? RoundTimeLogHours { get; set; }
		public virtual Guid? EieioOperatorId { get; set; }
		public virtual DateTime? ModifiedUtc { get; set; }
	}

	public class WellData
	{
		public Guid WellId { get; set; }
		public Guid RigId { get; set; }
		public Guid? OperatorId { get; set; }
		public string WellName { get; set; }
		public string WellNumber { get; set; }
		public int JobNumber { get; set; }
		public string ApiWellNumber { get; set; }
		public string Lease { get; set; }
		public DateTime? SpudDate { get; set; }
		public string Contractor { get; set; }
		public string Field { get; set; }
		public string BlockNumber { get; set; }
		public int? WaterDepth { get; set; }
		public string Parrish { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public short WellStatus { get; set; }
		public bool? TightHole { get; set; }
		public DateTime? FirstReportDate { get; set; }
		public DateTime? ModifiedUtc { get; set; }
	}

	public class UserProfile
	{
		public int UserId { get; set; }
		public bool IsActive { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public int State { get; set; }
		public string Zip { get; set; }
		public string HomePhone { get; set; }
		public string MobilePhone { get; set; }
		public string FaxPhone { get; set; }
		public string BusinessPhone { get; set; }
		public string SSN { get; set; }
	}

	public class Order
	{
		public int OrderId { get; set; }
		public string CustomerId { get; set; }
		public int? EmployeeId { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public decimal? Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}

	public class OrderDetail
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public short Quantity { get; set; }
		public float Discount { get; set; }
		public Order Orders { get; set; }
		public virtual Product Product { get; set; }
	}

	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal? UnitPrice { get; set; }
		public short? UnitsInStock { get; set; }
		public short? UnitsOnOrder { get; set; }
		public short? ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
		public ICollection<OrderDetail> Order_Detail { get; set; }
	}
}