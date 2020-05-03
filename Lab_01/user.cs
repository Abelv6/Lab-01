using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

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
            Console.WriteLine("Inventario actual:");
            string linea = "";
            using (Leer = new StreamReader("Inventario.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("Producto: " + datos[0] + " " + "Unidades: " + datos[1] + " " + "Precio actual: Q" + datos[2]);
                }
            }
        }
        public void Cargar_Inventario()
        {
            Console.WriteLine("Inventario:\t");
            string linea = "", Producto = "", CantTemp = "";
            double Cantidad, precio;
            using (Leer = new StreamReader("Inventario.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("Producto: " + datos[0] + " " + "Unidades: " + datos[1] + " " + "Precio actual: Q" + datos[2]);
                }
            }

            Console.Write("\nIngrese nombre del Producto a agregar: ");
            Producto = Console.ReadLine();
            Console.Write("Cantidad: ");
            Cantidad = double.Parse(Console.ReadLine());
            Console.Write("Precio o Nuevo Precio (Omita la Q): ");
            precio = double.Parse(Console.ReadLine());
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
                        else
                        {
                            CantTemp = datos[1];
                            Cantidad += double.Parse(CantTemp);
                        }
                    }
                }
            }
            File.Delete("Inventario.txt");
            File.Move("InventarioTemp.txt", "Inventario.txt");
            Leer.Close();
            escribir.Close();
            escribir = File.AppendText("Inventario.txt");
            escribir.WriteLine(Producto+"*"+Cantidad+"*"+precio);
            escribir.Close();
            Console.ReadKey();
        }
    }
}
