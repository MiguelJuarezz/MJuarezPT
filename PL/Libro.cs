using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro= new ML.Libro();

            Console.WriteLine("Inserte El Nombre Del Libro");
            libro.Nombre = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Inserte El Id del autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte El Numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte La fecha de publicacion");
            libro.FechaPublicacion = Console.ReadLine();

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Inserte El id de la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte la edicion del libro");
            libro.Edicion = Console.ReadLine();

            libro.Genero= new ML.Genero();  
            Console.WriteLine("Inserte el id genero del libro");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Libro.Add(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("El registro fue correcto");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El registro no se inserto" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            //instancia de un objeto
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Inserte El Id Del Usuario");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Libro.Delete(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("El Usuario se Elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Usuario no se Elimino " + result.ErrorMessage);
                Console.ReadKey();
            }
        }
    }
}
