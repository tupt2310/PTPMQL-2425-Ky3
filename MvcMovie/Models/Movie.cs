using System.ComponentModel.DataAnnotations;


namespace MvcMovie.Model;
public class Movie
{
    public int Id { get ; set ; }
    public string? Tittle { get; set; }
        [DataType(DataType.Date)]

        public DateTime ReleaseDate { get; set; }

        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
