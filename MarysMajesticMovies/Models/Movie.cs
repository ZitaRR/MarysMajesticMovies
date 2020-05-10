using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImdbId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string RunTime { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Actors { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public int ImdbRating { get; set; }
        [Required]
        public string PosterUrl { get; set; }
        [Required]
        public string TrailerUrl { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public DateTime AddedToStoreDate { get; set; }
        public int NoOfOrders { get; set; }

    }
}
