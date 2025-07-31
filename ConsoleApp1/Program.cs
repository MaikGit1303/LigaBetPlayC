// Program.cs
using System;
using ConsoleApp1.Modelos;

namespace ConsoleApp1
{
    class Program
    {
        // Instancias de los gestores para manejar la lógica de las entidades
        static GestionTorneos gestorTorneos = new GestionTorneos();
        static GestionEquipos gestorEquipos = new GestionEquipos();

        static void Main(string[] args)
        {
            // Bucle principal del menú
            while (true)
            {
                MostrarMenuPrincipal(); 
                string? opcionTexto = Console.ReadLine(); 
                Console.WriteLine(); 

                // Manejo de posible valor nulo de Console.ReadLine()
                if (opcionTexto == null)
                {
                    Console.WriteLine("Error de entrada. Terminando aplicación.");
                    break;
                }

                if (int.TryParse(opcionTexto, out int opcionSeleccionada))
                {
                    bool salir = EjecutarOpcionMenuPrincipal(opcionSeleccionada);
                    if (salir)
                    {
                        Console.WriteLine("¡Gracias por usar el sistema! Saliendo...");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, introduce un número.");
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey(); // Espera una tecla antes de mostrar el menú de nuevo
                Console.Clear();
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
                    MostrarSubmenuTorneos();
                    break;
                case 1:
                    MostrarSubmenuEquipos();
                    break;
                case 2:
                    Console.WriteLine("Has seleccionado: Registro Jugadores. (Funcionalidad pendiente)");
                    break;
                case 3:
                    Console.WriteLine("Has seleccionado: Transferencias (Compra, Préstamo). (Funcionalidad pendiente)");
                    break;
                case 4:
                    Console.WriteLine("Has seleccionado: Estadísticas. (Funcionalidad pendiente)");
                    break;
                case 5:
                    return true; 
                default:
                    Console.WriteLine("Opción no reconocida. Por favor, intenta de nuevo.");
                    break;
            }
            return false;
        }

        // Método para mostrar y manejar el submenú de Torneos
        static void MostrarSubmenuTorneos()
        {
            while (true)
            {
                Console.Clear(); 
                Console.WriteLine("══════════════════════════════════");
                Console.WriteLine("          MENÚ TORNEOS            ");
                Console.WriteLine("══════════════════════════════════");
                Console.WriteLine("1. Agregar Torneo");
                Console.WriteLine("2. Buscar/Mostrar Torneos");
                Console.WriteLine("3. Eliminar Torneo");
                Console.WriteLine("4. Actualizar Torneo");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.WriteLine("══════════════════════════════════");
                Console.Write("Selecciona una opción: ");

                string? opcionTexto = Console.ReadLine();
                Console.WriteLine(); 

                if (opcionTexto == null)
                {
                    Console.WriteLine("Error de entrada. Regresando al menú principal.");
                    break; 
                }

                if (int.TryParse(opcionTexto, out int opcionSubmenu))
                {
                    switch (opcionSubmenu)
                    {
                        case 1: 
                            gestorTorneos.AgregarTorneo();
                            break;
                        case 2: 
                            Console.Write("¿Quieres buscar un torneo específico por ID (S/N)? ");
                            string? respuesta = Console.ReadLine();

                            if (respuesta == null)
                            {
                                Console.WriteLine("Error de entrada.");
                                continue;
                            }

                            if (respuesta.ToUpper() == "S")
                            {
                                Console.Write("Introduce el ID del torneo a buscar: ");
                                if (int.TryParse(Console.ReadLine(), out int idBuscar))
                                {
                                    Torneo? encontrado = gestorTorneos.BuscarTorneoPorId(idBuscar);
                                    if (encontrado != null)
                                    {
                                        Console.WriteLine("\nTorneo Encontrado:");
                                        encontrado.MostrarInfo();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No se encontró ningún torneo con el ID: {idBuscar}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido.");
                                }
                            }
                            else
                            {
                                gestorTorneos.MostrarTorneos();
                            }
                            break;
                        case 3:
                            gestorTorneos.EliminarTorneo();
                            break;
                        case 4: 
                            gestorTorneos.ActualizarTorneo();
                            break;
                        case 5: 
                            Console.WriteLine("Regresando al Menú Principal...");
                            return;
                        default:
                            Console.WriteLine("Opción de submenú no reconocida. Por favor, intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, introduce un número válido (ej. 1, 5)."); // <-- Mensaje actualizado
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar en el Menú Torneos...");
                Console.ReadKey(); // Espera la entrada del usuario antes de volver a mostrar el submenú
            }
        }

        // Método para mostrar y manejar el submenú de Equipos
        static void MostrarSubmenuEquipos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("══════════════════════════════════");
                Console.WriteLine("          MENÚ EQUIPOS            ");
                Console.WriteLine("══════════════════════════════════");
                Console.WriteLine("1. Registrar Equipo");
                Console.WriteLine("2. Buscar/Mostrar Equipos");
                Console.WriteLine("3. Eliminar Equipo");
                Console.WriteLine("4. Actualizar Equipo");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.WriteLine("══════════════════════════════════");
                Console.Write("Selecciona una opción: ");

                string? opcionTexto = Console.ReadLine();
                Console.WriteLine();

                if (opcionTexto == null)
                {
                    Console.WriteLine("Error de entrada. Regresando al menú principal.");
                    break; 
                }

                if (int.TryParse(opcionTexto, out int opcionSubmenu)) 
                {
                    switch (opcionSubmenu)
                    {
                        case 1: 
                            gestorEquipos.RegistrarEquipo();
                            break;
                        case 2: 
                            Console.Write("¿Quieres buscar un equipo específico por ID (S/N)? ");
                            string? respuesta = Console.ReadLine();

                            if (respuesta == null)
                            {
                                Console.WriteLine("Error de entrada.");
                                continue;
                            }

                            if (respuesta.ToUpper() == "S")
                            {
                                Console.Write("Introduce el ID del equipo a buscar: ");
                                if (int.TryParse(Console.ReadLine(), out int idBuscar))
                                {
                                    Equipo? encontrado = gestorEquipos.BuscarEquipoPorId(idBuscar);
                                    if (encontrado != null)
                                    {
                                        Console.WriteLine("\nEquipo Encontrado:");
                                        encontrado.MostrarInfo();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No se encontró ningún equipo con el ID: {idBuscar}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido.");
                                }
                            }
                            else
                            {
                                gestorEquipos.MostrarEquipos();
                            }
                            break;
                        case 3: 
                            gestorEquipos.EliminarEquipo();
                            break;
                        case 4: 
                            gestorEquipos.ActualizarEquipo();
                            break;
                        case 5:
                            Console.WriteLine("Regresando al Menú Principal...");
                            return; 
                        default:
                            Console.WriteLine("Opción de submenú no reconocida. Por favor, intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, introduce un número válido (ej. 1, 5)."); // <-- Mensaje actualizado
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar en el Menú Equipos...");
                Console.ReadKey();
            }
        }
    }
}