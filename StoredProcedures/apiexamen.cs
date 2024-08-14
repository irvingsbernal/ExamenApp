using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedures
{
    public class apiexamen
    {
        public apiexamen()
        { }
        public string guardar(string nombre, string descripcion)
        {
            //declaramos una cadena de conexión con los datos de nuestro
            //manejador y la base de datos
            string cadenaconexion = "data source=192.168.24.16;initial catalog=BdiExamen;password=Dbasa01;user id=sa;";
            //una variable boleana para determinar si se realizó la operación
            //que realiza el procedimiento almacenado, la inicializamos como false
            bool success = false;
            //declrarmos la conexión
            SqlConnection LaConexion = null;
            //declaramos una transacción para que todo lo que se realiza en ella, desde una
            //simple inserción hasta multiples o, que involucren más operaciones sobre la
            //base de datos puedan deshacerse si se presenta un error
            SqlTransaction LaTransaccion = null;
            //variable para el valor de retorno
            int codigo_Retorno = 0;
            string descripcion_Retorno = "";
            int id_Examen = 0;
            //iniciamos un try catch
            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = cadenaconexion;
                //se abre la conexión
                LaConexion.Open();
                //se inicia la transacción
                LaTransaccion = LaConexion.BeginTransaction(System.Data.IsolationLevel.Serializable);
                //especificamos el comando, en este caso el nombre del Procedimiento Almacenado
                SqlCommand comando = new SqlCommand("sp_InsertExamen", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                //declaramos el parámetro de retorno
                SqlParameter codigoRetorno = new SqlParameter("@codigoRetorno", SqlDbType.Int);
                SqlParameter descripcionRetorno = new SqlParameter("@descripcionRetorno", SqlDbType.VarChar, 255);
                SqlParameter idExamen = new SqlParameter("@idExamen", SqlDbType.Int);
                //asignamos el valor de retorno
                codigoRetorno.Direction = ParameterDirection.Output;
                descripcionRetorno.Direction = ParameterDirection.Output;
                idExamen.Direction = ParameterDirection.Output;
                comando.Parameters.Add(codigoRetorno);
                comando.Parameters.Add(descripcionRetorno);
                comando.Parameters.Add(idExamen);
                //executamos la consulta
                comando.ExecuteNonQuery();
                // traemos el valor de retorno
                codigo_Retorno = Convert.ToInt32(codigoRetorno.Value);
                descripcion_Retorno = descripcionRetorno.Value.ToString();
                id_Examen = Convert.ToInt32(idExamen.Value);
                //dependiendo del valor de retorno se asigna la variable success
                //si el procedimiento retorna un 1 la operación se realizó con éxito
                //de no ser así se mantiene en false y pr lo tanto falló la operación
                if (codigo_Retorno == 0)
                    success = true;
                if (success == true)
                {
                    return codigoRetorno + " | " + descripcion_Retorno + " | " + id_Examen;
                }
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                //si el procedimeinto se efectuó con éxito
                if (success)
                {
                    //se realiza la transacción
                    LaTransaccion.Commit();
                    //cerramos la conexión
                    LaConexion.Close();
                    //mensaje de operación satisfactoria
                }
                //si se presentó algun error
                else
                {
                    //se deshace la transacción
                    LaTransaccion.Rollback();
                    //cerramos la conexión
                    LaConexion.Close();
                }
            }

            return "guardada satisfactoriamente";
        }

        public string actualizar(int idExamen, string nombre, string descripcion)
        {
            //declaramos una cadena de conexión con los datos de nuestro
            //manejador y la base de datos
            string cadenaconexion = "data source=192.168.24.16;initial catalog=BdiExamen;password=Dbasa01;user id=sa;";
            //una variable boleana para determinar si se realizó la operación
            //que realiza el procedimiento almacenado, la inicializamos como false
            bool success = false;
            //declrarmos la conexión
            SqlConnection LaConexion = null;
            //declaramos una transacción para que todo lo que se realiza en ella, desde una
            //simple inserción hasta multiples o, que involucren más operaciones sobre la
            //base de datos puedan deshacerse si se presenta un error
            SqlTransaction LaTransaccion = null;
            //variable para el valor de retorno
            int codigo_Retorno = 0;
            string descripcion_Retorno = "";
            int id_Examen = 0;
            //iniciamos un try catch
            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = cadenaconexion;
                //se abre la conexión
                LaConexion.Open();
                //se inicia la transacción
                LaTransaccion = LaConexion.BeginTransaction(System.Data.IsolationLevel.Serializable);
                //especificamos el comando, en este caso el nombre del Procedimiento Almacenado
                SqlCommand comando = new SqlCommand("sp_UpdateExamen", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()

                comando.Parameters.AddWithValue("@idExamen", idExamen);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                //declaramos el parámetro de retorno
                SqlParameter codigoRetorno = new SqlParameter("@codigoRetorno", SqlDbType.Int);
                SqlParameter descripcionRetorno = new SqlParameter("@descripcionRetorno", SqlDbType.VarChar, 255);
                //asignamos el valor de retorno
                codigoRetorno.Direction = ParameterDirection.Output;
                descripcionRetorno.Direction = ParameterDirection.Output;
                //idExamen.Direction = ParameterDirection.Output;
                comando.Parameters.Add(codigoRetorno);
                comando.Parameters.Add(descripcionRetorno);
                //comando.Parameters.Add(idExamen);
                //executamos la consulta
                comando.ExecuteNonQuery();
                // traemos el valor de retorno
                codigo_Retorno = Convert.ToInt32(codigoRetorno.Value);
                descripcion_Retorno = descripcionRetorno.Value.ToString();
                //id_Examen = Convert.ToInt32(idExamen.Value);
                //dependiendo del valor de retorno se asigna la variable success
                //si el procedimiento retorna un 1 la operación se realizó con éxito
                //de no ser así se mantiene en false y pr lo tanto falló la operación
                if (codigo_Retorno == 0)
                    success = true;
                if (success == true)
                {
                    return codigoRetorno + " | " + descripcion_Retorno + " | " + id_Examen;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                //si el procedimeinto se efectuó con éxito
                if (success)
                {
                    //se realiza la transacción
                    LaTransaccion.Commit();
                    //cerramos la conexión
                    LaConexion.Close();
                    //mensaje de operación satisfactoria
                }
                //si se presentó algun error
                else
                {
                    //se deshace la transacción
                    LaTransaccion.Rollback();
                    //cerramos la conexión
                    LaConexion.Close();
                }
            }

            return "actualizada satisfactoriamente";
        }

        public string eliminar(int idExamen)
        {
            //declaramos una cadena de conexión con los datos de nuestro
            //manejador y la base de datos
            string cadenaconexion = "data source=192.168.24.16;initial catalog=BdiExamen;password=Dbasa01;user id=sa;";
            //una variable boleana para determinar si se realizó la operación
            //que realiza el procedimiento almacenado, la inicializamos como false
            bool success = false;
            //declrarmos la conexión
            SqlConnection LaConexion = null;
            //declaramos una transacción para que todo lo que se realiza en ella, desde una
            //simple inserción hasta multiples o, que involucren más operaciones sobre la
            //base de datos puedan deshacerse si se presenta un error
            SqlTransaction LaTransaccion = null;
            //variable para el valor de retorno
            int codigo_Retorno = 0;
            string descripcion_Retorno = "";
            int id_Examen = 0;
            //iniciamos un try catch
            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = cadenaconexion;
                //se abre la conexión
                LaConexion.Open();
                //se inicia la transacción
                LaTransaccion = LaConexion.BeginTransaction(System.Data.IsolationLevel.Serializable);
                //especificamos el comando, en este caso el nombre del Procedimiento Almacenado
                SqlCommand comando = new SqlCommand("sp_DeleteExamen", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()

                comando.Parameters.AddWithValue("@idExamen", idExamen);
                //declaramos el parámetro de retorno
                SqlParameter codigoRetorno = new SqlParameter("@codigoRetorno", SqlDbType.Int);
                SqlParameter descripcionRetorno = new SqlParameter("@descripcionRetorno", SqlDbType.VarChar, 255);
                //asignamos el valor de retorno
                codigoRetorno.Direction = ParameterDirection.Output;
                descripcionRetorno.Direction = ParameterDirection.Output;
                //idExamen.Direction = ParameterDirection.Output;
                comando.Parameters.Add(codigoRetorno);
                comando.Parameters.Add(descripcionRetorno);
                //comando.Parameters.Add(idExamen);
                //executamos la consulta
                comando.ExecuteNonQuery();
                // traemos el valor de retorno
                codigo_Retorno = Convert.ToInt32(codigoRetorno.Value);
                descripcion_Retorno = descripcionRetorno.Value.ToString();
                //id_Examen = Convert.ToInt32(idExamen.Value);
                //dependiendo del valor de retorno se asigna la variable success
                //si el procedimiento retorna un 1 la operación se realizó con éxito
                //de no ser así se mantiene en false y pr lo tanto falló la operación
                if (codigo_Retorno == 0)
                    success = true;
                if (success == true)
                {
                    return codigoRetorno + " | " + descripcion_Retorno + " | " + id_Examen;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                //si el procedimeinto se efectuó con éxito
                if (success)
                {
                    //se realiza la transacción
                    LaTransaccion.Commit();
                    //cerramos la conexión
                    LaConexion.Close();
                    //mensaje de operación satisfactoria
                }
                //si se presentó algun error
                else
                {
                    //se deshace la transacción
                    LaTransaccion.Rollback();
                    //cerramos la conexión
                    LaConexion.Close();
                }
            }

            return "Eliminado satisfactoriamente";
        }

        public List<BdiExamen> consultar(int ?idExamen )
        {
            //declaramos una cadena de conexión con los datos de nuestro
            //manejador y la base de datos
            string cadenaconexion = "data source=192.168.24.16;initial catalog=BdiExamen;password=Dbasa01;user id=sa;";
            //una variable boleana para determinar si se realizó la operación
            //que realiza el procedimiento almacenado, la inicializamos como false
            bool success = false;
            //declrarmos la conexión
            SqlConnection LaConexion = null;
            //declaramos una transacción para que todo lo que se realiza en ella, desde una
            //simple inserción hasta multiples o, que involucren más operaciones sobre la
            //base de datos puedan deshacerse si se presenta un error
            SqlTransaction LaTransaccion = null;
            //variable para el valor de retorno
            int codigo_Retorno = 0;
            BdiExamen resp;
            List<BdiExamen> lisExamen = new List<BdiExamen>();
            //iniciamos un try catch
            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = cadenaconexion;
                //se abre la conexión
                LaConexion.Open();
                //se inicia la transacción
                LaTransaccion = LaConexion.BeginTransaction(System.Data.IsolationLevel.Serializable);
                //especificamos el comando, en este caso el nombre del Procedimiento Almacenado
                SqlCommand comando = new SqlCommand("sp_GetExamen", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                if (idExamen != null)
                {
                    comando.Parameters.AddWithValue("@idExamen", idExamen);
                }
                
                // Read the results returned by the stored procedure.
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    resp = new BdiExamen();
                    resp.idExamen =int.Parse( registro["idExamen"].ToString());
                    resp.nombre = registro["nombre"].ToString();
                    resp.descripcion = registro["descripcion"].ToString();
                    lisExamen.Add(resp);
                }
                registro.Close();
                if (codigo_Retorno == 0)
                    success = true;
                if (success == true)
                {
                    return lisExamen;
                }

            }
            catch (Exception ex)
            {
                return lisExamen;
            }
            finally
            {
                //si el procedimeinto se efectuó con éxito
                if (success)
                {
                    //se realiza la transacción
                    LaTransaccion.Commit();
                    //cerramos la conexión
                    LaConexion.Close();
                    //mensaje de operación satisfactoria
                }
                //si se presentó algun error
                else
                {
                    //se deshace la transacción
                    LaTransaccion.Rollback();
                    //cerramos la conexión
                    LaConexion.Close();
                }
            }

            return lisExamen;
        }

    }


}
