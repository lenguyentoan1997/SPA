using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }
    }
}