using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using RestAPIPlanningActivities.Models;

namespace RestAPIPlanningActivities.Controllers
{
    public class ActividadesController : ApiController
    {
        private MyDbContext db = new MyDbContext();
        // GET: api/Actividades
        //esto de aqui seguramente ni lo use en la version final 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Actividades/5
        //aqui en vez poner el 
        public string Get(string email)
        {
            
            return email;
        }

        // POST: api/Actividades
        public async  Task<HttpResponseMessage> Post (RegisterActivity actividad)
        {
            //abro la conexion de la base de datos 
            db.Database.Connection.Open();
            //antes de introducir los valores al objeto Actividades tengo que convertir en DateTime y en TimeSpan los valores cuando, horarioInicial y horarioFinal
            DateTime horarioInicial = DateTime.Parse(actividad.horarioInicial);
            DateTime horarioFinal = DateTime.Parse(actividad.horarioFinal);
            DateTime cuando = DateTime.Parse(actividad.Cuando);

            //creo el objeto aqui para introducir sus valores que me vienen de actividad 
            Actividades actividades = new Actividades();
            actividades.Nombre = actividad.Nombre;
            actividades.Cuando = cuando;
            actividades.Direccion = actividad.Donde;
            actividades.Informacion = actividad.Informacion;
            actividades.Horarioinicial = horarioInicial;
            actividades.Horariofinal = horarioFinal;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                await db.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }
            response.StatusCode = HttpStatusCode.Accepted;
            return response;

        }

        // PUT: api/Actividades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividades/5
        public void Delete(int id)
        {
        }
    }
}
