using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Model
{
    public class Daily
    {
        [Key]
        public int Id { get; set; } // Khóa chính
        public string? PersonId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Note { get; set; }
    }
}