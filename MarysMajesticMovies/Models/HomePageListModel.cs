using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies.Models
{
    public class HomePageListModel
    {
        public List<Movie> Blockbuster { set; get; }
        public List<Movie> Latest { set; get; }
        public List<Movie> Popular { set; get; }
        public List<Movie> Action { set; get; }
        public List<Movie> Oldies { set; get; }

    }
}

