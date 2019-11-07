namespace galleryWebsiteSparta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProductImage { get; set; }

        public decimal Price { get; set; }

        public bool ProductAvailability { get; set; }
    }
}
