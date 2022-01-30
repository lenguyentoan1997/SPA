using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class OrderCustomer
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Paid { get; set; }

        public string Debt { get; set; }

        public string Note { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public byte Discount { get; set; }

        public string Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    }
}