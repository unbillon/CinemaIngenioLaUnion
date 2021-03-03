using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2.Models;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Test2.Services
{
    public class ServicePelicula
    {
        public TMDbClient client;
        public SearchContainer<SearchMovie> popularMovies;
        public List<SearchMovie> popularMovieList;
        public SearchContainer<SearchMovie> scPeliculasEnCartelera;
        public List<SearchMovie> listPeliculasEnCartelera;
        IndexModel indexModel;


        public ServicePelicula()
        {
            client = new TMDbClient("38a98b7311a75b1913c0c24280d13024");
            popularMovies = client.GetMovieUpcomingListAsync("es").Result;
            popularMovieList = popularMovies.Results;
            scPeliculasEnCartelera = client.GetMovieNowPlayingListAsync("es").Result;
            listPeliculasEnCartelera = scPeliculasEnCartelera.Results;
            indexModel = new IndexModel();
        }

        public Pelicula obtenerPeliculaServicio(int idPelicula) {
            Movie m = client.GetMovieAsync(idPelicula, "es").Result;
            Pelicula p = new Pelicula();
            p.Id = m.Id;
            p.Images = m.Images;
            p.Title = m.Title;
            p.BackdropPath = "https://image.tmdb.org/t/p/w500" + m.BackdropPath;
            p.Credits = client.GetMovieCreditsAsync(idPelicula).Result;
            p.Images = client.GetMovieImagesAsync(idPelicula).Result;
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
            p.listVideo = client.GetMovieVideosAsync(p.Id).Result;

            try { 
            p.trailerPath = "https://www.youtube.com/embed/" + client.GetMovieVideosAsync(m.Id).Result.Results.ElementAt(0).Key;
            } catch(Exception e)
            {

                p.trailerPath = "TRAILER NO DISPONIBLE";
            }



            return p;

        }

        public List<Pelicula> obtenerPeliculasEnCartelera()
        {
            List<Pelicula> peliculasEnCartelera = new List<Pelicula>();

            using (var db = new INGENIO_LA_UNIONEntities())
            {
                foreach (var enCartelera in db.funcion.ToList())
                {
                    
                    Movie m = client.GetMovieAsync(enCartelera.id_pelicula, "es").Result;

                    Pelicula peliculaTemp = peliculasEnCartelera.Find(x => x.Id == enCartelera.id_pelicula);


                    if (peliculaTemp==null)
                    {
                        Pelicula p = new Pelicula();
                        p.Id = m.Id;
                        p.Images = m.Images;
                        p.Title = m.Title;
                        p.BackdropPath = "https://image.tmdb.org/t/p/w500" + m.BackdropPath;
                        p.Credits = client.GetMovieCreditsAsync(enCartelera.id_pelicula).Result;
                        p.Images = client.GetMovieImagesAsync(enCartelera.id_pelicula).Result;
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
                        p.horario = enCartelera.horario;
                        p.sala = enCartelera.sala;
                        p.listVideo = client.GetMovieVideosAsync(p.Id).Result;
                        p.trailerPath = "https://www.youtube.com/embed/" + client.GetMovieVideosAsync(m.Id).Result.Results.ElementAt(0).Key;
                        peliculasEnCartelera.Add(p);

                    }


                }

            }
            return peliculasEnCartelera;
        }


        public List<Pelicula> obtenerProximosEstrenos()
        {
            List<Pelicula> proximosEstrenos = new List<Pelicula>();

            foreach (SearchMovie pularMovie in popularMovieList)
            {
                Pelicula p = obtenerPeliculaServicio(pularMovie.Id);
                proximosEstrenos.Add(p);
            }

            return proximosEstrenos;
        }

        public Pelicula obtenerFunciones(int idPelicula)
        {
            Pelicula p = obtenerPeliculaServicio(idPelicula);
            using (var db = new INGENIO_LA_UNIONEntities())
            {
                List<funcion> listHorarios = new List<funcion>();
                foreach (var enCartelera in db.funcion.Where(idpelicula => idpelicula.id_pelicula == idPelicula).OrderBy(horario => horario.horario).ToList())
                {
                    funcion f = new funcion();
                    f = enCartelera;

                    sala s = db.sala.Where(idSala => idSala.id_sala == f.id_sala).OrderBy(a => a.nombre_sala).ToList().ElementAt(0);
                    tipo_sala ts = db.tipo_sala.Where(a => a.id_tipo_sala == s.id_tipo_sala).OrderBy(a => a.id_tipo_sala).ToList().ElementAt(0);

                    s.tipo_sala = ts;
                    f.sala = s;
                    listHorarios.Add(f);

                }

               
                p.listFunciones = listHorarios;

            }

            return p;
        }
    
    }
}