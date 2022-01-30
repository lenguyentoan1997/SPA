using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class CustomerOrderDetail
    {
        [Key]
        public int Id { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        public byte Discount { get; set; }

        [ForeignKey("OrderCustomer")]
        public int OrderCustomerId { get; set; }

        [ForeignKey("ProductDetail")]
        public int ProductDetailId { get; set; }

        public virtual OrderCustomer OrderCustomer { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}