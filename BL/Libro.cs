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

        public static ML.Result Update(ML.Libro libro)
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
                        cmd.CommandText = "LibroUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;
                        collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;
                        collection[2] = new SqlParameter("@IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;
                        collection[3] = new SqlParameter("@NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;
                        collection[4] = new SqlParameter("@FechaPublicacion", SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;
                        collection[5] = new SqlParameter("@IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;
                        collection[6] = new SqlParameter("@Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;
                        collection[7] = new SqlParameter("@IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;


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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //aqui voy a almacenar la información
                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {
                            //mi lista
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.Autor  = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.NumeroPaginas = int.Parse(row[3].ToString());
                                libro.FechaPublicacion = row[4].ToString();
                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[5].ToString());
                                libro.Edicion = row[6].ToString();
                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[7].ToString());
                                libro.Autor.Nombre = row[8].ToString();
                                libro.Editorial.Nombre = row[9].ToString();
                                libro.Genero.Nombre = row[10].ToString();


                                result.Objects.Add(libro);
                            }
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

        public static ML.Result GetById(int idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = idLibro;

                        cmd.Parameters.AddRange(collection);

                        //aqui voy a almacenar la información
                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {
                            //DataRow row = new DataRow(tableUsuario.Rows);
                            DataRow row = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.NumeroPaginas = int.Parse(row[3].ToString());
                            libro.FechaPublicacion = row[4].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[5].ToString());
                            libro.Edicion = row[6].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());
                            libro.Autor.Nombre = row[8].ToString();
                            libro.Editorial.Nombre = row[9].ToString();
                            libro.Genero.Nombre = row[10].ToString();


                            //boxing
                            //Almacenar cualquier tipo de dato en un dato object
                            result.Object = libro;

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

        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {


                    var query = context.LibroAdd(libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion,
                        libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {

                    var query = context.LibroDelete(IdLibro);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {
                    var updateResult = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas,
                        libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {
                    //libro.Rol.IdRol = (libro.Rol.IdRol == null) ? 0 : libro.Rol.IdRol;
                    //libro.Nombre = (libro.Nombre == null) ? "" : libro.Nombre;
                    //libro.ApellidoPaterno = (libro.ApellidoPaterno == null) ? "" : libro.ApellidoPaterno;

                    var libros = context.LibroGetAll().ToList();

                    result.Objects = new List<object>();

                    if (libros != null)
                    {
                        foreach (var obj in libros)
                        {
                            ML.Libro libroobj = new ML.Libro();
                            libroobj.IdLibro = obj.IdLibro;
                            libroobj.Nombre = obj.Nombre;
                            libroobj.Autor = new ML.Autor();
                            libroobj.Autor.IdAutor = obj.IdAutor.Value;
                            libroobj.NumeroPaginas = obj.NumeroPaginas.Value;
                            libroobj.FechaPublicacion = obj.FechaPublicacion.ToString();
                            libroobj.Editorial = new ML.Editorial();
                            libroobj.Editorial.IdEditorial = obj.IdEditorial.Value;
                            libroobj.Edicion = obj.Edicion;
                            libroobj.Genero = new ML.Genero();
                            libroobj.Genero.IdGenero = obj.IdGenero.Value;
                            libroobj.Autor.Nombre = obj.AutorNombre;
                            libroobj.Editorial.Nombre = obj.EditorialNombre;
                            libroobj.Genero.Nombre = obj.GeneroNombre;

                            result.Objects.Add(libroobj);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result GetByIdEF(int idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {

                    var objLibro = context.LibroGetById(idLibro).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objLibro != null)
                    {

                        ML.Libro libro = new ML.Libro();
                        libro.IdLibro = objLibro.IdLibro;
                        libro.Nombre = objLibro.Nombre;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = objLibro.IdAutor.Value;
                        libro.NumeroPaginas = objLibro.NumeroPaginas.Value;
                        libro.FechaPublicacion = objLibro.FechaPublicacion.ToString();
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = objLibro.IdEditorial.Value;
                        libro.Edicion = objLibro.Edicion;
                        libro.Genero = new ML.Genero();
                        libro.Genero.IdGenero = objLibro.IdGenero.Value;
                        libro.Autor.Nombre = objLibro.AutorNombre;
                        libro.Editorial.Nombre = objLibro.EditorialNombre;
                        libro.Genero.Nombre = objLibro.GeneroNombre;

                        result.Object = libro;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla usuarios";
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
