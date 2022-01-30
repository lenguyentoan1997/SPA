using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public virtual ICollection<ProviderOrderDetail> ProviderOrderDetails { get; set; }
    }
}