using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        [ForeignKey("Factory")]
        public int FactoryId { get; set; }

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }

        public decimal ImportPrice { get; set; }

        public decimal ExportPrice { get; set; }

        public string ProductCode { get; set; }

        public byte Discount { get; set; }

        public string ImgAvatar { get; set; }

        public string Thumbnail1 { get; set; }

        public string Thumbnail2 { get; set; }

        public string Thumbnail3 { get; set; }


        public virtual Type Type { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}