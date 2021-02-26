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
    public class CinemaLaUnionController : Controller
    {
        // GET: CinemaLaUnion
        public ActionResult Index()
        {
            TMDbClient client = new TMDbClient("38a98b7311a75b1913c0c24280d13024");

            SearchContainer<SearchMovie> popularMovies = client.GetMovieUpcomingListAsync("es", 1, region: null).Result;
            List<SearchMovie> popularMovieList = popularMovies.Results;

            SearchContainer<SearchMovie> scPeliculasEnCartelera = client.GetMovieNowPlayingListAsync("es", 1, region: null).Result;
            List<SearchMovie> listPeliculasEnCartelera = scPeliculasEnCartelera.Results;



            IndexModel indexModel = new IndexModel();

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
                p.PosterPath = "https://image.tmdb.org/t/p/w500" + m.PosterPath;
                p.ReleaseDate = m.ReleaseDate;
                p.Homepage = m.Homepage;
                p.Recommendations = m.Recommendations;
                p.Revenue = m.Revenue;
                p.Runtime = m.Runtime;
                p.Video = m.Video;
                p.VoteAverage = m.VoteAverage;
                p.Overview = m.Overview;
                p.Genres = m.Genres;

                p.listVideo= client.GetMovieVideosAsync(p.Id).Result;
                

                
                indexModel.listProximasPeliculas.Add(p);
            }


            foreach (SearchMovie searchPeliculasEnCartelera in listPeliculasEnCartelera)
            {
                Movie m = client.GetMovieAsync(searchPeliculasEnCartelera.Id).Result;
                Pelicula p = new Pelicula();
                p.Id = m.Id;
                p.Images = m.Images;
                p.Title = m.Title;
                p.BackdropPath = "https://image.tmdb.org/t/p/w500" + m.BackdropPath;
                p.Credits = m.Credits;
                p.Reviews = m.Reviews;
                p.PosterPath = "https://image.tmdb.org/t/p/w500" + m.PosterPath;
                p.ReleaseDate = m.ReleaseDate;
                p.Homepage = m.Homepage;
                p.Recommendations = m.Recommendations;
                p.Revenue = m.Revenue;
                p.Runtime = m.Runtime;
                p.Video = m.Video;
                p.Overview = m.Overview;
                p.VoteAverage = m.VoteAverage;
                p.Genres = m.Genres;
                p.listVideo = client.GetMovieVideosAsync(m.Id).Result;
                p.trailerPath = "https://www.youtube.com/watch?v="+ client.GetMovieVideosAsync(m.Id).Result.Results.ElementAt(0).Key;
                indexModel.listPeliculasEnCartelera.Add(p);
            }

            return View(indexModel);

        }

        
        public ActionResult DetallePelicula(Pelicula p)
        {
                    return View(p);

        }
    }
}