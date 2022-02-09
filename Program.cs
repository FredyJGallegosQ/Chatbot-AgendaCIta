using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chatbot
{
    class Program
    {
        public static string LimpiarCadena(string cadena)
        {
            cadena = cadena.Replace(" ", "");
            cadena = cadena.ToLower();
            cadena = cadena.Replace("á", "a");
            cadena = cadena.Replace("é", "e");
            cadena = cadena.Replace("í", "i");
            cadena = cadena.Replace("ó", "o");
            cadena = cadena.Replace("ú", "u");
            return cadena;
        }
        public static string Diascita()
        {
            Console.WriteLine("¿Qué día desea su cita?");
            Console.WriteLine("1. Lunes");
            Console.WriteLine("2. Martes");
            Console.WriteLine("3. Miércoles");
            Console.WriteLine("4. Viernes");
            Console.WriteLine("5. Ninguno");
            string rpta = Console.ReadLine();
            rpta = LimpiarCadena(rpta);
            while (rpta != "1" && rpta != "2" && rpta != "3" && rpta != "4" && rpta != "5" &&
                rpta != "lunes" && rpta != "martes" && rpta != "miercoles" && rpta != "viernes" && rpta != "ninguno")
            {
                Console.WriteLine("Error...");
                Console.WriteLine("Ingrese número de opción o la opción");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            if (rpta == "lunes" || rpta == "1")
            {
                Console.WriteLine("Horarios disponibles");
                Console.WriteLine("a) 8:00 - 8:30 am".PadRight(20) + "b) 8:30 - 9:00 am".PadRight(20) +
                    "c) 11:00 - 11:30 am".PadRight(22) + "n) Ninguno");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            if (rpta == "martes" || rpta == "2")
            {
                Console.WriteLine("Horarios disponibles");
                Console.WriteLine("a) 10:00 - 10:30 pm".PadRight(22) + "n) Ninguno");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            if (rpta == "miercoles" || rpta == "3")
            {
                Console.WriteLine("Horarios disponibles");
                Console.WriteLine("a) 3:30 - 4:00 pm".PadRight(20) + "b) 4:30 - 5:00 pm".PadRight(20) + "n) Ninguno");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            if (rpta == "viernes" || rpta == "4")
            {
                Console.WriteLine("Horarios disponibles");
                Console.WriteLine("a) 7:00 - 7:30 am".PadRight(20) + "b) 8:00 - 8:30 am".PadRight(20) + "n) Ninguno");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            if (rpta == "ninguno" || rpta == "5" || rpta == "n")
            {
                Console.WriteLine("¿Desea escoger otro horario?");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
                if(rpta == "escogerhorario" || rpta == "si")
                {
                    rpta = Diascita();
                }
                else
                {
                    Console.WriteLine("Lamentamos que no hayas encontrado un horario adecuado");
                    Console.WriteLine("Por favor ingrese un mensaje para su tutor");
                    rpta = Console.ReadLine();
                }
            }
            return rpta;
        }
        public static string Validar()
        {
            string[] A = new string[] { "151718", "181920", "161817", "202112", "151810", "171110", "171520" };
            string[] B = new string[] {"juan", "carlos", "jorge", "luis", "marco", "jose", "unsaac"};
            string nombre = " ";
            bool validado = false;
            Console.WriteLine("Simulación de Chatbot (Agendar cita)");
            Console.WriteLine("************************************");
            Console.WriteLine("");
            while(validado == false)
            {
                Console.WriteLine("Saludos, ingrese sus datos por favor");
                Console.Write("Código: ");
                string cod = Console.ReadLine();
                Console.Write("Contraseña: ");
                string contra = Console.ReadLine();
                Console.WriteLine("Validando...");
                Thread.Sleep(3000);
                for (int i = 0; i < A.Length; i++)
                {
                    if (cod == A[i] && contra == B[i])
                    {
                        nombre = B[i];
                        validado = true;
                    }
                }
            }
            return nombre;
        }
        public static void Chat(bool A)
        {
            if(A == true)
            {
                string nombre = Validar();
                Console.WriteLine("Su código y contraseña son correctos");
                Console.WriteLine("Hola " + nombre + ", ¿Cómo puedo ayudarte?");
            }
            Console.WriteLine("1. Agendar Cita");
            Console.WriteLine("2. Cancelar Cita");
            Console.WriteLine("3. Otros");
            Console.WriteLine("4. Salir");
            string rpta = Console.ReadLine();
            rpta = LimpiarCadena(rpta);
            while (rpta != "1" && rpta != "agendarcita")
            {
                Console.WriteLine("Error...");
                Console.WriteLine("Ingrese número de opción o la opción");
                rpta = Console.ReadLine();
                rpta = LimpiarCadena(rpta);
            }
            Console.WriteLine("Recuerda que el tiempo de atención por alumno es de 30 min");
            rpta = Diascita();
            if(rpta == "a" || rpta == "b" || rpta == "c")
            {
                Console.WriteLine("Se está procesando tu cita...");
                Thread.Sleep(3000);
                Console.WriteLine("Su cita se registro exitosamente, se le enviará un correo de confirmación");
            }
            else
            {
                Console.WriteLine("Registrando mensaje...");
                Thread.Sleep(3000);
                Console.WriteLine("Su tutor se comunicará con usted.");
            }
            Console.WriteLine("Desea realizar otra consulta?");
            rpta = Console.ReadLine();
            rpta = LimpiarCadena(rpta);
            if(rpta == "si" || rpta == "s")
            {
                Chat(false);
            }
            else
            {
                Console.WriteLine("Gracias por usar nuestro chatbot");
                Console.ReadKey();
            }
            Console.ReadKey();

        }
        static void Main(string[] args)
        {
            Chat(true);
            Console.ReadKey();
        }
    }
}
