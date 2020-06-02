using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Movie>().HasData(
               new Movie
               {
                   Id = 1,
                   ImdbId = "tt1375666",
                   Title = "Inception",
                   Year = 2010,
                   RunTime = "148",
                   Genre = "Action, Adventure, Sci-Fi",
                   Director = "Christopher Nolan",
                   Actors = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page",
                   Plot = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                   ImdbRating = 8.8,
                   PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                   TrailerUrl = "https://www.youtube.com/embed/YoHD9XEInc0",
                   Price = 149,
                   InStock = 7,
                   AddedToStoreDate = DateTime.Now
               },
               new Movie
               {
                   Id = 2,
                   ImdbId = "tt0105916",
                   Title = "Änglagård",
                   Year = 1992,
                   RunTime = "119",
                   Genre = "Comedy, Drama",
                   Director = "Colin Nutley",
                   Actors = "Helena Bergström, Rikard Wolff, Sven Wollter",
                   Plot = "A rural village is divided when an extraordinary couple move into a mansion.",
                   ImdbRating = 6.3,
                   PosterUrl = "https://m.media-amazon.com/images/M/MV5BNmE5ZjM3MDgtNmY5My00Y2JiLThmNDItZjU2NjIwNTYyNTdjXkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_.jpg",
                   TrailerUrl = "https://www.youtube.com/embed/NsvkwMTXzOI",
                   Price = 99,
                   InStock = 5,
                   AddedToStoreDate = DateTime.Now

               },
               new Movie
               {
                   Id = 3,
                   ImdbId = "tt0107290",
                   Title = "Jurrasic Park",
                   Year = 1993,
                   RunTime = "127",
                   Genre = "Action, Aventure, Sci-Fi",
                   Director = "Steven Spielberg",
                   Actors = "Sam Neill, Laura Dern, Jeff Goldblum",
                   Plot = "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park's cloned dinosaurs to run loose.",
                   ImdbRating = 8.1,
                   PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_.jpg",
                   TrailerUrl = "https://www.youtube.com/embed/KdGO9tL2DQ4",
                   Price = 129,
                   InStock = 12,
                   AddedToStoreDate = DateTime.Now

               },
               new Movie
               {
                   Id = 4,
                   ImdbId = "tt0120737",
                   Title = "The Lord of the Rings: The Fellowship of the Ring",
                   Year = 2001,
                   RunTime = "178",
                   Genre = "Action, Aventure, Drama",
                   Director = "Peter Jackson",
                   Actors = "Elijah Wood, Ian McKellen, Orlando Bloom",
                   Plot = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                   ImdbRating = 8.8,
                   PosterUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SY999_CR0,0,673,999_AL_.jpg",
                   TrailerUrl = "https://www.youtube.com/embed/V75dMMIW2B4",
                   Price = 129,
                   InStock = 5,
                   AddedToStoreDate = DateTime.Now

               },
               new Movie
               {
                   Id = 5,
                   ImdbId = "tt0133093",
                   Title = "The Matrix",
                   Year = 1999,
                   RunTime = "136",
                   Genre = "Action, Sci-Fi",
                   Director = "Lana Wachowski, Lilly Wachowski",
                   Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
                   Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                   ImdbRating = 8.7,
                   PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg",
                   TrailerUrl = "https://www.youtube.com/embed/m8e-FF8MsqU",
                   Price = 79,
                   InStock = 18,
                   AddedToStoreDate = DateTime.Now

               },
                new Movie
                {
                    Id = 6,
                    ImdbId = "tt0434409",
                    Title = "V for Vendetta",
                    Year = 2005,
                    RunTime = "132",
                    Genre = "Action, Drama, Sci-Fi",
                    Director = "James McTeigue",
                    Actors = "Hugo Weaving, Natalie Portman, Rupert Graves",
                    Plot = "In a future British tyranny, a shadowy freedom fighter, known only by the alias of 'V', plots to overthrow it with the help of a young woman.",
                    ImdbRating = 8.2,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BOTI5ODc3NzExNV5BMl5BanBnXkFtZTcwNzYxNzQzMw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/lSA7mAHolAw",
                    Price = 139,
                    InStock = 19,
                    AddedToStoreDate = DateTime.Now

                },
                 new Movie
                 {
                     Id = 7,
                     ImdbId = "tt0266308",
                     Title = "Battle Royale",
                     Year = 2000,
                     RunTime = "116",
                     Genre = "Adventure, Drama, Sci-Fi",
                     Director = "Kinji Fukusaku",
                     Actors = "Tatsuya Fujiwara, Aki Maeda, Tarô Yamamoto",
                     Plot = "In the future, the Japanese government captures a class of ninth-grade students and forces them to kill each other under the revolutionary 'Battle Royale' act.",
                     ImdbRating = 7.6,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDc2MGYwYzAtNzE2Yi00YmU3LTkxMDUtODk2YjhiNDM5NDIyXkEyXkFqcGdeQXVyMTEwNDU1MzEy._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/N0p1t-dC7Ko",
                     Price = 159,
                     InStock = 11,
                     AddedToStoreDate = DateTime.Now

                 },
                  new Movie
                  {
                      Id = 8,
                      ImdbId = "tt0097165",
                      Title = "Dead Poets Society",
                      Year = 1989,
                      RunTime = "128",
                      Genre = "Comedy, Drama",
                      Director = "Peter Weir",
                      Actors = "Robin Williams, Robert Sean Leonard, Ethan Hawke",
                      Plot = "English teacher John Keating inspires his students to look at poetry with a different perspective of authentic knowledge and feelings.",
                      ImdbRating = 8.1,
                      PosterUrl = "https://m.media-amazon.com/images/M/MV5BOGYwYWNjMzgtNGU4ZC00NWQ2LWEwZjUtMzE1Zjc3NjY3YTU1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,677,1000_AL_.jpg",
                      TrailerUrl = "https://www.youtube.com/embed/ye4KFyWu2do",
                      Price = 79,
                      InStock = 5,
                      AddedToStoreDate = DateTime.Now

                  },
                 new Movie
                 {
                     Id = 9,
                     ImdbId = "tt0108052",
                     Title = "Schindler's List",
                     Year = 1993,
                     RunTime = "195",
                     Genre = "Biography, Drama, History",
                     Director = "Steven Spielberg",
                     Actors = "Liam Neeson, Ralph Fiennes, Ben Kingsley",
                     Plot = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                     ImdbRating = 8.9,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/gG22XNhtnoY",
                     Price = 129,
                     InStock = 13,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 10,
                     ImdbId = "tt3472226",
                     Title = "Kung Fury",
                     Year = 2015,
                     RunTime = "31",
                     Genre = "Short, Action, Comedy",
                     Director = "David Sandberg",
                     Actors = "David Sandberg, Jorma Taccone, Steven Chew",
                     Plot = "In 1985, Kung Fury, the toughest martial artist cop in Miami, goes back in time to kill the worst criminal of all time - Kung Führer, a.k.a. Adolf Hitler.",
                     ImdbRating = 8.0,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjQwMjU2ODU5NF5BMl5BanBnXkFtZTgwNTU1NjM4NTE@._V1_SY999_CR0,0,702,999_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/89AxvewTS90",
                     Price = 229,
                     InStock = 73,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 11,
                     ImdbId = "tt0110413",
                     Title = "Leon",
                     Year = 1994,
                     RunTime = "110",
                     Genre = "Action, Crime, Drama",
                     Director = "Luc Besson",
                     Actors = "Jean Reno, Gary Oldman, Natalie Portman",
                     Plot = "Mathilda, a 12-year-old girl, is reluctantly taken in by Léon, a professional assassin, after her family is murdered. An unusual relationship forms as she becomes his protégée and learns the assassin's trade.",
                     ImdbRating = 8.5,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BZDAwYTlhMDEtNTg0OS00NDY2LWJjOWItNWY3YTZkM2UxYzUzXkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_SY1000_CR0,0,710,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/jawVxq1Iyl0",
                     Price = 99,
                     InStock = 11,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 12,
                     ImdbId = "tt0167261",
                     Title = "The Lord of the Rings: The Two Towers",
                     Year = 2002,
                     RunTime = "179",
                     Genre = "Adventure, Drama, Fantasy",
                     Director = "Peter Jackson",
                     Actors = "Elijah Wood, Ian McKellen, Viggo Mortensen",
                     Plot = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                     ImdbRating = 8.7,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/hYcw5ksV8YQ",
                     Price = 129,
                     InStock = 22,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 13,
                     ImdbId = "tt0167260",
                     Title = "The Lord of the Rings: The Return of the King",
                     Year = 2003,
                     RunTime = "201",
                     Genre = "Adventure, Drama, Fantasy",
                     Director = "Peter Jackson",
                     Actors = "Elijah Wood, Viggo Mortensen, Ian McKellen",
                     Plot = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                     ImdbRating = 8.9,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/r5X-hFf6Bwo",
                     Price = 129,
                     InStock = 15,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 14,
                     ImdbId = "tt0088247",
                     Title = "Terminator",
                     Year = 1984,
                     RunTime = "107",
                     Genre = "Action, Sci-Fi",
                     Director = "James Cameron",
                     Actors = "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn",
                     Plot = "In 1984, a human soldier is tasked to stop an indestructible cyborg killing machine, both sent from 2029, from executing a young woman, whose unborn son is the key to humanity's future salvation.",
                     ImdbRating = 8.0,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BYTViNzMxZjEtZGEwNy00MDNiLWIzNGQtZDY2MjQ1OWViZjFmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/k64P4l2Wmeg",
                     Price = 89,
                     InStock = 17,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 15,
                     ImdbId = "tt2872732",
                     Title = "Lucy",
                     Year = 2014,
                     RunTime = "89",
                     Genre = "Action, Sci-Fi, Thriller",
                     Director = "Luc Besson",
                     Actors = "Scarlett Johansson, Morgan Freeman, Min-Sik Choi",
                     Plot = "A woman, accidentally caught in a dark deal, turns the tables on her captors and transforms into a merciless warrior evolved beyond human logic. ",
                     ImdbRating = 6.4,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BODcxMzY3ODY1NF5BMl5BanBnXkFtZTgwNzg1NDY4MTE@._V1_SY1000_CR0,0,631,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/bN7ksFEVO9U",
                     Price = 119,
                     InStock = 19,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 16,
                     ImdbId = "tt0137523",
                     Title = "Fight Club",
                     Year = 1999,
                     RunTime = "139",
                     Genre = "Drama",
                     Director = "David Fincher",
                     Actors = "Brad Pitt, Edward Norton, Helena Bonham Carter",
                     Plot = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more. ",
                     ImdbRating = 8.8,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/qtRKdVHc-cE",
                     Price = 119,
                     InStock = 7,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 17,
                     ImdbId = "tt0172495",
                     Title = "Gladiator",
                     Year = 2000,
                     RunTime = "155",
                     Genre = "Action, Drama, Adventure",
                     Director = "Ridley Scott",
                     Actors = "Russel Crowe, Joaquin Phoenix, Connie Nielsen",
                     Plot = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                     ImdbRating = 8.5,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDliMmNhNDEtODUyOS00MjNlLTgxODEtN2U3NzIxMGVkZTA1L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/Q-b7B8tOAQU",
                     Price = 109,
                     InStock = 12,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 18,
                     ImdbId = "tt1051906",
                     Title = "The Invisible Man",
                     Year = 2020,
                     RunTime = "124",
                     Genre = "Horror, Mystery, Sci-Fi",
                     Director = "Leigh Whannell",
                     Actors = "Elisabeth Moss, Oliver Jackson-Cohen, Harriet Dyer",
                     Plot = "When Cecilia's abusive ex takes his own life and leaves her his fortune, she suspects his death was a hoax. As a series of coincidences turn lethal, Cecilia works to prove that she is being hunted by someone nobody can see.",
                     ImdbRating = 7.1,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BZjFhM2I4ZDYtZWMwNC00NTYzLWE3MDgtNjgxYmM3ZWMxYmVmXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,631,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/Pso0Aj_cTh0",
                     Price = 229,
                     InStock = 35,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 19,
                     ImdbId = "tt3322940",
                     Title = "Annabelle",
                     Year = 2014,
                     RunTime = "109",
                     Genre = "Horror, Mystery, Thriller",
                     Director = "John R. Leonetti",
                     Actors = "Ward Horton, Annabelle Wallis, Alfre Woodard",
                     Plot = "A couple begins to experience terrifying supernatural occurrences involving a vintage doll shortly after their home is invaded by satanic cultists.",
                     ImdbRating = 5.4,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BOTQwZmQyYzEtODk5ZC00OTY3LWExMjAtYzRjNWFhNGM3MzBlXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/paFgQNPGlsg",
                     Price = 129,
                     InStock = 16,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 20,
                     ImdbId = "tt1457767",
                     Title = "The Conjuring",
                     Year = 2013,
                     RunTime = "112",
                     Genre = "Horror, Mystery, Thriller",
                     Director = "James Wan",
                     Actors = "Patrick Wilson, Vera Farmiga, Ron Livingston",
                     Plot = "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.",
                     ImdbRating = 7.5,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTM3NjA1NDMyMV5BMl5BanBnXkFtZTcwMDQzNDMzOQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/k10ETZ41q5o",
                     Price = 149,
                     InStock = 22,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 21,
                     ImdbId = "tt6751668",
                     Title = "Parasite",
                     Year = 2019,
                     RunTime = "132",
                     Genre = "Comedy, Drama, Thriller",
                     Director = "Bong Joon Ho",
                     Actors = "Kang-ho Son, Sun-Kyun Lee, Yeo-Yeong Jo",
                     Plot = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan. ",
                     ImdbRating = 8.6,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/5xH0HfJHsaY",
                     Price = 199,
                     InStock = 30,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 22,
                     ImdbId = "tt1670345",
                     Title = "Now You See Me",
                     Year = 2013,
                     RunTime = "115",
                     Genre = "Crime, Mystery, Thriller",
                     Director = "Louis Leterrier",
                     Actors = "Jesse Eisenberg, Mark Ruffalo, Woody Harrelson",
                     Plot = "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money. ",
                     ImdbRating = 7.3,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTY0NDY3MDMxN15BMl5BanBnXkFtZTcwOTM5NzMzOQ@@._V1_SY1000_CR0,0,642,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/4OtM9j2lcUA",
                     Price = 99,
                     InStock = 18,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 23,
                     ImdbId = "tt0848228",
                     Title = "The Avengers",
                     Year = 2012,
                     RunTime = "143",
                     Genre = "Action, Adventure, Sci-Fi",
                     Director = "Joss Whedon",
                     Actors = "Robert Downey Jr., Chris Evans, Scarlett Johansson",
                     Plot = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity. ",
                     ImdbRating = 8.0,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/hIR8Ar-Z4hw",
                     Price = 129,
                     InStock = 21,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 24,
                     ImdbId = "tt3501632",
                     Title = "Thor Ragnarök",
                     Year = 2017,
                     RunTime = "130",
                     Genre = "Action, Adventure, Comedy",
                     Director = "Taika Waititi",
                     Actors = "Chris Hemsworth, Tom Hiddleston, Cate Blanchett",
                     Plot = "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela. ",
                     ImdbRating = 7.9,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjMyNDkzMzI1OF5BMl5BanBnXkFtZTgwODcxODg5MjI@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/v7MGUNV8MxU",
                     Price = 179,
                     InStock = 39,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 25,
                     ImdbId = "tt0241527",
                     Title = "Harry Potter and the Philosophers Stone",
                     Year = 2001,
                     RunTime = "152",
                     Genre = "Adventure, Family, Fantasy",
                     Director = "Chris Columbus",
                     Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson",
                     Plot = "An orphaned boy enrolls in a school of wizardry, where he learns the truth about himself, his family and the terrible evil that haunts the magical world. ",
                     ImdbRating = 7.6,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/VyHV0BRtdxo",
                     Price = 109,
                     InStock = 14,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 26,
                     ImdbId = "tt0096283",
                     Title = "My Neighbour Totoro",
                     Year = 1988,
                     RunTime = "86",
                     Genre = "Animation, Family, Fantasy",
                     Director = "Hayao Miyazaki",
                     Actors = "Hitoshi Takagi, Noriko Hidaka, Chika Sakamoto",
                     Plot = "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.",
                     ImdbRating = 8.2,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzJjMTYyMjQtZDI0My00ZjE2LTkyNGYtOTllNGQxNDMyZjE0XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/92a7Hj0ijLs",
                     Price = 79,
                     InStock = 28,
                     AddedToStoreDate = DateTime.Now
  
                 },
                 new Movie
                 {
                     Id = 27,
                     ImdbId = "tt0347149",
                     Title = "Howl's Moving Castle",
                     Year = 2004,
                     RunTime = "119",
                     Genre = "Animation, Adventure, Family",
                     Director = "Hayao Miyazaki",
                     Actors = "Chieko Baishô, Takuya Kimura, Tatsuya Gashûin",
                     Plot = "When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.",
                     ImdbRating = 8.2,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BNmM4YTFmMmItMGE3Yy00MmRkLTlmZGEtMzZlOTQzYjk3MzA2XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/yUZCo0oWt4o",
                     Price = 79,
                     InStock = 25,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 28,
                     ImdbId = "tt0245429",
                     Title = "Spirited Away",
                     Year = 2001,
                     RunTime = "125",
                     Genre = "Animation, Adventure, Family",
                     Director = "Hayao Miyazaki",
                     Actors = "Rumi Hiiragi, Miyu Irino, Mari Natsuki",
                     Plot = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
                     ImdbRating = 8.6,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjlmZmI5MDctNDE2YS00YWE0LWE5ZWItZDBhYWQ0NTcxNWRhXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/qCgon52mp2M",
                     Price = 79,
                     InStock = 18,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 29,
                     ImdbId = "tt1359421",
                     Title = "Bröllopsfotografen",
                     Year = 2009,
                     RunTime = "113",
                     Genre = "Comedy, Drama, Romance",
                     Director = "Ulf Malmros",
                     Actors = "Björn A. Ling, Kjell Bergqvist, Tuva Novotny",
                     Plot = "When the factory in Molkom shuts down, Robin leaves his beloved hometown to try his luck in Stockholm as a wedding photographer. This experience changes not merely his outlook on life but also his hairstyle.",
                     ImdbRating = 5.9,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzgxMTU3YjEtZjQ2NS00MTA5LTk3ZTItMzkyODI3NTMzYTM5XkEyXkFqcGdeQXVyMTQzMjU1NjE@._V1_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/j2Ai6zAzkOQ",
                     Price = 79,
                     InStock = 3,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 30,
                     ImdbId = "tt0323998",
                     Title = "Smala Sussie",
                     Year = 2003,
                     RunTime = "117",
                     Genre = "Comedy, Crime, Mystery",
                     Director = "Ulf Malmros",
                     Actors = "Tuva Novotny, Jonas Rimeika, Björn A. Ling",
                     Plot = "A young man returns to his hometown to look for his missing sister.",
                     ImdbRating = 6.9,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTMxMTEwNzI3Nl5BMl5BanBnXkFtZTcwMzQ1ODkyMQ@@._V1_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/Q8Drrm6Mlco",
                     Price = 79,
                     InStock = 5,
                     AddedToStoreDate = DateTime.Now

                 },
                 new Movie
                 {
                     Id = 31,
                     ImdbId = "tt1392190",
                     Title = "Mad Max: Fury Road",
                     Year = 2015,
                     RunTime = "120",
                     Genre = "Action, Adventure, Sci-Fi",
                     Director = "George Miller",
                     Actors = "Tom Hardy, Charlize Theron, Nicholas Hoult",
                     Plot = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners, a psychotic worshiper, and a drifter named Max.",
                     ImdbRating = 8.1,
                     PosterUrl = "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
                     TrailerUrl = "https://www.youtube.com/embed/hEJnMQG9ev8",
                     Price = 159,
                     InStock = 20,
                     AddedToStoreDate = DateTime.Now

                 }

               //new Movie
               //{
               //    Id = "",
               //    ImdbId = "",
               //    Title = "",
               //    Year = ,
               //    RunTime = "",
               //    Genre = "",
               //    Director = "",
               //    Actors = "",
               //    Plot = "",
               //    ImdbRating = ,
               //    PosterUrl = "",
               //    TrailerUrl = "",
               //    Price = ,
               //    InStock = ,
               //    AddedToStoreDate = DateTime.Now

               //}

               );
        }
    }
}
