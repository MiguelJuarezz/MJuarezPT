using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezPTEntities2 context = new DL_EF.MJuarezPTEntities2())
                {
                    //libro.Rol.IdRol = (libro.Rol.IdRol == null) ? 0 : libro.Rol.IdRol;
                    //libro.Nombre = (libro.Nombre == null) ? "" : libro.Nombre;
                    //libro.ApellidoPaterno = (libro.ApellidoPaterno == null) ? "" : libro.ApellidoPaterno;

                    var autores = context.AutorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (autores != null)
                    {
                        foreach (var obj in autores)
                        {
                            ML.Autor autorobj = new ML.Autor();
                            autorobj.IdAutor = obj.IdAutor;
                            autorobj.Nombre = obj.Nombre;

                            result.Objects.Add(autorobj);
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
    }
}
