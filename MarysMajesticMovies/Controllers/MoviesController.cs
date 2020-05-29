using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarysMajesticMovies.Data;
using MarysMajesticMovies.Models;

namespace MarysMajesticMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _db.Movie.ToListAsync();
        }

        // GET: Movies/
        [HttpGet("{type, NoOfMovies}")]
        public async Task<IEnumerable<Movie>> GetMovieList(string type, int NoOfMovies = 25)
        {
            var allMovies = await _db.Movie.ToListAsync();
            try
            {
                if (type == "Action" || type == "Adventure" || type == "Comedy" || type == "Crime" || type == "Drama" || type == "Horror" || type == "Romance" || type == "Scifi")
                {
                    return allMovies.Where(m => m.Genre.Contains(type)).OrderBy(m => m.Title).Take(NoOfMovies);
                }
                else if (type == "TopRated")
                {
                    return allMovies.OrderByDescending(m => m.ImdbRating).Take(NoOfMovies);
                }
                else if (type == "MostBought")
                {
                    return allMovies.OrderByDescending(m => m.NoOfOrders).Take(NoOfMovies);
                }
                else if (type == "LastAdded")
                {
                    return allMovies.OrderByDescending(m => m.AddedToStoreDate).Take(NoOfMovies);
                }
                else if (type == "NewestMovies")
                {
                    return allMovies.OrderByDescending(m => m.Year).Take(NoOfMovies);
                }
            }
            catch (Exception)
            {                
            }

            return Enumerable.Empty<Movie>();
        }

        // GET: Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _db.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _db.Movie.Any(e => e.Id == id);
        }
    }
}
