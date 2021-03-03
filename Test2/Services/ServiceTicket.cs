using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2.Models;

namespace Test2.Services
{
    public class ServiceTicket
    {
        ServicePelicula servicePelicula = new ServicePelicula();
        public ticket obtenerTicketInfo(int id)
        {
            
            ticket t = new ticket();
            
            using (var db = new INGENIO_LA_UNIONEntities())
            {
                funcion f = db.funcion.Where(a => a.id_funcion == id).ToList().ElementAt(0);
                Pelicula p = servicePelicula.obtenerPeliculaServicio(f.id_pelicula);
                sala s = db.sala.Where(a => a.id_sala == f.id_sala).ToList().ElementAt(0);
                tipo_sala ts = db.tipo_sala.Where(a => a.id_tipo_sala == s.id_tipo_sala).ToList().ElementAt(0);
                List<asiento> listAsiento = db.asiento.Where(a => a.id_sala == s.id_sala).ToList().ToList();
                s.tipo_sala = ts;
                s.asiento = listAsiento;
                f.sala = s;
                
                t.funcion = f;
                t.pelicula = p;
            }
            return t;

        }
    }
}