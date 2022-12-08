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
            Console.WriteLine("");
        }
    }
}
