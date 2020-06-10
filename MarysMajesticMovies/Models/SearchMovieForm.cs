using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class SearchMovieForm
    {
        [Required]
        [Display(Name = "Imdb id for movie info")]
        [RegularExpression(@"^(tt)[0-9]+", ErrorMessage = "Imdb id format is \"tt123...\"")]
        public string ImdbId { get; set; }
    }
}
