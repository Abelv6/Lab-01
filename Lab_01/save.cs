using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_01
{
    /*class save
    {
        public void inicio_de_secion()
        {
            string line = "usuario", Ubusq, contrabusq, salir = "no";
            int Z = 1;
            Console.WriteLine("Ingrese su Usuario");
            Ubusq = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña");
            contrabusq = Console.ReadLine();
            //lector = File.OpenText("Users.txt");
            using (lector = new StreamReader("Users.txt"))
            {
                while ((line = lector.ReadLine()) != null)
                {
                    //line = lector.ReadLine();
                    string[] vec = line.Split('*');
                    if (Ubusq == vec[0])
                    {
                        do
                        {
                            if (contrabusq == vec[1])
                            {
                                //lector.Close();
                                Z++;
                                if (vec[2] == "admin")
                                {
                                    Console.WriteLine("Usted es Administrador");
                                    //menu para admin
                                }
                                else
                                {
                                    Console.WriteLine("Usted es Trabajador");
                                    //menu para user
                                }
                            }
                            else
                            {
                                do
                                {
                                    Console.WriteLine("Contraseña Incorrca");
                                    Console.WriteLine("Desea cambiar de usuario[Si/No]");
                                    salir = Console.ReadLine();
                                    if (salir == "No" || salir == "no")
                                    {
                                        Console.WriteLine("Ingrese de nuevo la contraseña");
                                        contrabusq = Console.ReadLine();
                                    }
                                    else
                                    {
                                        inicio_de_secion();
                                    }
                                } while (salir == "no" || salir == "No");
                            }
                        }
                        while (Z == 1);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no existente intente de nuevo");
                        inicio_de_secion();
                    }
                }
            }
        }
    }*/

    /*else if(datos[0]!= busqueda)
                    {
                        Console.WriteLine("Usuario Invalido Precione cualquier tecla para continuar");
                        Console.ReadKey();
                        inicio_de_secion();
                    }*/
}
