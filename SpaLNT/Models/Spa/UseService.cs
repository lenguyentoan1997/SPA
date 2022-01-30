using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class UseService
    {
        [Key]
        public int Id { get; set; }

        public string ServedDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Note { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}