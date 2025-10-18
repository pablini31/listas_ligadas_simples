using System;

namespace PlaylistMusical
{
    /// <summary>
    /// Representa una canción con sus propiedades básicas
    /// Esta es la "información" que guardaremos en cada nodo
    /// </summary>
    public class Cancion
    {
        // Propiedades de una canción
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int Duracion { get; set; } // Duración en segundos
        
        /// <summary>
        /// Constructor: Crea una nueva canción
        /// </summary>
        public Cancion(string titulo, string artista, int duracion)
        {
            Titulo = titulo;
            Artista = artista;
            Duracion = duracion;
        }
        
        /// <summary>
        /// Retorna la información de la canción en formato legible
        /// Ejemplo: "Imagine - John Lennon [3:03]"
        /// </summary>
        public string MostrarInfo()
        {
            int minutos = Duracion / 60;
            int segundos = Duracion % 60;
            return $"{Titulo} - {Artista} [{minutos}:{segundos:D2}]";
        }
        
        /// <summary>
        /// Retorna solo la duración en formato MM:SS
        /// </summary>
        public string DuracionFormateada()
        {
            int minutos = Duracion / 60;
            int segundos = Duracion % 60;
            return $"{minutos}:{segundos:D2}";
        }
    }
}