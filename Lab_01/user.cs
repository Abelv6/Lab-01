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
            string CantTemp="", Correlativo = "",NombreProd = "", Nombre = "", NIT = "", Fecha = "", Detalle = "", MontoTt = "", Seguir = "Si", Precio="";
            double Tt = 0;
            int CasillasNo = 0, x = 0, w = 0, cant = 0;
            Console.WriteLine("Inventario actual: ");
            string linea = "",line="";
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
            Console.Write("Ingrese el nombre del Cliente: ");
            Nombre = Console.ReadLine();
            Console.Write("Ingrese el NIT del Cliente: ");
            NIT = Console.ReadLine();
            Console.Write("Ingrese la Fecha: ");
            Fecha = Console.ReadLine();
            
            do
            {
                Console.Write("Nombre del Producto: ");
                NombreProd = Console.ReadLine();
                Detalle += ("Producto: " + NombreProd + "*");//<==
                Console.Write("Cantidad del Producto: ");
                cant = int.Parse(Console.ReadLine());
                Detalle += ("Cantidad del Producto: " + cant + "*");//<==
                Console.Write("Precio del Ptodicto: ");
                Precio = Console.ReadLine();
                Detalle += ("Precio del Producto" + Precio + "*");//<==
                Tt += cant * double.Parse(Precio);

                using (escribir = new StreamWriter("InventarioTemp.txt"))
                {
                    using (Leer = new StreamReader("Inventario.txt"))
                    {
                        while ((line = Leer.ReadLine()) != null)
                        {
                            string[] datos = line.Split('*');
                            if (datos[0] != NombreProd)
                            {
                                escribir.WriteLine(line);
                            }
                            else if (datos[0]==NombreProd)
                            {
                                CantTemp = datos[1];

                                cant = int.Parse(CantTemp)-cant;
                                Console.WriteLine(w);
                                w++;

                            }
                         
                        }
                        Console.WriteLine(w);
                        
                    }
                }
                File.Delete("Inventario.txt");
                File.Move("InventarioTemp.txt", "Inventario.txt");
                Leer.Close();
                escribir.Close();
                escribir = File.AppendText("Inventario.txt");
                escribir.WriteLine(NombreProd + "*" + cant + "*" + Precio);
                escribir.Close();
                Console.WriteLine("Desea agregar otro Producto: ");
                Seguir = Console.ReadLine();
            } while (Seguir == "Si"||Seguir == "si");
            MontoTt = ("El total a pagar es: " + Tt);

            string line2 = "";
            Leer = File.OpenText("Correlativos_Facturas.txt");
            while (line2 != null)
            {
                line2 = Leer.ReadLine();
                if (Correlativo == line2)
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
