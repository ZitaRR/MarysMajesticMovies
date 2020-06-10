using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class AddMovieForm
    {
        [Required]
        [Display(Name = "Imdb id")]
        [RegularExpression(@"^(tt)[0-9]+", ErrorMessage = "Imdb id format is \"tt123...\"")]
        public string ImdbId { get; set; }
        [Required]
        [RegularExpression(@"^[^\s].*", ErrorMessage = "Title can not start with a blank space")]
        [Display(Name = "Movie titel")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release year")]
        [Range(1850, 2025, ErrorMessage = "Release year is a number between 1850-2025")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Movie length")]
        [Range(5, 500, ErrorMessage = "Movie length is a number between 5-500 (minutes)")]
        public string RunTime { get; set; }
        [Required]
        [RegularExpression(@"^[^\s].*", ErrorMessage = "Genre can not start with a blank space")]
        public string Genre { get; set; }
        [Required]
        [RegularExpression(@"^[^\s].*", ErrorMessage = "Director can not start with a blank space")]
        public string Director { get; set; }
        [Required]
        [RegularExpression(@"^[^\s].*", ErrorMessage = "Actors can not start with a blank space")]
        public string Actors { get; set; }
        [Required]
        [RegularExpression(@"^[^\s].*", ErrorMessage = "Plot can not start with a blank space")]
        public string Plot { get; set; }
        [Required]
        [Display(Name = "Imdb Rating")]
        [Range(0, 10, ErrorMessage = "IMDb Rate is a number between 0-10")]
        public string ImdbRating { get; set; }
        [Required]
        [Display(Name = "Poster url")]
        [Url]
        public string PosterUrl { get; set; }
        [Required]
        [Display(Name = "Trailer url")]
        [RegularExpression(@"^(https://www.youtube.com/watch\?v=)[\S]+", ErrorMessage = "Trailer URL format is \"https://www.youtube.com/watch?v=...\"")]
        public string TrailerUrl { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Price is a number betweeen 1-1000")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "In stock")]
        [Range(0, 10000, ErrorMessage = "In stock is a number between 0-10000")]
        [RegularExpression(@"^[0-9]*", ErrorMessage = "In stock is a number between 0-10000")]
        public int InStock { get; set; }
    }
}
