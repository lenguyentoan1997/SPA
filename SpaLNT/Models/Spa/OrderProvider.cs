using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class OrderProvider
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Paid { get; set; }

        public string Debt { get; set; }

        public string Note { get; set; }

        [ForeignKey("Provider")]
        public int? ProviderId { get; set; }

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }

        public byte Discount { get; set; }

        public string Total { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Branch Branch { get; set; }
        
        public virtual ICollection<ProviderOrderDetail> ProviderOrderDetails { get; set; }
    }
}