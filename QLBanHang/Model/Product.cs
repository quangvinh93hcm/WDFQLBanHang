//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }
    
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string SupplierID { get; set; }
        public string TypeID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
