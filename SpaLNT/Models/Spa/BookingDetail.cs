using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class BookingDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BookingService")]
        public int BookingServiceId { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [ForeignKey("UseService")]
        public int UseServiceId { get; set; }

        public decimal Paid { get; set; }


        public virtual BookingService BookingService { get; set; }

        public virtual Service Service { get; set; }

        public virtual UseService UseService { get; set; }
    }
}