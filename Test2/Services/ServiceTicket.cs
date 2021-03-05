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

                string sql = @"select ts.id_ticket_asiento,
                                        ts.id_ticket,
                                        ts.id_asiento,
                                        ts.fecha_ingreso
                                from ticket_asiento ts
                                join ticket t on ts.id_ticket=t.id_ticket
                                where id_funcion="+id;


                

               t.ticket_asiento= db.Database.SqlQuery<ticket_asiento>(sql).ToList(); 

                s.tipo_sala = ts;
                s.asiento = listAsiento;
                f.sala = s;

                t.funcion = f;
                t.pelicula = p;
            }
            return t;

        }

        public ticket obtenerInfoTicketReservado(int idTicket)
        {

            ticket t = new ticket();

            using (var db = new INGENIO_LA_UNIONEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                t = db.ticket.Where(a => a.id_ticket == idTicket).ToList().ElementAt(0);
                funcion f = db.funcion.Where(a => a.id_funcion == t.id_funcion).ToList().ElementAt(0);
                Pelicula p = servicePelicula.obtenerPeliculaServicio(f.id_pelicula);
                sala s = db.sala.Where(a => a.id_sala == f.id_sala).ToList().ElementAt(0);
                tipo_sala ts = db.tipo_sala.Where(a => a.id_tipo_sala == s.id_tipo_sala).ToList().ElementAt(0);
                List<asiento> listAsiento = db.asiento.Where(a => a.id_sala == s.id_sala).ToList().ToList();
                List<ticket_asiento> listTicketAsiento = db.ticket_asiento.Where(a => a.id_ticket == idTicket).ToList();
                //t = db.ticket.Include(c => c.ticket_asiento).ToList());


                s.tipo_sala = ts;
                s.asiento = listAsiento;
                f.sala = s;
                t.ticket_asiento = listTicketAsiento;
                t.funcion = f;
                t.pelicula = p;
            }
            return t;

        }

        public ticket guardarTicketInfo(int idFuncion, int[] arr_asientos_reservados)
        {
            using (var db = new INGENIO_LA_UNIONEntities())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {

                funcion f = db.funcion.Where(a => a.id_funcion == idFuncion).ToList().ElementAt(0);
                List<ticket_asiento> listTicketAsiento = new List<ticket_asiento>();
                ticket t = new ticket();
                t.id_funcion = idFuncion;
                t.funcion = f;
                t.fecha_compra = DateTime.Now;

                db.ticket.Add(t);

                foreach (int asiento_reservado in arr_asientos_reservados)
                {

                    ticket_asiento ts = new ticket_asiento();
                    ts.id_ticket = t.id_ticket;
                    ts.id_asiento = asiento_reservado;
                    ts.fecha_ingreso = DateTime.Now;
                    db.ticket_asiento.Add(ts);
                    listTicketAsiento.Add(ts);
                }

                db.SaveChanges();
                dbContextTransaction.Commit();

                t.ticket_asiento = listTicketAsiento;

                return t;
            }
        }
    }
}