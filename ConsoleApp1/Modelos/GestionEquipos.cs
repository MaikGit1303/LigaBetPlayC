using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Modelos
{
    public class GestionEquipos
    {
        private List<Equipo> listaEquipos;
        private int siguienteIdEquipo = 1;

        public GestionEquipos()
        {
            listaEquipos = new List<Equipo>();
        }

        // 1.1. Registrar Equipo
        public void RegistrarEquipo()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          REGISTRAR EQUIPO        ");
            Console.WriteLine("══════════════════════════════════");

            Console.Write("Nombre del Equipo: ");
            string? nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("El nombre no puede estar vacío. Introduce el nombre del Equipo: ");
                nombre = Console.ReadLine();
            }

            Console.Write("Ciudad: ");
            string? ciudad = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(ciudad))
            {
                Console.Write("La ciudad no puede estar vacía. Introduce la ciudad: ");
                ciudad = Console.ReadLine();
            }

            Console.Write("Estadio: ");
            string? estadio = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(estadio))
            {
                Console.Write("El estadio no puede estar vacío. Introduce el estadio: ");
                estadio = Console.ReadLine();
            }

            Equipo nuevoEquipo = new Equipo(siguienteIdEquipo++, nombre!, ciudad!, estadio!); // Usamos '!' ya que validamos no-null/vacío
            listaEquipos.Add(nuevoEquipo);

            Console.WriteLine("\n¡Equipo registrado exitosamente!");
            nuevoEquipo.MostrarInfo();
        }

        // Método interno para buscar equipo por ID
        public Equipo? BuscarEquipoPorId(int id)
        {
            return listaEquipos.FirstOrDefault(e => e.Id == id);
        }

        // 1.2. Mostrar/Buscar Equipo
        public void MostrarEquipos()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          LISTA DE EQUIPOS        ");
            Console.WriteLine("══════════════════════════════════");

            if (listaEquipos.Any())
            {
                foreach (var equipo in listaEquipos)
                {
                    equipo.MostrarInfo();
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay equipos registrados.");
            }
        }

        // 1.3. Eliminar Equipo
        public void EliminarEquipo()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          ELIMINAR EQUIPO         ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del equipo a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                Equipo? equipoAEliminar = BuscarEquipoPorId(idEliminar);
                if (equipoAEliminar != null)
                {
                    listaEquipos.Remove(equipoAEliminar);
                    Console.WriteLine($"Equipo '{equipoAEliminar.Nombre}' (ID: {idEliminar}) eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún equipo con el ID: {idEliminar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }

        // 1.4. Actualizar Equipo
        public void ActualizarEquipo()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          ACTUALIZAR EQUIPO       ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del equipo a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int idActualizar))
            {
                Equipo? equipoAActualizar = BuscarEquipoPorId(idActualizar);
                if (equipoAActualizar != null)
                {
                    Console.WriteLine($"\nActualmente: Nombre: {equipoAActualizar.Nombre}, Ciudad: {equipoAActualizar.Ciudad}, Estadio: {equipoAActualizar.Estadio}");
                    Console.WriteLine("Deja en blanco para no cambiar el valor.");

                    Console.Write($"Nuevo Nombre ({equipoAActualizar.Nombre}): ");
                    string? nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    {
                        equipoAActualizar.Nombre = nuevoNombre;
                    }

                    Console.Write($"Nueva Ciudad ({equipoAActualizar.Ciudad}): ");
                    string? nuevaCiudad = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevaCiudad))
                    {
                        equipoAActualizar.Ciudad = nuevaCiudad;
                    }

                    Console.Write($"Nuevo Estadio ({equipoAActualizar.Estadio}): ");
                    string? nuevoEstadio = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoEstadio))
                    {
                        equipoAActualizar.Estadio = nuevoEstadio;
                    }

                    Console.WriteLine("\n¡Equipo actualizado exitosamente!");
                    equipoAActualizar.MostrarInfo();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún equipo con el ID: {idActualizar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }
    }
}