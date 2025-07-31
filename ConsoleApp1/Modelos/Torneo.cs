using System;
using System.Collections.Generic;

namespace ConsoleApp1.Modelos

{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Deporte { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

        public Torneo(int id, string nombre, string deporte, DateTime fechaInicio, DateTime fechaFin)
        {
            Id = id;
            Nombre = nombre;
            Deporte = deporte;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = "Pendiente";
        }

        // Método para mostrar la información del torneo
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Deporte: {Deporte}");
            Console.WriteLine($"Inicio: {FechaInicio.ToShortDateString()}");
            Console.WriteLine($"Fin: {FechaFin.ToShortDateString()}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}