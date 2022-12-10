using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {

        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;
                        collection[1] = new SqlParameter("@IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;
                        collection[2] = new SqlParameter("@NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;
                        collection[3] = new SqlParameter("@FechaPublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;
                        collection[4] = new SqlParameter("@IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;
                        collection[5] = new SqlParameter("@Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;
                        collection[6] = new SqlParameter("@IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Libro libro)
        {
            //instancia de result
            ML.Result result = new ML.Result();
            try
            {
                //SqlCnnnection es para la conexion a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar y ejecutar querys de sql
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 



                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;


                        //pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
    }
}
