using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_01
{
    class admin
    {
        static StreamReader Leer;
        public void inventareado()
        {
            Console.WriteLine("Inventario actual:");
            string linea = "";
            using (Leer = new StreamReader("Inventario.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("Producto: " + datos[0] + " " + "Unidades: " + datos[1] + " " + "Precio actual: Q" + datos[2]);
                }
                Leer.Close();
                Console.ReadKey();
            }
        }
        public void Usuarios()
        {
            string linea;
            using (Leer = new StreamReader("Users.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("Usuario: "+datos[0]+" "+"Contraseña: "+datos[1]+" "+"Rango: "+datos[2]);
                }
                Leer.Close();
                Console.ReadKey();
            }
        }
        /*
         * Inventario
         * Usuarios (ver y crear)
         * Facturas (ver todas las existentes
         */
    }
}
