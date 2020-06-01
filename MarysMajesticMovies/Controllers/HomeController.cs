﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarysMajesticMovies.Models;
using MarysMajesticMovies.Data;
using Microsoft.EntityFrameworkCore;

namespace MarysMajesticMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var homePageLists = new HomePageListModel();
            homePageLists.Blockbuster = GetMovieList("Blockbuster", 10);
            homePageLists.Latest = GetMovieList("Latest", 10);
            homePageLists.Popular = GetMovieList("Popular", 10);
            homePageLists.Action = GetMovieList("Action", 10);
            homePageLists.Drama = GetMovieList("Drama", 10);

            return View(homePageLists);
        }

        public IActionResult Genre()
        {
            return  View(GetMovieList());
        }

        public IActionResult Blockbuster()
        {
            return View(GetMovieList("Blockbuster", 25));
        }

        public IActionResult Popular()
        {
            return View(GetMovieList("Popular", 25));
        }

        public IActionResult Latest()
        {
            return View(GetMovieList("Latest", 25));
        }

        public IActionResult Oldies()
        {
            return View(GetMovieList("Oldies", 25));
        }
        public IActionResult NewlyAdded()
        {
            return View(GetMovieList("NewlyAdded", 25));
        }

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Movie> GetMovieList()
        {
            try
            {
                return _db.Movies.ToList();
            }
            catch (Exception)
            {
            }

            return new List<Movie>();
        }
        public  List<Movie> GetMovieList(string type, int NoOfMovies)
        {
            var allMovies = _db.Movies;
            try
            {
                if (type == "Action" || type == "Adventure" || type == "Comedy" || type == "Crime" || type == "Drama" || type == "Horror" || type == "Romance" || type == "Scifi")
                {
                    return allMovies.Where(m => m.Genre.Contains(type)).OrderByDescending(m => m.ImdbRating).Take(NoOfMovies).ToList();
                }
                else if (type == "Blockbuster")
                {
                    return allMovies.OrderByDescending(m => m.ImdbRating).Take(NoOfMovies).ToList();
                }
                else if (type == "Popular")
                {
                    return allMovies.OrderByDescending(m => m.NoOfOrders).Take(NoOfMovies).ToList();
                }
                else if (type == "Latest")
                {
                    return allMovies.OrderByDescending(m => m.Year).Take(NoOfMovies).ToList();
                }
                else if (type == "Oldies")
                {
                    return allMovies.OrderBy(m => m.Year).Take(NoOfMovies).ToList();
                }
                else if (type == "NewlyAdded")
                {
                    return allMovies.OrderByDescending(m => m.AddedToStoreDate).Take(NoOfMovies).ToList();
                }
            }
            catch (Exception)
            {
            }

            return new List<Movie>();
        }
    }
}
