using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_01
{
    class user
    {
        static StreamReader Leer;
        static StreamWriter escribir;
        /*
         * Cargar Inverio
         *  facturar productos
         */
        public void Facturas()
        {

        }
        public void Cargar_Inventario()
        {
            Console.WriteLine("Inventario:\t");
            string linea = "", Producto = "", Cantidad = "";
            /*Lista de contactos */
            using (Leer = new StreamReader("Inventario.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    Console.WriteLine("\t\t" + linea);
                }
            }

            Console.Write("\nIngrese nombre del Producto a agregar: ");
            Producto = Console.ReadLine();
            Console.Write("Cantidad: ");
            Cantidad = Console.ReadLine();
            using (escribir = new StreamWriter("InventarioTemp.txt"))
            {
                using (Leer = new StreamReader("Inventario.txt"))
                {
                    while ((linea = Leer.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('*');
                        if (datos[0] != Producto)
                        {
                            escribir.WriteLine(linea);
                        }
                    }
                }
            }
            File.Delete("Inventario.txt");
            File.Move("InventarioTemp.txt", "Inventario");
            Console.ReadKey();
        }
    }
}
