using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarysMajesticMovies.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MarysMajesticMovies.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult AddMovie()
        {
            if (ViewBag.Model == null)
            {
                ViewBag.Message = "";
            }
            return View();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Imdb id")]
            [RegularExpression(@"^(tt)[0-9]+", ErrorMessage = "Imdb id always starts with \"tt\"")]
            public string ImdbId { get; set; }
            [Required]
            [Display(Name = "Movie titel")]
            public string Title { get; set; }
            [Required]
            [Display(Name = "Release year")]
            [Range(1850, 2025, ErrorMessage = "The year is between 1850-2025")]
            public int Year { get; set; }
            [Required]
            [Display(Name = "Movie length")]
            [Range(5, 500, ErrorMessage = "The length is between 5-500 (minutes)")]
            public string RunTime { get; set; }
            [Required]
            [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß :]+$", ErrorMessage = "Use only letters and space please")]
            public string Genre { get; set; }
            [Required]
            public string Director { get; set; }
            [Required]
            public string Actors { get; set; }
            [Required]
            public string Plot { get; set; }
            [Required]
            [Display(Name = "Imdb Rating")]
            [Range(0, 10, ErrorMessage = "The IMDb rate is between 0-10")]
            public int ImdbRating { get; set; }
            [Required]
            [Display(Name = "Poster url")]
            [Url]
            public string PosterUrl { get; set; }
            [Required]
            [Display(Name = "Trailer url")]
            [Url]
            public string TrailerUrl { get; set; }
            [Required]
            [Range(1, 1000, ErrorMessage = "The price can only be betweeen 1-1000 kr")]
            public int Price { get; set; }
            [Required]
            [Display(Name = "In stock")]
            [Range(0, 10000, ErrorMessage = "The IMDb rate is between 0-10000")]
            public int InStock { get; set; }
        }

        // GET: Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _db.Movie.ToListAsync();
        }

        // GET: Admin/5
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

        // PUT: Admin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _db.Entry(movie).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostMovie()
        {
            if (_db.Movie.Any(m => m.ImdbId == Input.ImdbId))
            {
                ModelState.Clear();
                ViewBag.SaveMessage = "Movie is already registered, please try another one";
                return View("AddMovie");
            }

            var movie = new Movie
            {
                ImdbId = Input.ImdbId,
                Title = Input.Title,
                Year = Input.Year,
                RunTime = Input.RunTime,
                Genre = Input.Genre,
                Director = Input.Director,
                Actors = Input.Actors,
                Plot = Input.Plot,
                ImdbRating = Input.ImdbRating,
                PosterUrl = Input.PosterUrl,
                TrailerUrl = Input.TrailerUrl,
                Price = Input.Price,
                InStock = Input.InStock,
                AddedToStoreDate = DateTime.Now
            };

            _db.Movie.Add(movie);
            int saveStatus = await _db.SaveChangesAsync();

            if (!_db.Movie.Contains(movie))
            {
                ViewBag.SaveMessage = "Server Error, please try again!";
                return View("AddMovie");
            }

            ModelState.Clear();
            ViewBag.SaveMessage = "Movie is registered!";
            return View("AddMovie");
        }

        // DELETE: Admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _db.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _db.Movie.Remove(movie);
            await _db.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _db.Movie.Any(e => e.Id == id);
        }
    }
}
