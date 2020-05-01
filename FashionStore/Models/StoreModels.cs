using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionStore.Models
{
    public enum SizeEnum
    {
        S,
        L,
        XL,
        XXL
    }

    public enum TransactEnum
    {
        Ordering,
        Shipping,
        Done,
        Cancelled
    }
    
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public decimal UnitPrice { get; set; }

        public SizeEnum Size { get; set; }

        public string Color { get; set; }

        public float Discount { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public bool ProductAvailable { get; set; }

        public bool DiscountAvailable { get; set; }

        public string Picture { get; set; }

        public int Ranking { get; set; }

        public string Note { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Supplier
    {
        public int SupplierId { get; set; }

        public string CompanyName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public int PaymentMethodId { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
    }

    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }

        public string PaymentMethodName { get; set; }

        public bool Allowed { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int CategoryParentId { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public virtual Category CategoryParent { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        public int ApplicationUserId { get; set; }

        public int OrderNumber { get; set; }

        public int PaymentMethodId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public int ShipperId { get; set; }

        public decimal Freight { get; set; }

        public float SalesTax { get; set; }

        public DateTime TimeStamp { get; set; }

        public TransactEnum TransactStatus { get; set; }

        public bool Deleted { get; set; }

        public bool Paid { get; set; }

        public DateTime PaymentDate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual Shipper Shipper { get; set; }
    }

    public class Shipper
    {
        public int ShipperId { get; set; }

        public int SupplierId { get; set; }

        public string Phone { get; set; }

    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
