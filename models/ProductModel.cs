using System;
using System.ComponentModel.DataAnnotations;

namespace YourProjectName.Models
{
    public class db_products
    {
        [Key]
        public int? id { get; set; }

        public int? categoryId { get; set; }

        [StringLength(500)]
        public string? title { get; set; }

        [StringLength(15000)]
        public string? desc { get; set; }

        [StringLength(255)]
        public string? author { get; set; }

        [StringLength(255)]
        public string? slug { get; set; }

        public string? image { get; set; }

        public int? producerID { get; set; }

        public int? quantity { get; set; }

        public int? soldQuantity { get; set; }

        public int? soldInventory { get; set; }

        public int? sale { get; set; } // Nullable

        public decimal? price { get; set; } // Nullable

        public decimal? price_sale { get; set; } // Nullable

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public DateTime? deletedAt { get; set; } // Nullable

        public int? status { get; set; } // Nullable

        public int? pageNumber { get; set; } // Nullable

        [StringLength(11)]
        public string? size { get; set; }
    }
}