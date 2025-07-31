using System;

namespace ConsoleApp1.Modelos
{
    public class Jugador
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }
        public int IdEquipo { get; set; }

        // Constructor
        public Jugador(int id, string nombreCompleto, int edad, string posicion, int idEquipo)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Edad = edad;
            Posicion = posicion;
            IdEquipo = idEquipo;
        }

        // Método para mostrar la información del jugador
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {NombreCompleto}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Posición: {Posicion}");
            Console.WriteLine($"ID de Equipo Asignado: {IdEquipo}");
        }
    }
}