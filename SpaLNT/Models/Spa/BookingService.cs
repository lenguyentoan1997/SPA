using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class BookingService
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public decimal Total { get; set; }

        public decimal Paid { get; set; }

        public decimal Debt { get; set; }

        public virtual Customer Customer { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }
    }
}