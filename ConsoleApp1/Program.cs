using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bucle principal del menú
            while (true)
            {
                MostrarMenuPrincipal(); // Llama al método que muestra las opciones
                string? opcionTexto = Console.ReadLine(); // Lee la entrada del usuario
                Console.WriteLine(); // Salto de línea para mejor formato

                if (opcionTexto != null && int.TryParse(opcionTexto, out int opcionSeleccionada))
                {
                    // Llama al método que maneja la opción seleccionada
                    bool salir = EjecutarOpcionMenuPrincipal(opcionSeleccionada);
                    if (salir)
                    {
                        Console.WriteLine("¡Gracias por usar el sistema! Saliendo...");
                        break; // Sale del bucle while (cierra la aplicación)
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, introduce un número.");
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey(); // Espera una tecla antes de mostrar el menú de nuevo
                Console.Clear(); // Limpia la consola para el siguiente menú
            }
        }

        // Método para mostrar las opciones del menú principal
        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          MENÚ PRINCIPAL          ");
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("0. Crear Torneo");
            Console.WriteLine("1. Registro Equipos");
            Console.WriteLine("2. Registro Jugadores");
            Console.WriteLine("3. Transferencias (Compra, Préstamo)");
            Console.WriteLine("4. Estadísticas");
            Console.WriteLine("5. Salir");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Selecciona una opción: ");
        }

        // Método para ejecutar la opción seleccionada del menú principal
        static bool EjecutarOpcionMenuPrincipal(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Has seleccionado: Crear Torneo.");
                    // Aquí llamaremos al submenú de torneos
                    // MenuTorneos.Mostrar(); // Esto lo haremos más adelante
                    break;
                case 1:
                    Console.WriteLine("Has seleccionado: Registro Equipos.");
                    // Aquí llamaremos a la funcionalidad de registro de equipos
                    break;
                case 2:
                    Console.WriteLine("Has seleccionado: Registro Jugadores.");
                    // Aquí llamaremos a la funcionalidad de registro de jugadores
                    break;
                case 3:
                    Console.WriteLine("Has seleccionado: Transferencias (Compra, Préstamo).");
                    // Aquí llamaremos a la funcionalidad de transferencias
                    break;
                case 4:
                    Console.WriteLine("Has seleccionado: Estadísticas.");
                    // Aquí llamaremos a la funcionalidad de estadísticas
                    break;
                case 5:
                    return true; // Indica que se debe salir de la aplicación
                default:
                    Console.WriteLine("Opción no reconocida. Por favor, intenta de nuevo.");
                    break;
            }
            return false; // Indica que NO se debe salir de la aplicación
        }
    }
}