using StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace WsApiexamen.Controllers
{
    public class WsApiexamenController : ApiController
    {


        [OperationContract]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.Route("WsApiexamen/AgregarExamen")]
        //[WebInvoke(UriTemplate = "/Consulta/agregar", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public string AgregarExamen(string nombre, string descripcion)
        {
            try
            {
                var contexto = new BdiExamenEntities();


                var examen = new tblExamen()
                {
                    nombre = nombre,
                    descripcion = descripcion
                };
                contexto.tblExamen.Add(examen);
                contexto.SaveChanges();

                contexto.Dispose();

                return "Registro Correctamente el Examen";
            }
            catch
            {
                return "Error al agregar Datos";
            }
        }

        [OperationContract]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.Route("WsApiexamen/ActualizarExamen")]
        //[WebInvoke(UriTemplate = "/Consulta/agregar", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public string ActualizarExamen(int idExamen, string nombre, string descripcion)
        {

            try
            {

                using (var context = new BdiExamenEntities())

                {

                    var examen = context.tblExamen.Find(idExamen);

                    examen.nombre = nombre;
                    examen.descripcion = descripcion;

                    context.SaveChanges();

                }


                return "Registro Correctamente el Examen";
              }
            catch(Exception ex)
            {
                return "Error al agregar Datos " + ex.Message;
            }
        }

        [OperationContract]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.Route("WsApiexamen/EliminarExamen")]
        //[WebInvoke(UriTemplate = "/Consulta/agregar", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public string EliminarExamen(int idExamen)
        {
            try
            {
                using (var context = new BdiExamenEntities())

            {

                var examen = context.tblExamen.Find(idExamen);

                context.tblExamen.Remove(examen);

                context.SaveChanges();

            }
              return "Eliminado Correctamente el Examen";
              }
            catch(Exception ex)
            {
                return "Error al agregar Datos " + ex.Message;
            }
        }

        [OperationContract]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.Route("WsApiexamen/ConsultarExamen")]
        //[WebInvoke(UriTemplate = "/Consulta/agregar", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public List<tblExamen> ConsultarExamen(int ?idExamen)
        {

            using (var context = new BdiExamenEntities())
            {
                if (idExamen != null)
                {
                    var examenes = context.tblExamen.Where(b => b.idExamen == idExamen).ToList();
                    return examenes;
                }
                else
                {
                    var examenes = context.tblExamen.ToList();
                    return examenes;
                }
            }
        }

    }
}
