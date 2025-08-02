// Models/Product.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductImage> Images { get; set; }
    }

    public class ProductImage
    {
        public int ProductImageId { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
