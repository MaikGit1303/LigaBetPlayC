using System;
using System.Collections.Generic; // Para usar List<Torneo>
using System.Linq; // Necesario para métodos de LINQ como .FirstOrDefault() y .Any()

namespace ConsoleApp1.Modelos // MUY IMPORTANTE: Asegúrate de que este namespace sea el correcto
{
    public class GestionTorneos
    {
        private List<Torneo> listaTorneos; // Colección para almacenar los torneos
        private int siguienteIdTorneo = 1; // Para asignar IDs automáticamente y únicos

        public GestionTorneos()
        {
            listaTorneos = new List<Torneo>();
        }

        // 0.1. Agregar Torneo
        public void AgregarTorneo()
        {
            Console.Clear(); // Limpia la consola para una mejor experiencia de usuario
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          AGREGAR TORNEO          ");
            Console.WriteLine("══════════════════════════════════");

            Console.Write("Nombre del Torneo: ");
            string? nombre = Console.ReadLine();
            // Bucle para validar que el nombre no sea nulo, vacío o solo espacios en blanco
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("El nombre no puede estar vacío. Introduce el nombre del Torneo: ");
                nombre = Console.ReadLine();
            }

            Console.Write("Deporte (Ej: Fútbol, Baloncesto): ");
            string? deporte = Console.ReadLine();
            // Bucle para validar que el deporte no sea nulo, vacío o solo espacios en blanco
            while (string.IsNullOrWhiteSpace(deporte))
            {
                Console.Write("El deporte no puede estar vacío. Introduce el deporte: ");
                deporte = Console.ReadLine();
            }

            DateTime fechaInicio;
            Console.Write("Fecha de Inicio (YYYY-MM-DD): ");
            // Bucle para validar que la entrada sea una fecha válida
            while (!DateTime.TryParse(Console.ReadLine(), out fechaInicio))
            {
                Console.Write("Formato de fecha incorrecto. Intenta de nuevo (YYYY-MM-DD): ");
            }

            DateTime fechaFin;
            Console.Write("Fecha de Fin (YYYY-MM-DD): ");
            // Bucle para validar fecha fin y que no sea anterior a fecha inicio
            while (!DateTime.TryParse(Console.ReadLine(), out fechaFin) || fechaFin < fechaInicio)
            {
                if (fechaFin < fechaInicio)
                {
                    Console.Write("La fecha de fin no puede ser anterior a la de inicio. Intenta de nuevo (YYYY-MM-DD): ");
                }
                else
                {
                    Console.Write("Formato de fecha incorrecto. Intenta de nuevo (YYYY-MM-DD): ");
                }
            }

            // Aquí usamos el operador null-forgiving (!) porque los bucles de validación
            // garantizan que 'nombre' y 'deporte' no serán nulos o vacíos en este punto.
            Torneo nuevoTorneo = new Torneo(siguienteIdTorneo++, nombre!, deporte!, fechaInicio, fechaFin);
            listaTorneos.Add(nuevoTorneo);

            Console.WriteLine("\n¡Torneo agregado exitosamente!");
            nuevoTorneo.MostrarInfo();
        }

        // 0.2. Buscar Torneo por ID (método interno útil)
        public Torneo? BuscarTorneoPorId(int id)
        {
            return listaTorneos.FirstOrDefault(t => t.Id == id);
        }

        // Método para mostrar todos los torneos
        public void MostrarTorneos()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          LISTA DE TORNEOS        ");
            Console.WriteLine("══════════════════════════════════");

            if (listaTorneos.Any()) // Verifica si hay torneos en la lista
            {
                foreach (var torneo in listaTorneos)
                {
                    torneo.MostrarInfo();
                    Console.WriteLine("------------------------------"); // Separador entre torneos
                }
            }
            else
            {
                Console.WriteLine("No hay torneos registrados.");
            }
        }

        // 0.3. Eliminar Torneo
        public void EliminarTorneo()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          ELIMINAR TORNEO         ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del torneo a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                Torneo? torneoAEliminar = BuscarTorneoPorId(idEliminar); // Busca el torneo por ID
                if (torneoAEliminar != null)
                {
                    listaTorneos.Remove(torneoAEliminar); // Si lo encuentra, lo elimina de la lista
                    Console.WriteLine($"Torneo '{torneoAEliminar.Nombre}' (ID: {idEliminar}) eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún torneo con el ID: {idEliminar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }

        // 0.4. Actualizar Torneo
        public void ActualizarTorneo()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine("          ACTUALIZAR TORNEO       ");
            Console.WriteLine("══════════════════════════════════");
            Console.Write("Introduce el ID del torneo a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int idActualizar))
            {
                Torneo? torneoAActualizar = BuscarTorneoPorId(idActualizar); // Busca el torneo por ID
                if (torneoAActualizar != null)
                {
                    Console.WriteLine($"\nActualmente: Nombre: {torneoAActualizar.Nombre}, Deporte: {torneoAActualizar.Deporte}, Estado: {torneoAActualizar.Estado}");
                    Console.WriteLine("Deja en blanco para no cambiar el valor.");

                    Console.Write($"Nuevo Nombre ({torneoAActualizar.Nombre}): ");
                    string? nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoNombre)) // Si el usuario ingresa algo (no nulo, vacío o espacios), actualiza
                    {
                        torneoAActualizar.Nombre = nuevoNombre;
                    }

                    Console.Write($"Nuevo Deporte ({torneoAActualizar.Deporte}): ");
                    string? nuevoDeporte = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoDeporte))
                    {
                        torneoAActualizar.Deporte = nuevoDeporte;
                    }

                    Console.Write($"Nuevo Estado ({torneoAActualizar.Estado}): ");
                    string? nuevoEstado = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoEstado))
                    {
                        torneoAActualizar.Estado = nuevoEstado;
                    }
                    // Podrías añadir lógica similar para actualizar fechas si lo deseas

                    Console.WriteLine("\n¡Torneo actualizado exitosamente!");
                    torneoAActualizar.MostrarInfo();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún torneo con el ID: {idActualizar}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduce un número.");
            }
        }
    }
}