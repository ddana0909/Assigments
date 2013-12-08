//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using Microsoft.Ajax.Utilities;

namespace OrderManagement
{
    using System;
    using System.Collections.Generic;

    public partial class Order
    {
        public Order()
        {
            this.Order_Details = new HashSet<Order_Detail>();
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> RequiredDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Shipped")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> ShippedDate { get; set; }

        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }

        [DisplayName("Ship Name")]
        public string ShipName { get; set; }

        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        [DisplayName("Shipping Address")]
        public string ShippingDetails
        {
            get
            {
                var sb = new StringBuilder(ShipAddress + ", " + ShipCity + ", " + ShipRegion + ", "
                    + ShipPostalCode + ", " + ShipCountry);
                sb.Replace(", , ", ", ");
                return (sb.ToString());
            }
        }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Order_Detail> Order_Details { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
