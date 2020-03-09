namespace Ornek.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

       
        
        [Required]
        [StringLength(120)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(250)]
        public string Barcode { get; set; }
        [Required]

        public int Category { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]

        public int StockQuantity { get; set; }
        [Required]

        public bool IsActive { get; set; }
        

        public string Description { get; set; }
        [Required]

        public DateTime CreatedAt { get; set; }
        [Required]

        public DateTime UpdatedAt { get; set; }
    }
}
