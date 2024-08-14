using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedures
{
    
    public class ClsExamen
    {
        public int tipoGuardado { get; set; }
        public ClsExamen(int tipo_guardado)
        {
            this.tipoGuardado =  tipo_guardado;
        }

        public bool AgregarExamen(string nombre, string descripcion)
        {
            bool respuesta = false;
            apiexamen sps = new apiexamen();
            try
            {
                if (this.tipoGuardado == 1)
                {
                  
                    string rep = sps.guardar(nombre, descripcion).Substring(0, 1);
                    respuesta = bool.Parse(rep);
                    return respuesta;
                }
                else
                {
                    string urluncode = "https://localhost:44370/WsApiexamen/AgregarExamen?nombre=" + nombre + "&descripcion=" + descripcion;
                    RestRequest request = new RestRequest();
                    request.RequestFormat = DataFormat.Json;
                    request.Timeout = 60000;
                    request.Method = Method.POST;
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    //request.AddParameter("nombre",nombre);
                    //request.AddParameter("descripcion", descripcion);
                    RestClient conexion = new RestClient(urluncode);
                    conexion.Timeout = 60000;
                    var requestcon = conexion.Execute(request);
                    if (requestcon.Content.Contains("Correctamente"))
                    {
                        respuesta = true;
                        return respuesta;
                    }
                    else
                    {


                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        public bool ActualizarExamen(int idExamen, string nombre, string descripcion)
        {
            bool respuesta = false;
            try
            {
                if (this.tipoGuardado == 1)
                {
                    apiexamen sps = new apiexamen();
                    string rep = sps.actualizar(idExamen, nombre, descripcion).Substring(0, 1);
                    respuesta = bool.Parse(rep);
                    return respuesta;
                }
                else
                {
                    string urluncode = "https://localhost:44370/WsApiexamen/ActualizarExamen?idExamen=" + idExamen + "&nombre=" + nombre + "&descripcion=" + descripcion;
                    RestRequest request = new RestRequest();
                    request.RequestFormat = DataFormat.Json;
                    request.Timeout = 60000;
                    request.Method = Method.POST;
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    //request.AddParameter("idExamen", idExamen);
                    //request.AddParameter("nombre", nombre);
                    //request.AddParameter("descripcion", descripcion);
                    RestClient conexion = new RestClient(urluncode);
                    conexion.Timeout = 60000;
                    var requestcon = conexion.Execute(request);
                    respuesta = bool.Parse(requestcon.ToString());
                    if (requestcon.Content.Contains("Correctamente"))
                    {
                        respuesta = true;
                        return respuesta;
                    }
                    else
                    {


                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

        }

        public List<BdiExamen> ConsultarExamen(int ?idExamen)
        {
            List<BdiExamen> rep = new List<BdiExamen>();
            try
            {
                if (this.tipoGuardado == 1)
                {
                    apiexamen sps = new apiexamen();
                    rep = sps.consultar(idExamen);
                    return rep;
                }
                else
                {
                    string urluncode = "https://localhost:44370/WsApiexamen/ConsultarExamen?idExamen=" + idExamen;
                    RestRequest request = new RestRequest();
                    request.RequestFormat = DataFormat.Json;
                    request.Timeout = 60000;
                    request.Method = Method.POST;
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    //request.AddParameter("idExamen", idExamen);
                    RestClient conexion = new RestClient(urluncode);
                    conexion.Timeout = 60000;
                    var requestcon = conexion.Execute(request);

                    string res;
                    res = requestcon.Content;
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    // solicitud = JsonConvert.DeserializeObject<Models.Entidades.ListResponseAdd>(res, settings);


                    rep = JsonConvert.DeserializeObject<List<BdiExamen>>(res);

                    return rep;
                }
            }
            catch
            {
                return rep;
            }

        }

        public bool EliminarExamen(int idExamen)
        {
            bool respuesta = false;
            try
            {
                if (this.tipoGuardado == 1)
                {
                    apiexamen sps = new apiexamen();
                    string rep = sps.eliminar(idExamen);
                    respuesta = bool.Parse(rep);
                    return respuesta;
                }
                else
                {
                    string urluncode = "https://localhost:44370/WsApiexamen/EliminarExamen?idExamen=" + idExamen;
                    RestRequest request = new RestRequest();
                    request.RequestFormat = DataFormat.Json;
                    request.Timeout = 60000;
                    request.Method = Method.POST;
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    request.AddParameter("idExamen", idExamen);
                    RestClient conexion = new RestClient(urluncode);
                    conexion.Timeout = 60000;
                    var requestcon = conexion.Execute(request);
                    respuesta = bool.Parse(requestcon.ToString());
                    return respuesta;
                }
            }
            catch
            {
                return false;
            }

        }


    }
}
