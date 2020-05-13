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
    //[Route("api/[controller]")]
    //[ApiController]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public string statusMessage;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult AddMovie()
        {
            return View();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Imdb id")]
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
            //[Range(0, 10, ErrorMessage = "The IMDb rate is between 0-10")]
            public int ImdbRating { get; set; }
            [Required]
            [Display(Name = "Poster url")]
            //[Url]
            public string PosterUrl { get; set; }
            [Required]
            [Display(Name = "Trailer url")]
            //[Url]
            public string TrailerUrl { get; set; }
            [Required]
            //[Range(1, 1000, ErrorMessage = "The price can only be betweeen 1-1000 kr")]
            public int Price { get; set; }
            [Required]
            [Display(Name = "In stock")]
            public int InStock { get; set; }

            //[RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß-]+$", ErrorMessage = "Use letters only please")]
            //[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            //[Range(9999, 99999, ErrorMessage = "The zipcode must be 5 numbers long")]
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
        public async Task PostMovie()
        {
            statusMessage = "registering...";
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            //if (_db.Movie.Any(m => m.ImdbId == Input.ImdbId))
            //{
            //    statusMessage = "Movie is already registered, please try another one";
            //    ModelState.Clear();
            //    return;
            //}

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
            //var saveToDbResult = 
                await _db.SaveChangesAsync();

            //if (saveToDbResult == 0)
            //{
            //    statusMessage = "Server error, please try again";
            //    return;
            //}

            //statusMessage = "Movie is registered!";
            //ModelState.Clear();
            return;

            //return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
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
