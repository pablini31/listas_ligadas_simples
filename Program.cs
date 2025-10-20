using System;

namespace PlaylistMusical
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaPlaylist playlist = new ListaPlaylist();
            int opcion = 0;
            
            // Mensaje de bienvenida
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║  🎵 SISTEMA DE PLAYLIST MUSICAL 🎵        ║");
            Console.WriteLine("║     Lista Ligada Simple - Proyecto 2      ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            Console.ReadKey();
            
            while (opcion != 15)
            {
                Console.Clear();
                MostrarMenu();
                
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                }
                catch
                {
                    opcion = 0;
                }
                
                Console.WriteLine();
                ProcesarOpcion(opcion, playlist);
            }
        }
        
        static void MostrarMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║      🎵 PLAYLIST MUSICAL - MENÚ 🎵        ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("──── OPERACIONES BÁSICAS (Requeridas) ────");
            Console.WriteLine("1.  📋 Ver playlist completa");
            Console.WriteLine("2.  ➕ Agregar canción al inicio");
            Console.WriteLine("3.  ➕ Agregar canción al final");
            Console.WriteLine("4.  ❌ Eliminar del inicio");
            Console.WriteLine("5.  ❌ Eliminar del final");
            Console.WriteLine("6.  🔍 Buscar canción por título");
            Console.WriteLine("7.  📊 Información de la playlist");
            Console.WriteLine();
            Console.WriteLine("──── OPERACIONES ADICIONALES ────");
            Console.WriteLine("8.  🗑️  Eliminar canción específica");
            Console.WriteLine("9.  🔀 Modo aleatorio (Shuffle)");
            Console.WriteLine("10. 📝 Ordenar por duración");
            Console.WriteLine("11. 🎲 Reproducir canción aleatoria");
            Console.WriteLine("12. 💾 Guardar playlist");
            Console.WriteLine("13. 📂 Cargar playlist");
            Console.WriteLine("14. 📊 Estadísticas avanzadas");
            Console.WriteLine("15. 🚪 Salir");
            Console.WriteLine();
            Console.Write("Selecciona una opción: ");
        }
        
        static void ProcesarOpcion(int opcion, ListaPlaylist playlist)
        {
            switch (opcion)
            {
                case 1:
                    MostrarPlaylistCompleta(playlist);
                    break;
                case 2:
                    AgregarCancionAlInicio(playlist);
                    break;
                case 3:
                    AgregarCancionAlFinal(playlist);
                    break;
                case 4:
                    EliminarDelInicio(playlist);
                    break;
                case 5:
                    EliminarDelFinal(playlist);
                    break;
                case 6:
                    BuscarCancion(playlist);
                    break;
                case 7:
                    MostrarInformacion(playlist);
                    break;
                case 8:
                    EliminarCancionEspecifica(playlist);
                    break;
                case 9:
                    ModoAleatorio(playlist);
                    break;
                case 10:
                    OrdenarPorDuracion(playlist);
                    break;
                case 11:
                    ReproducirAleatoria(playlist);
                    break;
                case 12:
                    GuardarPlaylist(playlist);
                    break;
                case 13:
                    CargarPlaylist(playlist);
                    break;
                case 14:
                    MostrarEstadisticas(playlist);
                    break;
                case 15:
                    Console.WriteLine("═══════════════════════════════════════════");
                    Console.WriteLine("👋 ¡Gracias por usar Playlist Musical!");
                    Console.WriteLine("═══════════════════════════════════════════");
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida. Intenta de nuevo.");
                    Console.ReadKey();
                    break;
            }
        }
        
        // ════════════════════════════════════════════════════════════
        // OPERACIONES BÁSICAS CORREGIDAS
        // ════════════════════════════════════════════════════════════
        
        static void MostrarPlaylistCompleta(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         📋 PLAYLIST COMPLETA              ");
            Console.WriteLine("═══════════════════════════════════════════");
            playlist.MostrarPlaylist();
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void AgregarCancionAlInicio(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("      ➕ AGREGAR CANCIÓN AL INICIO         ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Console.Write("Título de la canción: ");
            string titulo = Console.ReadLine();
            
            Console.Write("Artista: ");
            string artista = Console.ReadLine();
            
            Console.Write("Duración (en segundos): ");
            int duracion;
            
            if (int.TryParse(Console.ReadLine(), out duracion) && duracion > 0)
            {
                Cancion nueva = new Cancion(titulo, artista, duracion);
                playlist.AgregarComoSiguiente(nueva);
                Console.WriteLine($"\n✅ '{titulo}' agregada al inicio de la playlist");
            }
            else
            {
                Console.WriteLine("\n❌ Duración inválida");
            }
            
            Console.ReadKey();
        }
        
        static void AgregarCancionAlFinal(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("      ➕ AGREGAR CANCIÓN AL FINAL          ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Console.Write("Título de la canción: ");
            string titulo = Console.ReadLine();
            
            Console.Write("Artista: ");
            string artista = Console.ReadLine();
            
            Console.Write("Duración (en segundos): ");
            int duracion;
            
            if (int.TryParse(Console.ReadLine(), out duracion) && duracion > 0)
            {
                Cancion nueva = new Cancion(titulo, artista, duracion);
                playlist.AgregarAlFinal(nueva);
                Console.WriteLine($"\n✅ '{titulo}' agregada al final de la playlist");
            }
            else
            {
                Console.WriteLine("\n❌ Duración inválida");
            }
            
            Console.ReadKey();
        }
        
        // ✅ CORREGIDO: Eliminar del inicio SIN preguntar
        static void EliminarDelInicio(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         ❌ ELIMINAR DEL INICIO            ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Cancion eliminada = playlist.ReproducirSiguiente();
            
            if (eliminada != null)
            {
                Console.WriteLine($"\n✅ Canción eliminada del inicio:");
                Console.WriteLine($"   {eliminada.MostrarInfo()}");
            }
            else
            {
                Console.WriteLine("\n❌ La playlist está vacía");
            }
            
            Console.ReadKey();
        }
        
        // ✅ NUEVO: Eliminar del final SIN preguntar
        static void EliminarDelFinal(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         ❌ ELIMINAR DEL FINAL             ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Cancion eliminada = playlist.EliminarUltimaCancion();
            
            if (eliminada != null)
            {
                Console.WriteLine($"\n✅ Canción eliminada del final:");
                Console.WriteLine($"   {eliminada.MostrarInfo()}");
            }
            else
            {
                Console.WriteLine("\n❌ La playlist está vacía");
            }
            
            Console.ReadKey();
        }
        
        static void BuscarCancion(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         🔍 BUSCAR CANCIÓN                 ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Console.Write("Ingresa el título (o parte del título): ");
            string titulo = Console.ReadLine();
            
            Cancion encontrada = playlist.BuscarPorTitulo(titulo);
            
            if (encontrada != null)
            {
                Console.WriteLine($"\n✅ Canción encontrada:");
                Console.WriteLine($"   {encontrada.MostrarInfo()}");
            }
            else
            {
                Console.WriteLine($"\n❌ No se encontró ninguna canción con '{titulo}'");
            }
            
            Console.ReadKey();
        }
        
        static void MostrarInformacion(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("       📊 INFORMACIÓN DE LA PLAYLIST       ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            int totalCanciones = playlist.ContarCanciones();
            int duracionTotal = playlist.DuracionTotal();
            int minutos = duracionTotal / 60;
            int segundos = duracionTotal % 60;
            
            Console.WriteLine($"\n📀 Total de canciones: {totalCanciones}");
            Console.WriteLine($"⏱️  Duración total: {minutos}:{segundos:D2} ({duracionTotal} segundos)");
            
            Cancion actual = playlist.ObtenerCancionActual();
            if (actual != null)
            {
                Console.WriteLine($"\n▶️  Primera canción:");
                Console.WriteLine($"   {actual.MostrarInfo()}");
            }
            else
            {
                Console.WriteLine("\n⏸️  Playlist vacía");
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        // ════════════════════════════════════════════════════════════
        // OPERACIONES ADICIONALES
        // ════════════════════════════════════════════════════════════
        
        static void EliminarCancionEspecifica(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("     🗑️  ELIMINAR CANCIÓN ESPECÍFICA       ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            playlist.MostrarPlaylist();
            
            Console.Write("\nIngresa el título exacto de la canción a eliminar: ");
            string titulo = Console.ReadLine();
            
            if (playlist.EliminarCancion(titulo))
            {
                Console.WriteLine($"\n✅ Canción '{titulo}' eliminada correctamente");
            }
            else
            {
                Console.WriteLine($"\n❌ No se encontró la canción '{titulo}'");
            }
            
            Console.ReadKey();
        }
        
        static void ModoAleatorio(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         🔀 MODO ALEATORIO (SHUFFLE)       ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            int total = playlist.ContarCanciones();
            
            if (total < 2)
            {
                Console.WriteLine("\n❌ Se necesitan al menos 2 canciones para mezclar");
            }
            else
            {
                playlist.ModoAleatorio();
                Console.WriteLine($"\n✅ Playlist mezclada aleatoriamente ({total} canciones)");
                Console.WriteLine("\n📋 Nuevo orden:");
                playlist.MostrarPlaylist();
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void OrdenarPorDuracion(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         📝 ORDENAR POR DURACIÓN           ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            if (playlist.ContarCanciones() < 2)
            {
                Console.WriteLine("\n❌ Se necesitan al menos 2 canciones para ordenar");
            }
            else
            {
                Console.WriteLine("\n⏳ Ordenando (Algoritmo Burbuja)...");
                playlist.OrdenarPorDuracion();
                Console.WriteLine("\n✅ Playlist ordenada de menor a mayor duración");
                Console.WriteLine("\n📋 Lista ordenada:");
                playlist.MostrarPlaylist();
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void ReproducirAleatoria(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("       🎲 REPRODUCIR CANCIÓN ALEATORIA     ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Cancion aleatoria = playlist.ReproducirAleatoria();
            
            if (aleatoria != null)
            {
                Console.WriteLine($"\n🎵 Reproduciendo aleatoriamente:");
                Console.WriteLine($"   {aleatoria.MostrarInfo()}");
                Console.WriteLine($"⏱️  Duración: {aleatoria.DuracionFormateada()}");
            }
            else
            {
                Console.WriteLine("\n❌ No hay canciones en la playlist");
            }
            
            Console.ReadKey();
        }
        
        static void GuardarPlaylist(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         💾 GUARDAR PLAYLIST               ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            if (playlist.EstaVacia())
            {
                Console.WriteLine("\n❌ No hay canciones para guardar");
            }
            else
            {
                Console.Write("\nNombre del archivo (sin extensión): ");
                string nombre = Console.ReadLine();
                string archivo = nombre + ".txt";
                
                try
                {
                    playlist.GuardarEnArchivo(archivo);
                    Console.WriteLine($"\n✅ Playlist guardada en: {archivo}");
                    Console.WriteLine($"📁 Ubicación: {System.IO.Path.GetFullPath(archivo)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ Error al guardar: {ex.Message}");
                }
            }
            
            Console.ReadKey();
        }
        
        static void CargarPlaylist(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         📂 CARGAR PLAYLIST                ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Console.Write("\nNombre del archivo (sin extensión): ");
            string nombre = Console.ReadLine();
            string archivo = nombre + ".txt";
            
            if (playlist.CargarDesdeArchivo(archivo))
            {
                int total = playlist.ContarCanciones();
                Console.WriteLine($"\n✅ Playlist cargada correctamente ({total} canciones)");
                playlist.MostrarPlaylist();
            }
            else
            {
                Console.WriteLine($"\n❌ No se encontró el archivo: {archivo}");
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void MostrarEstadisticas(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("       📊 ESTADÍSTICAS AVANZADAS           ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            if (playlist.EstaVacia())
            {
                Console.WriteLine("\n📭 No hay datos para mostrar");
            }
            else
            {
                playlist.MostrarEstadisticas();
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}