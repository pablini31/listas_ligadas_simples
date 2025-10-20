using System;

namespace PlaylistMusical
{
    /// <summary>
    /// Lista ligada simple adaptada para gestionar una playlist musical
    /// Basada en el Proyecto 1 (LSS), pero especializada para canciones
    /// </summary>
    public class ListaPlaylist
    {
        private NodoCancion inicio;
        private NodoCancion final;
        private NodoCancion actual;
        
        public ListaPlaylist()
        {
            inicio = final = actual = null;
        }
        
        public bool EstaVacia()
        {
            return inicio == null;
        }
        
        public void AgregarAlFinal(Cancion cancion)
        {
            NodoCancion nuevo = new NodoCancion(cancion);
            
            if (inicio == null)
            {
                inicio = nuevo;
                final = nuevo;
                actual = nuevo;
            }
            else
            {
                final.siguiente = nuevo;
                final = nuevo;
            }
        }
        
        public void AgregarComoSiguiente(Cancion cancion)
        {
            NodoCancion nuevo = new NodoCancion(cancion);
            
            if (inicio == null)
            {
                inicio = nuevo;
                final = nuevo;
                actual = nuevo;
            }
            else if (actual == null)
            {
                nuevo.siguiente = inicio;
                inicio = nuevo;
                actual = nuevo;
            }
            else
            {
                nuevo.siguiente = actual.siguiente;
                actual.siguiente = nuevo;
                
                if (actual == final)
                    final = nuevo;
            }
        }
        
        public Cancion ReproducirSiguiente()
        {
            if (inicio == null)
                return null;
            
            Cancion cancionReproducida = inicio.dato;
            inicio = inicio.siguiente;
            
            if (inicio == null)
            {
                final = null;
                actual = null;
            }
            else
            {
                actual = inicio;
            }
            
            return cancionReproducida;
        }
        
        public Cancion BuscarPorTitulo(string titulo)
        {
            NodoCancion temp = inicio;
            
            while (temp != null)
            {
                if (temp.dato.Titulo.ToLower().Contains(titulo.ToLower()))
                    return temp.dato;
                
                temp = temp.siguiente;
            }
            
            return null;
        }
        
        public bool EliminarCancion(string titulo)
        {
            if (inicio == null)
                return false;
            
            if (inicio.dato.Titulo.ToLower() == titulo.ToLower())
            {
                inicio = inicio.siguiente;
                
                if (inicio == null)
                {
                    final = null;
                    actual = null;
                }
                else if (actual != null && actual.dato.Titulo.ToLower() == titulo.ToLower())
                {
                    actual = inicio;
                }
                
                return true;
            }
            
            NodoCancion anterior = inicio;
            NodoCancion temp = inicio.siguiente;
            
            while (temp != null)
            {
                if (temp.dato.Titulo.ToLower() == titulo.ToLower())
                {
                    anterior.siguiente = temp.siguiente;
                    
                    if (temp == final)
                        final = anterior;
                    
                    if (temp == actual)
                        actual = anterior;
                    
                    return true;
                }
                
                anterior = temp;
                temp = temp.siguiente;
            }
            
            return false;
        }
        
        public void MostrarPlaylist()
        {
            if (inicio == null)
            {
                Console.WriteLine("📭 Playlist vacía");
                return;
            }
            
            Console.WriteLine("\n🎵 PLAYLIST ACTUAL:");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            
            NodoCancion temp = inicio;
            int posicion = 1;
            
            while (temp != null)
            {
                string marcador = (temp == actual) ? "▶ " : "  ";
                Console.WriteLine($"{marcador}{posicion}. {temp.dato.MostrarInfo()}");
                
                temp = temp.siguiente;
                posicion++;
            }
            
            Console.WriteLine("═══════════════════════════════════════════════════════════");
        }
        
        public int ContarCanciones()
        {
            int contador = 0;
            NodoCancion temp = inicio;
            
            while (temp != null)
            {
                contador++;
                temp = temp.siguiente;
            }
            
            return contador;
        }
        
        public Cancion ObtenerCancionActual()
        {
            return actual?.dato;
        }
        
        public int DuracionTotal()
        {
            int total = 0;
            NodoCancion temp = inicio;
            
            while (temp != null)
            {
                total += temp.dato.Duracion;
                temp = temp.siguiente;
            }
            
            return total;
        }
        
        public void LimpiarPlaylist()
        {
            inicio = final = actual = null;
        }
        
