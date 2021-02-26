using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Models;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using Movie = TMDbLib.Objects.Movies.Movie;

namespace Test2.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index()
        {
            TMDbClient client = new TMDbClient("38a98b7311a75b1913c0c24280d13024");
            SearchContainer<SearchMovie> popularMovies = client.GetMoviePopularListAsync("en-US", 1, null).Result;
            List<SearchMovie> popularMovieList = popularMovies.Results;

            List<Models.Movie> listPopularMovies=new List<Models.Movie>();

            foreach (SearchMovie pularMovie in popularMovieList) {
                Models.Movie m = new Models.Movie();
                m.id = pularMovie.Id;
                m.title = pularMovie.Title;
                m.release_date = m.release_date;
                listPopularMovies.Add(m);
            }
                
                return View(listPopularMovies);
        }


        public ActionResult PeliculasPopulares()
        {
            TMDbClient client = new TMDbClient("38a98b7311a75b1913c0c24280d13024");
            SearchContainer<SearchMovie> popularMovies = client.GetMoviePopularListAsync("en-US", 1, null).Result;
            List<SearchMovie> popularMovieList = popularMovies.Results;


            List<Pelicula> listPopularMovies = new List<Pelicula>();

            foreach (SearchMovie pularMovie in popularMovieList)
            {
                Movie m = client.GetMovieAsync(pularMovie.Id).Result;
                Pelicula p = new Pelicula();
                p.Id = m.Id;
                p.Images = m.Images;
                p.Title = m.Title;
                p.BackdropPath = "https://image.tmdb.org/t/p/w500" + m.BackdropPath;
                p.Credits = m.Credits;
                p.Reviews = m.Reviews;
                p.PosterPath = "https://image.tmdb.org/t/p/w500"+m.PosterPath;
                p.ReleaseDate = m.ReleaseDate;
                p.Homepage = m.Homepage;
                p.Recommendations = m.Recommendations;
                p.Revenue = m.Revenue;
                p.Runtime = m.Runtime;
                p.Video = m.Video;
                p.Status = m.Status;
                p.Tagline = m.Tagline;
                p.Overview = m.Overview;
                p.ImdbId = m.ImdbId;
                p.OriginalLanguage = m.OriginalLanguage;
                p.VoteAverage = m.VoteAverage;
                p.Genres = m.Genres;
                
                listPopularMovies.Add(p);
            }
            
            return View(listPopularMovies);
            
        }


        public ActionResult DetallePelicula(Pelicula p)
        {

                    return View(p);


        }
    }
}