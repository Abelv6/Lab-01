using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Net.Http;

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
            string Correlativo = "", Nombre = "", NIT = "", Fecha = "", Detalle = "", MontoTt = "", Seguir = "Si", cant = "", Precio="";
            double Tt = 0;
            int CasillasNo = 0, x = 0;
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
            Leer.Close();
            Console.Write("Ingrese el Correlativo de la factura: ");
            Correlativo = Console.ReadLine();
            Console.Write("Ingrese el nimbre del Cliente: ");
            Nombre = Console.ReadLine();
            Console.Write("Ingrese el NIT del Cliente");
            NIT = Console.ReadLine();
            Console.Write("Ingrese la Fecha");
            Fecha = Console.ReadLine();
            do
            {
                Console.WriteLine("Nombre del Producto: ");
                Detalle += (Console.ReadLine()+"*");
                Console.WriteLine("Cantidad del Producto");
                cant = Console.ReadLine();
                Detalle += (cant + "*");
                Console.WriteLine("Precio del Ptodicto: ");
                Precio = Console.ReadLine();
                Detalle += (Precio + "*");
                Tt += double.Parse(cant)*double.Parse(Precio);
                Console.WriteLine("Desea agregar otro Producto: ");
                Seguir = Console.ReadLine();
            } while (Seguir == "Si"||Seguir == "si");
            MontoTt = ("El total a pagar es: " + Tt);

            string line = "";
            Leer = File.OpenText("Correlativos_Facturas.txt");
            while (line != null)
            {
                line = Leer.ReadLine();
                if (Correlativo == line)
                {
                    Console.WriteLine("Este correlativo de factura ya exisre");
                    Console.Write("Porfavor corriga el correlativo: ");
                    Correlativo = Console.ReadLine();
                }
            }
            Leer.Close();
            escribir = File.AppendText("Correlativos_Facturas.txt");
            escribir.WriteLine(Correlativo);
            escribir.Close();
            escribir = File.AppendText("Factura" + Correlativo + ".txt");
            escribir.WriteLine("Factura No."+Correlativo);
            escribir.WriteLine("Nombre del Cliente: "+Nombre);
            escribir.WriteLine("NIT: "+NIT);
            escribir.WriteLine("Fecha: "+Fecha);
            escribir.WriteLine("Detalles: ");
            string[] detalles = Detalle.Split('*');
            CasillasNo = detalles.Length;
            do
            { 
                escribir.WriteLine(detalles[x]);
                Console.WriteLine(detalles[x]);
                x = x + 1;
            }
            while (CasillasNo > x);
            escribir.WriteLine(MontoTt);
            escribir.Close();
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
