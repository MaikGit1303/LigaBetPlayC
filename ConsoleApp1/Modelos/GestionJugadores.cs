// GestionJugadores.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Modelos
{
    public class GestionJugadores
    {
        private List<Jugador> listaJugadores;
        private int siguienteIdJugador = 1;
        private GestionEquipos gestorEquipos;

        public GestionJugadores(GestionEquipos gestorEquipos)
        {
            listaJugadores = new List<Jugador>();
            this.gestorEquipos = gestorEquipos;
        }

        // 2.1. Registrar Jugador
        public void RegistrarJugador()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          REGISTRAR JUGADOR       ");
            Console.WriteLine("══════════════════════════════════");

            Console.Write("Nombre completo del Jugador: ");
            string? nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("El nombre no puede estar vacío. Introduce el nombre del Jugador: ");
                nombre = Console.ReadLine();
            }

            int edad;
            Console.Write("Edad: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 0)
            {
                Console.Write("Edad inválida. Introduce un número entero positivo: ");
            }

            Console.Write("Posición (Ej: Delantero, Defensa, Portero): ");
            string? posicion = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(posicion))
            {
                Console.Write("La posición no puede estar vacía. Introduce la posición: ");
                posicion = Console.ReadLine();
            }

            int idEquipo;
            // Validar que el ID de equipo exista
            while (true)
            {
                Console.Write("ID del Equipo al que pertenece (0 si no tiene equipo): ");
                if (int.TryParse(Console.ReadLine(), out idEquipo))
                {
                    if (idEquipo == 0) // Permitir 0 si el jugador no tiene equipo asignado aún
                    {
                        break;
                    }
                    else if (gestorEquipos.BuscarEquipoPorId(idEquipo) != null)
                    {
                        break; // El equipo existe, el ID es válido
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún equipo con el ID: {idEquipo}. Por favor, introduce un ID de equipo existente o 0.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de equipo inválido. Introduce un número.");
                }
            }

            Jugador nuevoJugador = new Jugador(siguienteIdJugador++, nombre!, edad, posicion!, idEquipo);
            listaJugadores.Add(nuevoJugador);

            Console.WriteLine("\n¡Jugador registrado exitosamente!");
            nuevoJugador.MostrarInfo();
        }

        // Método interno para buscar jugador por ID
        public Jugador? BuscarJugadorPorId(int id)
        {
            return listaJugadores.FirstOrDefault(j => j.Id == id);
        }

        // 2.2. Mostrar/Buscar Jugadores
        public void MostrarJugadores()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          LISTA DE JUGADORES      ");
            Console.WriteLine("══════════════════════════════════");

            if (listaJugadores.Any())
            {
                foreach (var jugador in listaJugadores)
                {
                    jugador.MostrarInfo();
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay jugadores registrados.");
            }
        }

        // 2.3. Editar Jugador (Actualizar)
        public void EditarJugador()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          EDITAR JUGADOR          ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del jugador a editar: ");
            if (int.TryParse(Console.ReadLine(), out int idEditar))
            {
                Jugador? jugadorAEditar = BuscarJugadorPorId(idEditar);
                if (jugadorAEditar != null)
                {
                    Console.WriteLine($"\nActualmente: Nombre: {jugadorAEditar.NombreCompleto}, Edad: {jugadorAEditar.Edad}, Posición: {jugadorAEditar.Posicion}, Equipo ID: {jugadorAEditar.IdEquipo}");
                    Console.WriteLine("Deja en blanco para no cambiar el valor.");

                    Console.Write($"Nuevo Nombre ({jugadorAEditar.NombreCompleto}): ");
                    string? nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    {
                        jugadorAEditar.NombreCompleto = nuevoNombre;
                    }

                    Console.Write($"Nueva Edad ({jugadorAEditar.Edad}): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaEdad) && nuevaEdad > 0)
                    {
                        jugadorAEditar.Edad = nuevaEdad;
                    }
                    else if (!string.IsNullOrWhiteSpace(Console.ReadLine())) // Si no fue un número válido, pero algo se escribió
                    {
                        Console.WriteLine("Edad no válida, se mantiene la actual.");
                    }

                    Console.Write($"Nueva Posición ({jugadorAEditar.Posicion}): ");
                    string? nuevaPosicion = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevaPosicion))
                    {
                        jugadorAEditar.Posicion = nuevaPosicion;
                    }

                    Console.Write($"Nuevo ID de Equipo ({jugadorAEditar.IdEquipo}) (0 para sin equipo): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevoIdEquipo))
                    {
                        if (nuevoIdEquipo == 0 || gestorEquipos.BuscarEquipoPorId(nuevoIdEquipo) != null)
                        {
                            jugadorAEditar.IdEquipo = nuevoIdEquipo;
                        }
                        else
                        {
                            Console.WriteLine("ID de equipo no válido o no existente, se mantiene el actual.");
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(Console.ReadLine())) // Si no fue un número válido, pero algo se escribió
                    {
                        Console.WriteLine("Entrada de ID de equipo no válida, se mantiene la actual.");
                    }

                    Console.WriteLine("\n¡Jugador actualizado exitosamente!");
                    jugadorAEditar.MostrarInfo();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún jugador con el ID: {idEditar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }

        // 2.4. Eliminar Jugador
        public void EliminarJugador()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          ELIMINAR JUGADOR        ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del jugador a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                Jugador? jugadorAEliminar = BuscarJugadorPorId(idEliminar);
                if (jugadorAEliminar != null)
                {
                    listaJugadores.Remove(jugadorAEliminar);
                    Console.WriteLine($"Jugador '{jugadorAEliminar.NombreCompleto}' (ID: {idEliminar}) eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún jugador con el ID: {idEliminar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }
    }
}