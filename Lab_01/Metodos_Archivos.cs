﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_01
{
    class Metodos_Archivos
    {
        public void registro()
        {
            string temp, confirm1, confirm2, confirmRan;
            int x = 1, y = 2;
            StreamWriter escritor = File.AppendText("Users.txt");
            Console.Write("►Por favor ungrese el nombre del nuevo usuario◄: ");
            temp = Console.ReadLine();
            Console.Write("►Ahora ingrese su contraseña◄: ");
            confirm1 = Console.ReadLine();
            Console.Write("►Confirme la contraseña◄: ");
            confirm2 = Console.ReadLine();
            while (x == 1)
                if (confirm1 == confirm2)
                {
                    x++;
                    temp += ("*" + confirm1);
                    Console.Write("►Ahora seleccione su rango [admin/user]◄");
                    confirmRan = Console.ReadLine();
                    while (y == 2)
                    {
                        if (confirmRan == "admin" || confirmRan == "user")
                        {
                            y++;
                            temp += ("*" + confirmRan);
                            escritor.WriteLine(temp);
                            Console.Write("►Usuario creado precione cualquier tecla para continuar.◄");
                            escritor.Close();

                            Console.ReadKey();
                            Console.Clear();
                            //LLamar a menu
                        }
                        else
                        {
                            Console.Write("►Rango no valido◄");
                            Console.Write("►Inserte nuevamente el rango del usuario◄");
                            Console.Write("►[admin/user]◄");
                            confirmRan = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.Write("►Confirmacion de contraseña invalida◄");
                    Console.Write("►Escriba la contraseña◄");
                    confirm1 = Console.ReadLine();
                    Console.Write("►Confirme la contraseña◄");
                    confirm2 = Console.ReadLine();
                }
        }

        public void inicio_de_secion()
        {

        }
    }
}
