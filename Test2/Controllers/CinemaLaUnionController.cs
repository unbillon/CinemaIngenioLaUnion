using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Models;
using Test2.Services;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using Movie = TMDbLib.Objects.Movies.Movie;

namespace Test2.Controllers
{
    public class CinemaLaUnionController : Controller
    {
        ServicePelicula servicePelicula = new ServicePelicula();
        // GET: CinemaLaUnion
        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.listProximasPeliculas = servicePelicula.obtenerProximosEstrenos();
            indexModel.listPeliculasEnCartelera = servicePelicula.obtenerPeliculasEnCartelera();
            return View(indexModel);

        }

       
        public ActionResult DetallePelicula(int id)
        {
            
            return View(servicePelicula.obtenerFunciones(id));

        }


    }
}