using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            //comentario
            //comentario2
            try
            {
                string sql = @"select	a.Id as ID,
		                                a.Nombres,
		                                a.Apellidos,
		                                a.Edad,
		                                a.Sexo,
		                                a.FechaRegistro,
		                                c.Nombre as nombreCiudad		
                                from		Alumno		a
                                inner join	Ciudad		c	on (a.CodCiudad=c.Id);";
                using (var db = new INGENIO_LA_UNIONEntities())
                {
                    /*var data = from a in db.Alumno
                               join c in db.Ciudad on a.CodCiudad equals c.id
                               select new AlumnoCE() {
                                   ID = a.ID,
                                   Nombres = a.Nombres,
                                   Apellidos=a.Apellidos,
                                   Edad=a.Edad,
                                   Sexo=a.Sexo,
                                   nombreCiudad=c.Nombre,
                                   FechaRegistro=a.FechaRegistro

                               };
                    */
                    return View(db.Database.SqlQuery<AlumnoCE>(sql).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            //INGENIO_LA_UNIONEntities db = new INGENIO_LA_UNIONEntities();
            //List<Alumno> lista= db.Alumno.Where(a=>a.Edad>18).ToList();
            
        }

        public ActionResult Agregar2() {
            return View();
        }

        public ActionResult ListaCiudades() {
            using (var db = new INGENIO_LA_UNIONEntities()) {
                return PartialView(db.Ciudad.ToList());
            }
        }
        public ActionResult Agregar() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (INGENIO_LA_UNIONEntities db = new INGENIO_LA_UNIONEntities())
                {
                    db.Alumno.Add(a);
                    a.FechaRegistro = DateTime.Now;
                    db.SaveChanges();
                    
                    return RedirectToAction("index");
                }


            }
            catch (Exception e)
            {

                ModelState.AddModelError("","Error al agregar al alumno: "+e.Message);
                return View();
            }
            
        }

        public ActionResult Editar(int id) {

            using (var db = new INGENIO_LA_UNIONEntities()) {

                //Alumno al = db.Alumno.Where(a => a.ID == id).FirstOrDefault();
                Alumno al2 = db.Alumno.Find(id);
                return View(al2);

            }
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {

            try
            {
                using (var db = new INGENIO_LA_UNIONEntities()) {

                    if (!ModelState.IsValid)
                        return View();
                    Alumno al = db.Alumno.Find(a.ID);
                    //Podemos validar si no lo encuentra que haga algo.

                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult DetalleAlumno(int id) {

            try
            {
                using (var db = new INGENIO_LA_UNIONEntities())
                {
                    Alumno al2 = db.Alumno.Find(id);
                    return View(al2);

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        public ActionResult EliminarAlumno(int id) {

            try
            {
                using (var db = new INGENIO_LA_UNIONEntities())
                {
                    Alumno al2 = db.Alumno.Find(id);
                    db.Alumno.Remove(al2);
                    db.SaveChanges();
                    return RedirectToAction("index");

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static String NombreCiudad(int codCiudad) {
            using (var db = new INGENIO_LA_UNIONEntities()) {
                return db.Ciudad.Find(codCiudad).Nombre;
            }
        }


    }
    
}
