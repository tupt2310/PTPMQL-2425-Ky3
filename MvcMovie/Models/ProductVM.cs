// ViewModels/ProductViewModel.cs
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ProductVM
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Cần upload ít nhất một ảnh")]
        [MinLength(1, ErrorMessage = "Cần ít nhất 1 ảnh")]
        [MaxLength(5, ErrorMessage = "Chỉ được upload tối đa 5 ảnh")]
        public List<IFormFile> Images { get; set; }
    }
}
