using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
	public class BucketlData
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
}