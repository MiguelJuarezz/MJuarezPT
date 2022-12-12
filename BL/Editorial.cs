using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
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

                    var editoriales = context.EditorialGetAll().ToList();

                    result.Objects = new List<object>();

                    if (editoriales != null)
                    {
                        foreach (var obj in editoriales)
                        {
                            ML.Editorial editorialobj = new ML.Editorial();
                            editorialobj.IdEditorial = obj.IdEditorial;
                            editorialobj.Nombre = obj.Nombre;

                            result.Objects.Add(editorialobj);
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
