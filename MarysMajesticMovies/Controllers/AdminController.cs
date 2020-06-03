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
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using System.Dynamic;

namespace MarysMajesticMovies.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        static HttpClient client = new HttpClient();

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SearchMovieForm SearchMovieInput { get; set; }
        [BindProperty]
        public AddMovieForm AddMovieInput { get; set; }

        public IActionResult AddMovie()
        {
            if (ViewBag.Model == null)
            {
                ViewBag.Message = "";
            }
            if (ViewBag.Input != null)
            {
                AddMovieInput = ViewBag.Input;
            }
            return View();
        }

        public class SearchMovieForm
        {
            [Required]
            [Display(Name = "Imdb id for movie info")]
            [RegularExpression(@"^(tt)[0-9]+", ErrorMessage = "Imdb id format is \"tt123...\"")]
            public string ImdbId { get; set; }
        }

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
            [Url]
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

        // GET: Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _db.Movies.ToListAsync();
        }

        // GET: Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _db.Movies.FindAsync(id);

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
            if (_db.Movies.Any(m => m.ImdbId == AddMovieInput.ImdbId))
            {
                ModelState.Clear();
                ViewBag.StatusMessage = "Movie is already registered, please try another one";
                return View("AddMovie");
            }

            var movie = new Movie
            {
                ImdbId = AddMovieInput.ImdbId.Trim(),
                Title = AddMovieInput.Title.Trim(),
                Year = AddMovieInput.Year,
                RunTime = AddMovieInput.RunTime.Trim(),
                Genre = AddMovieInput.Genre.Trim(),
                Director = AddMovieInput.Director.Trim(),
                Actors = AddMovieInput.Actors.Trim(),
                Plot = AddMovieInput.Plot.Trim(),
                ImdbRating = Convert.ToDouble(AddMovieInput.ImdbRating.Replace(".",",")),
                PosterUrl = AddMovieInput.PosterUrl.Trim(),
                TrailerUrl = AddMovieInput.TrailerUrl.Trim(),
                Price = AddMovieInput.Price,
                InStock = AddMovieInput.InStock,
                AddedToStoreDate = DateTime.Now
            };

            _db.Movies.Add(movie);
            int saveStatus = await _db.SaveChangesAsync();

            if (!_db.Movies.Contains(movie))
            {
                ViewBag.StatusMessage = "Server Error, please try again!";
                return View("AddMovie");
            }

            ModelState.Clear();
            ViewBag.StatusMessage = "Movie is registered!";
            return View("AddMovie");
        }

        // DELETE: Admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _db.Movies.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> GetMovieInfo()
        {
            string APIKey = "GetFromOmdb";
            string APIURL = $"http://www.omdbapi.com/?apikey={APIKey}&i={SearchMovieInput.ImdbId}&r=json";

            try
            {
                HttpResponseMessage response = await client.GetAsync(APIURL);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responsContent = await response.Content.ReadAsStringAsync();
                    var movieInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(responsContent);

                    ViewBag.ImdbId = movieInfo["imdbID"].ToString();
                    ViewBag.MovieTitle = movieInfo["Title"].ToString();
                    ViewBag.Year = movieInfo["Year"].ToString();
                    ViewBag.RunTime = movieInfo["Runtime"].ToString();
                    ViewBag.Genre = movieInfo["Genre"].ToString();
                    ViewBag.Director = movieInfo["Director"].ToString();
                    ViewBag.Actors = movieInfo["Actors"].ToString();
                    ViewBag.Plot = movieInfo["Plot"].ToString();
                    ViewBag.ImdbRating = movieInfo["imdbRating"].ToString();
                    ViewBag.PosterUrl = movieInfo["Poster"].ToString();
                }
                else
                {
                    ViewBag.StatusMessage = "Server error, please check imdb id!";

                }
            }
            catch (Exception)
            {
                ViewBag.StatusMessage = "Server error, please contact support!";
            }

            return View("AddMovie");
        }
    }
}
