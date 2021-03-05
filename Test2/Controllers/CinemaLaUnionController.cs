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
        ServiceTicket servictTicket = new ServiceTicket();
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

        public ActionResult GuardarTicket(int id) {
            return View(servictTicket.obtenerTicketInfo(id));
        }

        public ActionResult ticket(int id, int[] arr_asientos_seleccionados) {
            ticket t =servictTicket.guardarTicketInfo(id, arr_asientos_seleccionados);
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("ticketPagina", "CinemaLaUnion", new { id = t.id_ticket });
            return Json(new { Url = redirectUrl });

            //return View(servictTicket.guardarTicketInfo(id, arr_asientos_seleccionados));
        }


        public ActionResult ticketPagina(int id)
        {
           return View(servictTicket.obtenerInfoTicketReservado(id));
        }



    }
}