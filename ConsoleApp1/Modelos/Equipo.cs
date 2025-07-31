using System;
using System.Collections.Generic;

namespace ConsoleApp1.Modelos
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Estadio { get; set; }

        // Constructor para crear objetos Equipo
        public Equipo(int id, string nombre, string ciudad, string estadio)
        {
            Id = id;
            Nombre = nombre;
            Ciudad = ciudad;
            Estadio = estadio;
        }

        // Método para mostrar la información del equipo
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Ciudad: {Ciudad}");
            Console.WriteLine($"Estadio: {Estadio}");
        }
    }
}