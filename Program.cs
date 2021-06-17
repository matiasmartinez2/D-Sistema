using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp4_1
{
    public class Persona
    {
        private int dni;
        private string dni1;
        private string nombreApellido;
        private string domicilio;
        private long telefono;
        private string telefono1;
        private string email;
        public string actividad;
        private string linea;
        public int[] documentos = new int[100];
        public string[,] Persons;
        public int filas = 0;

        public void Matriz()
        {
            Persons = new string[100, 6];
        }

        public void CargaPersona()
        {
            Console.WriteLine("DNI: ");
            linea = Console.ReadLine();
            dni1 = linea;
            dni = int.Parse(linea);
            Console.WriteLine("NOMBRE Y APELLIDO: ");
            nombreApellido = Console.ReadLine();
            Console.WriteLine("DOMICILIO: ");
            domicilio = Console.ReadLine();
            Console.WriteLine("TELEFONO: ");
            linea = Console.ReadLine();
            telefono1 = linea;
            telefono = long.Parse(linea);
            Console.WriteLine("EMAIL: ");
            email = Console.ReadLine();
            Console.WriteLine("ACTIVIDAD: ");
            actividad = Console.ReadLine();

            for (int i = filas; i < (filas + 1); i++)
            {
                for (int f = 0; f < 6; f++)
                {
                    switch (f)
                    {
                        case 0:
                            Persons[i, f] = dni1;
                            documentos[i] = dni;
                            break;
                        case 1:
                            Persons[i, f] = nombreApellido;
                            break;
                        case 2:
                            Persons[i, f] = domicilio;
                            break;
                        case 3:
                            Persons[i, f] = telefono1;
                            break;
                        case 4:
                            Persons[i, f] = email;
                            break;
                        case 5:
                            Persons[i, f] = actividad;
                            break;
                        default:
                            break;
                    }
                }
            }
            filas++;
        }

        public int verificarExistencia(int docu)
        {
            int bandera = 0;
            for (int i = 0; i < documentos.Length; i++)
            {
                if (docu == documentos[i])
                {
                    bandera = 1;
                }
            }
            return bandera;
        }
    }


    internal class Actividad
    {
        private string area;
        public string actividadAutorizada;
        public int Bandera = 0;
        public string actividadComparar;
        string[] autoActi = new string[7];
        public int ban1;
        public int ban2;
        public string texto;
        public int documento;
        public string Activity;

        public Actividad()
        {
            autoActi[0] = "seguridad";
            autoActi[1] = "bombero";
            autoActi[2] = "limpieza";
            autoActi[3] = "policia";
            autoActi[4] = "docente";
            autoActi[5] = "gastronomico";
            autoActi[6] = "estudiante";
        }

        public int verificarActividad(string acti)
        {
            int bandera = 0;


            for (int i = 0; i < autoActi.Length; i++)
            {
                if (acti == autoActi[i])
                {
                    bandera = 1;
                }
            }
            return bandera;
        }

        public void autorizarIngreso()
        {
            Console.WriteLine("INGRESE DNI DE LA PERSONA: ");
            texto = Console.ReadLine();
            documento = int.Parse(texto);
            Persona persona = new Persona();
            ban1 = persona.verificarExistencia(documento);
            if (ban1 == 1)
            {
                Console.WriteLine("PERSONA AUTORIZADA A INGRESAR.");
            }
            else
            {
                Console.WriteLine("INGRESE LA ACTIVIDAD DE LA PERSONA: ");
                Activity = Console.ReadLine();
                ban2 = verificarActividad(Activity);
                if (ban2 == 1)
                {
                    Console.WriteLine("---INGRESE LOS DATOS DE LA PERSONA PARA CARGARLA AL SISTEMA---");
                    persona.CargaPersona();
                    Console.WriteLine("PERSONA AUTORIZADA A INGRESAR.");
                }
                else
                {
                    Console.WriteLine("PERSONA NO AUTORIZADA A INGRESAR.");
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Actividad actividad = new Actividad();
            Console.WriteLine("---INGRESE LOS DATOS DE LA PERSONA A VERIFICAR---");
            actividad.autorizarIngreso();
            Console.ReadKey();
        }
    }
}