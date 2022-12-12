using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Libro libro = new ML.Libro();
            ML.Result result = new ML.Result();

            libro.Autor = new ML.Autor();
            //libro.Editorial = new ML.Editorial();
            //libro.Genero = new ML.Genero();

            ML.Result resultAutor = BL.Autor.GetAll();
            //ML.Result resultEditorial = BL.Editorial.GetAll();
            //ML.Result resultGenero = BL.Genero.GetAll();


            result = BL.Libro.GetAllEF(libro);


            if (result.Correct)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Libros = result.Objects;
                return View(libro);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            ML.Result resultAutor = BL.Autor.GetAll();
            result = BL.Libro.GetAllEF(libro);


            if (result.Correct)
            {
                libro.Libros = result.Objects;
                libro.Autor.Autores = resultAutor.Objects;

                return View(libro);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
           

            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultGeneros = BL.Genero.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();

            if (IdLibro == null)
            {
                libro.Autor.Autores = resultAutores.Objects;
                libro.Editorial.Editoriales = resultEditoriales.Objects;
                libro.Genero.Generos = resultGeneros.Objects;
                return View(libro);
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutores.Objects;
                    libro.Editorial.Editoriales = resultEditoriales.Objects;
                    libro.Genero.Generos = resultGeneros.Objects;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el usuario seleccionado";
                }
                return View(libro);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];

            //if (file.ContentLength > 0)
            //{
            //    usuario.Imagen = ConvertToBytes(file);
            //}

            if (libro.IdLibro == 0)
            {
                //add
                result = BL.Libro.AddEF(libro);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado el usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                //update
                result = BL.Libro.UpdateEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha Actualizado el usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
        }

        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            result = BL.Libro.DeleteEF(IdLibro);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha elimnado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha elimnado el registro" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }



    }
}