        // ═══════════════════════════════════════════════════════════
        // MÉTODOS ADICIONALES
        // ═══════════════════════════════════════════════════════════
        /// <summary>
        /// Elimina la última canción de la playlist
        /// Equivalente a eliminarFinal() del Proyecto 1
        /// Complejidad: O(n) - debe encontrar el penúltimo nodo
        /// </summary>
        public Cancion EliminarUltimaCancion()
        {
            if (inicio == null)
                return null;
            
            // Si solo hay un nodo
            if (inicio.siguiente == null)
            {
                Cancion cancionEliminada = inicio.dato;
                inicio = final = actual = null;
                return cancionEliminada;
            }
            
            // Buscar el penúltimo nodo
            NodoCancion penultimo = inicio;
            while (penultimo.siguiente != final)
            {
                penultimo = penultimo.siguiente;
            }
            
            Cancion eliminada = final.dato;
            penultimo.siguiente = null;
            final = penultimo;
            
            // Si eliminamos la canción actual, actualizar
            if (actual == null || actual.siguiente == null)
            {
                actual = inicio;
            }
            
            return eliminada;
        }

        public void ModoAleatorio()
        {
            if (inicio == null || inicio.siguiente == null)
                return;
            
            int cantidad = ContarCanciones();
            Cancion[] canciones = new Cancion[cantidad];
            NodoCancion temp = inicio;
            
            for (int i = 0; i < cantidad; i++)
            {
                canciones[i] = temp.dato;
                temp = temp.siguiente;
            }
            
            Random rnd = new Random();
            for (int i = cantidad - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                Cancion aux = canciones[i];
                canciones[i] = canciones[j];
                canciones[j] = aux;
            }
            
            LimpiarPlaylist();
            foreach (Cancion c in canciones)
            {
                AgregarAlFinal(c);
            }
        }
        
        public void OrdenarPorDuracion()
        {
            if (ContarCanciones() <= 1)
                return;
            
            bool seguir = true;
            
            while (seguir)
            {
                seguir = false;
                NodoCancion primero = inicio;
                NodoCancion segundo = inicio.siguiente;
                
                while (segundo != null)
                {
                    if (primero.dato.Duracion > segundo.dato.Duracion)
                    {
                        Cancion temp = primero.dato;
                        primero.dato = segundo.dato;
                        segundo.dato = temp;
                        seguir = true;
                    }
                    
                    primero = primero.siguiente;
                    segundo = segundo.siguiente;
                }
            }
        }
        
        public Cancion ReproducirAleatoria()
        {
            int total = ContarCanciones();
            if (total == 0)
                return null;
            
            Random rnd = new Random();
            int posicion = rnd.Next(0, total);
            
            NodoCancion temp = inicio;
            for (int i = 0; i < posicion; i++)
            {
                temp = temp.siguiente;
            }
            
            actual = temp;
            return temp.dato;
        }
        
        public void GuardarEnArchivo(string nombreArchivo)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(nombreArchivo))
            {
                NodoCancion temp = inicio;
                
                while (temp != null)
                {
                    writer.WriteLine($"{temp.dato.Titulo}|{temp.dato.Artista}|{temp.dato.Duracion}");
                    temp = temp.siguiente;
                }
            }
        }
        
        public bool CargarDesdeArchivo(string nombreArchivo)
        {
            if (!System.IO.File.Exists(nombreArchivo))
                return false;
            
            LimpiarPlaylist();
            
            using (System.IO.StreamReader reader = new System.IO.StreamReader(nombreArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    string[] partes = linea.Split('|');
                    
                    if (partes.Length == 3)
                    {
                        string titulo = partes[0];
                        string artista = partes[1];
                        
                        if (int.TryParse(partes[2], out int duracion))
                        {
                            AgregarAlFinal(new Cancion(titulo, artista, duracion));
                        }
                    }
                }
            }
            
            return true;
        }
        
        public void MostrarEstadisticas()
        {
            if (inicio == null)
            {
                Console.WriteLine("📭 No hay datos para mostrar");
                return;
            }
            
            Cancion masLarga = inicio.dato;
            Cancion masCorta = inicio.dato;
            NodoCancion temp = inicio.siguiente;
            
            while (temp != null)
            {
                if (temp.dato.Duracion > masLarga.Duracion)
                    masLarga = temp.dato;
                
                if (temp.dato.Duracion < masCorta.Duracion)
                    masCorta = temp.dato;
                
                temp = temp.siguiente;
            }
            
            int total = ContarCanciones();
            int promedio = DuracionTotal() / total;
            
            Console.WriteLine("\n📊 ESTADÍSTICAS DE LA PLAYLIST:");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine($"🎵 Canción más larga: {masLarga.MostrarInfo()}");
            Console.WriteLine($"⏱️  Canción más corta: {masCorta.MostrarInfo()}");
            Console.WriteLine($"📊 Duración promedio: {promedio / 60}:{promedio % 60:D2}");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
        }
    }
}