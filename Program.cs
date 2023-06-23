using System;
using listas_cSharp.Clases;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string? op;
        Persona alumno;
        bool isOkData = false;
        bool isEmailOk = false;
        bool state = true;
        Console.WriteLine("hola");
        List<Persona> personas = new List<Persona>();

        while (state == true)
        {
            Console.Clear();
            Console.WriteLine("Escriba el numero que corresponda a la accion que desea realizar");
            Console.WriteLine("1 Agregar un alumno");
            Console.WriteLine("2 Buscar un aluno");
            Console.WriteLine("3 Mostrar alumnos");
            Console.WriteLine("4 Salir");
            op = Console.ReadLine();


            switch (op)
            {
                case "1":
                    do
                    {
                        alumno = new Persona();
                        isOkData = false;
                        while (isOkData == false)
                        {
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Ingrese El nombre del Alumno");
                                alumno.Name = Console.ReadLine() ?? String.Empty;
                                if (alumno.Name == String.Empty)
                                {
                                    continue;
                                }
                                Console.WriteLine("Ingrese la edad del Alumno");
                                alumno.Age = Convert.ToInt32(Console.ReadLine());
                                do
                                {
                                    Console.WriteLine("Ingrese El Email del Alumno");
                                    alumno.Email = Console.ReadLine() ?? String.Empty;
                                    isEmailOk = alumno.IsValidEmail(alumno.Email);
                                } while (isEmailOk == false);
                                personas.Add(alumno);
                                isOkData = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error a l ingresar los datos");
                            }
                        }
                        Console.WriteLine("Desea ingresar otro alumno Enter(Si) o pulse tecla Esc(Escape) para terminar");
                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                                      
                    break;

                case "2":
                    Persona buscarPersona;
                    Console.WriteLine("Ingrese el nombre del alumno a buscar");
                    string nombreEstudiante = Console.ReadLine();
                    buscarPersona = personas.Find(persona => persona.Name.Equals(nombreEstudiante));

                    
                    if (buscarPersona != null)
                    {
                        Console.WriteLine("{0,-15} {1,20} {2,25} {3,30}", buscarPersona.IdPerson, buscarPersona.Name, buscarPersona.Age, buscarPersona.Email);
                    }
                    else
                    {
                        Console.WriteLine("Alumno no encontrado");
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("{0,-15} {1,20} {2,30} {3,40}", "Codigo", "Nombre del alumno", "Edad", "Correo electronico");
                    foreach (Persona person in personas)
                    {
                        try
                        {
                            Console.WriteLine("{0,-15} {1,20} {2,25} {3,30}", person.IdPerson, person.Name, person.Age, person.Email);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error verifique con chat-GPT");
                        }
                    }
                    Console.ReadLine();
                    break;

                case "4":
                    state = false;
                    break;

            }

        }

    }
}