using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_01
{
    class Menus
    {
        static Metodos_Archivos metA = new Metodos_Archivos();
        static user U = new user();
        static admin ad = new admin();

        public void Menu_Users()
        {
            string op = "", confirmar = "";
            Console.WriteLine("Bienvenido Travajadpr de Los Patos");
            Console.WriteLine("Ingrese el numero de la accion que desea realizar:");
            Console.WriteLine("1.- Cargar Inventario");
            Console.WriteLine("2.- Realizar una Factura");
            Console.WriteLine("3.- Cerrar secion");
            Console.Write("Opcion: ");
            op = Console.ReadLine();
            if(op == "1")
            {
                U.Cargar_Inventario();
            }
            else if (op == "2")
            {
                U.Facturas();
            }
            else if(op =="3")
            {
                Console.WriteLine("Seguro que desea cerrar secion[Si/No]");
                confirmar = Console.ReadLine();
                if(confirmar == "Si"||confirmar =="si")
                {
                    Console.Clear();
                    metA.inicio_de_secion();
                }
                else
                {
                    Console.Clear();
                    Menu_Users();
                }
            }
            else
            {
                Console.WriteLine("Esta opcion no existe, Precione cualquie tecla para volver");
                Console.Clear();
                Menu_Users();
            }
        }
        public void Menu_Admin()
        {
            string op = "", confirmar = "";
            Console.WriteLine("Bienvenido Administrador de Los Patos");
            Console.WriteLine("Ingrese el numero de la accion que desea realizar:");
            Console.WriteLine("1.- Mostrar el Inventario");
            Console.WriteLine("2.- Mostrar los Usuarios");
            Console.WriteLine("3.- Mostrar las facturas");
            Console.WriteLine("4.- Crear un nuevo Usuario");
            Console.WriteLine("5.- Cerrar secion");
            Console.Write("Opcion: ");
            op = Console.ReadLine();
            if(op == "1")
            {
                ad.inventareado();
            }
            else if(op == "2")
            {
                ad.Usuarios();
            }
            else if(op == "3")
            {
                ad.Mostrar_Facturas();
            }
            else if(op == "4")
            {
                metA.registro();
            }
            else if (op == "5")
            {
                Console.WriteLine("Seguro que desea cerrar secion[Si/No]");
                confirmar = Console.ReadLine();
                if (confirmar == "Si" || confirmar == "si")
                {
                    Console.Clear();
                    metA.inicio_de_secion();
                }
                else
                {
                    Console.Clear();
                    Menu_Users();
                }
            }
            else
            {
                Console.WriteLine("Esta opcion no existe, Precione cualquie tecla para volver");
                Console.Clear();
                Menu_Users();
            }
        }
    }
}
