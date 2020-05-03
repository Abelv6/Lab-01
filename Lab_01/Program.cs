using System;
using System.IO;

namespace Lab_01
{
    class Program
    {
        static Metodos_Archivos metA = new Metodos_Archivos();
        static user U = new user();
        static void Main(string[] args)
        {
            //metA.registro();
            //metA.inicio_de_secion();
            U.Cargar_Inventario();
        }
        
    }
}
