using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VoodooTestDataTest
{


    public class rangeTester
    {
        [Range(0,1000)]
        public int max { get; set; }

        [Range(100,200)]
        public int min { get; set; }

        [Range(typeof(DateTime), "1/1/1990","12/31/1990")]
        public DateTime maxDate { get; set; }
    }

    public partial class IADC_Well_Metadata
    {
        //TODO: TEst meta data
    }

    
    [MetadataType(typeof(IADC_Well_Metadata))]
    public partial class IADC_Well
    {
       

        
        public virtual System.Guid IADC_WellID { get; set; }
        
        public virtual System.Guid IADC_RigID { get; set; }
        [StringLength(64)]
        
        public virtual string WellName { get; set; }
        [StringLength(20)]
        
        public virtual string WellNumber { get; set; }
        
        public virtual int JobNumber { get; set; }
        [StringLength(18)]
        
        public virtual string APIWellNumber { get; set; }
        [StringLength(20)]
        
        public virtual string Lease { get; set; }
        
        public virtual Nullable<System.DateTime> SpudDate { get; set; }
        [StringLength(32)]
        
        public virtual string Contractor { get; set; }
        [StringLength(64)]
        
        public virtual string Field { get; set; }
        [StringLength(5)]
        
        public virtual string BlockNumber { get; set; }
        
        public virtual Nullable<int> WaterDepth { get; set; }
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
        
        public virtual Nullable<bool> TightHole { get; set; }
        
        public virtual Nullable<System.DateTime> FirstReportDate { get; set; }
        
        public virtual Nullable<bool> IsTwoTour { get; set; }
        
        public virtual Nullable<bool> RoundTimeLogHours { get; set; }
        
        public virtual Nullable<System.Guid> IADC_OperatorID { get; set; }
        
        public virtual Nullable<System.DateTime> ModifiedUTC { get; set; }
              
    }
    public class WellData
    {
        public Guid WellID { get; set; }

        public Guid RigID { get; set; }

        public Guid? OperatorID { get; set; }

        public string WellName { get; set; }

        public string WellNumber { get; set; }

        public int JobNumber { get; set; }

        public string APIWellNumber { get; set; }

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

        public DateTime? ModifiedUTC { get; set; }


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
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
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
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public Order Orders { get; set; }
        public virtual Product Product { get; set; }

     
    }
    public class Product
    {
        public int ProductID { get; set; }
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
