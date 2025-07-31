using System;
using ConsoleApp1.Modelos;

namespace ConsoleApp1
{
    class Program
    {
        static GestionTorneos gestorTorneos = new GestionTorneos();

        static void Main(string[] args)
        {
            while (true)
            {
                MostrarMenuPrincipal();
                string? opcionTexto = Console.ReadLine(); // <-- CAMBIADO: Añadido ? para indicar que puede ser nulo
                Console.WriteLine();

                // Añadir una pequeña comprobación si opcionTexto es null, aunque poco probable aquí
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
                Console.ReadKey();
                Console.Clear();
            }
        }

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

        static bool EjecutarOpcionMenuPrincipal(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    MostrarSubmenuTorneos();
                    break;
                case 1:
                    Console.WriteLine("Has seleccionado: Registro Equipos. (Funcionalidad pendiente)");
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

        static void MostrarSubmenuTorneos()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("══════════════════════════════════");
                    Console.WriteLine("          MENÚ TORNEOS            ");
                    Console.WriteLine("══════════════════════════════════");
                    Console.WriteLine("0.1. Agregar Torneo");
                    Console.WriteLine("0.2. Buscar/Mostrar Torneos");
                    Console.WriteLine("0.3. Eliminar Torneo");
                    Console.WriteLine("0.4. Actualizar Torneo");
                    Console.WriteLine("0.5. Regresar al Menú Principal");
                    Console.WriteLine("══════════════════════════════════");
                    Console.Write("Selecciona una opción: ");

                    string? opcionTexto = Console.ReadLine();
                    Console.WriteLine();

                    if (opcionTexto == null)
                    {
                        Console.WriteLine("Error de entrada. Regresando al menú principal.");
                        break;
                    }

                    if (double.TryParse(opcionTexto, out double opcionSubmenu))
                    {
                        if (opcionSubmenu == 0.1)
                        {
                            gestorTorneos.AgregarTorneo();
                        }
                        else if (opcionSubmenu == 0.2)
                        {
                            Console.Write("¿Quieres buscar un torneo específico por ID (S/N)? ");
                            string? respuesta = Console.ReadLine();
                            
                            // *** CORRECCIÓN AQUÍ ***
                            if (respuesta == null) // Primero verificamos si es null
                            {
                                Console.WriteLine("Error de entrada.");
                                continue; // Salta al siguiente ciclo del bucle del submenú
                            }
                            
                            // Ahora que sabemos que respuesta no es null, podemos usar ToUpper()
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
                        }
                        else if (opcionSubmenu == 0.3)
                        {
                            gestorTorneos.EliminarTorneo();
                        }
                        else if (opcionSubmenu == 0.4)
                        {
                            gestorTorneos.ActualizarTorneo();
                        }
                        else if (opcionSubmenu == 0.5)
                        {
                            Console.WriteLine("Regresando al Menú Principal...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción de submenú no reconocida. Por favor, intenta de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Por favor, introduce un número válido (ej. 0.1, 0.5).");
                    }

                    Console.WriteLine("\nPresiona cualquier tecla para continuar en el Menú Torneos...");
                    Console.ReadKey();
                }
            }
        }
    }
    
    