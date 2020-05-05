using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_01
{
    class admin
    {
        static StreamReader Leer;
        static StreamReader lector;
        static Menus M = new Menus();
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
            Console.WriteLine("Precione cualquier tecla para volver al menu");
            Console.ReadKey();
            Console.Clear();
            M.Menu_Admin();
        }
        public void Usuarios()
        {
            string linea;
            using (Leer = new StreamReader("Users.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("Usuario: " + datos[0] + " " + "Contraseña: " + datos[1] + " " + "Rango: " + datos[2]);
                }
                Leer.Close();
                Console.ReadKey();
            }
            Console.WriteLine("Precione cualquier tecla para volver al menu");
            Console.ReadKey();
            Console.Clear();
            M.Menu_Admin();
        }
        public void Mostrar_Facturas()
        {
            string correlatico = "";
            int encontrada = 1;
            Console.WriteLine("Correlativos de Facturas existentes: ");
            string linea = "", line = "", line2 = "";
            using (Leer = new StreamReader("Correlativos_Facturas.txt"))
            {
                while ((linea = Leer.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
            Leer.Close();
            Console.Write("Ingrese el corelativo de la cactura que desa ver: ");
            correlatico = Console.ReadLine();
            Leer = File.OpenText("Correlativos_Facturas.txt");
            while((line = Leer.ReadLine())!=null)
            {
                if(line == correlatico)
                {
                    encontrada++;
                    Console.WriteLine("Factura encontrada");
                    lector = File.OpenText("Factura" + correlatico + ".txt");
                    while ((line2 = lector.ReadLine()) != null)
                    {
                        Console.WriteLine(line2);
                    }
                }
                
            }
            if(encontrada == 1)
            {
                    Console.WriteLine("Factura Inexistente");
            }

            Leer.Close();
            Console.WriteLine("Precione cualquier tecla para volver al menu");
            Console.ReadKey();
            Console.Clear();
            M.Menu_Admin();
        }
     
    }
}
