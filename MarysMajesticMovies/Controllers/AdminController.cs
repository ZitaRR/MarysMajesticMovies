using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarysMajesticMovies.Data;
using MarysMajesticMovies.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace MarysMajesticMovies.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[admincontroller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

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
            public int Year { get; set; }
            [Required]
            [Display(Name = "Movie length")]
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
            [Display(Name = "Imdb Rating")]
            public int ImdbRating { get; set; }
            [Required]
            [Display(Name = "Poster url")]
            public string PosterUrl { get; set; }
            [Required]
            [Display(Name = "Trailer url")]
            public string TrailerUrl { get; set; }
            [Required]
            public int Price { get; set; }
            [Required]
            [Display(Name = "In stock")]
            public int InStock { get; set; }

            //[RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß-]+$", ErrorMessage = "Use letters only please")]
            //[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            //[Range(9999, 99999, ErrorMessage = "The zipcode must be 5 numbers long")]
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _db.Movie.ToListAsync();
        }

        // GET: api/Admin/5
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

        // PUT: api/Admin/5
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

        // POST: api/Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _db.Movie.Add(movie);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Admin/5
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
