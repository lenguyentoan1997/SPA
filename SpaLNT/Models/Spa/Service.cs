using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string ServiceCode { get; set; }

        public string Name { get; set; }
        
        public string Price { get; set; }

        public byte Discount { get; set; }

        public string Note { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}