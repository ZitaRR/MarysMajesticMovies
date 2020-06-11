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

        // POST: Admin
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
                TrailerUrl = AddMovieInput.TrailerUrl.Trim().Replace("watch?v=", "embed/"),
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

        [HttpPost]
        public async Task<ActionResult> GetMovieInfo()
        {
            string APIKey = "GetByOmdb";
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
