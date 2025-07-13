using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entities
{
    public class Person
    {
        [Key]
        public string PersonID { get; set; } = default!;
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = default!;
    }
}