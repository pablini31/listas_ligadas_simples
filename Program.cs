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
            
            while (opcion != 16)
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
            Console.WriteLine("──── OPERACIONES BÁSICAS ────");
            Console.WriteLine("1.  📋 Ver playlist completa");
            Console.WriteLine("2.  ➕ Agregar canción al final");
            Console.WriteLine("3.  ⏭️  Agregar canción como siguiente");
            Console.WriteLine("4.  ▶️  Reproducir siguiente canción");
            Console.WriteLine("5.  🔍 Buscar canción por título");
            Console.WriteLine("6.  🗑️  Eliminar canción");
            Console.WriteLine("7.  📊 Información de la playlist");
            Console.WriteLine("8.  🧹 Limpiar playlist");
            Console.WriteLine();
            Console.WriteLine("──── OPERACIONES AVANZADAS ────");
            Console.WriteLine("9.  🔀 Modo aleatorio (Shuffle)");
            Console.WriteLine("10. 📝 Ordenar por duración");
            Console.WriteLine("11. 🎲 Reproducir canción aleatoria");
            Console.WriteLine("12. 💾 Guardar playlist");
            Console.WriteLine("13. 📂 Cargar playlist");
            Console.WriteLine("14. 📊 Estadísticas avanzadas");
            Console.WriteLine("15. ℹ️  Acerca de (Comparación Proyecto 1 vs 2)");
            Console.WriteLine("16. 🚪 Salir");
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
                    AgregarCancionAlFinal(playlist);
                    break;
                case 3:
                    AgregarComoSiguiente(playlist);
                    break;
                case 4:
                    ReproducirSiguiente(playlist);
                    break;
                case 5:
                    BuscarCancion(playlist);
                    break;
                case 6:
                    EliminarCancion(playlist);
                    break;
                case 7:
                    MostrarInformacion(playlist);
                    break;
                case 8:
                    LimpiarPlaylist(playlist);
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
                    MostrarAcercaDe();
                    break;
                case 16:
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
        // OPERACIONES BÁSICAS (Ya existentes)
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
        
        static void AgregarComoSiguiente(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("     ⏭️  AGREGAR COMO SIGUIENTE            ");
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
                Console.WriteLine($"\n✅ '{titulo}' será la siguiente en reproducirse");
            }
            else
            {
                Console.WriteLine("\n❌ Duración inválida");
            }
            
            Console.ReadKey();
        }
        
        static void ReproducirSiguiente(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("       ▶️  REPRODUCIR SIGUIENTE             ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Cancion reproducida = playlist.ReproducirSiguiente();
            
            if (reproducida != null)
            {
                Console.WriteLine($"\n🎵 Reproduciendo: {reproducida.MostrarInfo()}");
                Console.WriteLine($"⏱️  Duración: {reproducida.DuracionFormateada()}");
            }
            else
            {
                Console.WriteLine("\n❌ No hay canciones en la playlist");
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
        
        static void EliminarCancion(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         🗑️  ELIMINAR CANCIÓN               ");
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
                Console.WriteLine($"\n▶️  Reproduciendo ahora:");
                Console.WriteLine($"   {actual.MostrarInfo()}");
            }
            else
            {
                Console.WriteLine("\n⏸️  No hay canción reproduciéndose");
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void LimpiarPlaylist(ListaPlaylist playlist)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("         🧹 LIMPIAR PLAYLIST               ");
            Console.WriteLine("═══════════════════════════════════════════");
            
            Console.Write("\n⚠️  ¿Estás seguro? (S/N): ");
            string confirmacion = Console.ReadLine().ToUpper();
            
            if (confirmacion == "S")
            {
                playlist.LimpiarPlaylist();
                Console.WriteLine("\n✅ Playlist limpiada correctamente");
            }
            else
            {
                Console.WriteLine("\n❌ Operación cancelada");
            }
            
            Console.ReadKey();
        }
        
        // ════════════════════════════════════════════════════════════
        // OPERACIONES AVANZADAS (Nuevas)
        // ════════════════════════════════════════════════════════════
        
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
        
        static void MostrarAcercaDe()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ℹ️  ACERCA DE ESTE PROYECTO                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("📚 COMPARACIÓN: PROYECTO 1 vs PROYECTO 2");
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("🔹 PROYECTO 1: Lista Ligada Simple Genérica");
            Console.WriteLine("   - Almacena: Números enteros (int)");
            Console.WriteLine("   - Propósito: Demostrar operaciones básicas");
            Console.WriteLine("   - Operaciones: 10 métodos fundamentales");
            Console.WriteLine();
            Console.WriteLine("🔹 PROYECTO 2: Playlist Musical");
            Console.WriteLine("   - Almacena: Objetos Cancion (título, artista, duración)");
            Console.WriteLine("   - Propósito: Aplicación a caso real");
            Console.WriteLine("   - Operaciones: 15 métodos (básicos + avanzados)");
            Console.WriteLine();
            Console.WriteLine("📊 CONCEPTOS DEMOSTRADOS:");
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine(" ✅ Adaptación de lista genérica a dominio específico");
            Console.WriteLine(" ✅ Operaciones con significado del mundo real");
            Console.WriteLine(" ✅ Estado adicional (canción actual)");
            Console.WriteLine(" ✅ Búsqueda por propiedades de objetos");
            Console.WriteLine(" ✅ Ordenamiento con algoritmo Burbuja");
            Console.WriteLine(" ✅ Persistencia de datos (guardar/cargar)");
            Console.WriteLine(" ✅ Estadísticas y análisis de datos");
            Console.WriteLine();
            Console.WriteLine("⚙️  COMPLEJIDADES ALGORÍTMICAS:");
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine(" • AgregarAlFinal():      O(1)  - Acceso directo con 'final'");
            Console.WriteLine(" • ReproducirSiguiente(): O(1)  - Eliminar del inicio");
            Console.WriteLine(" • BuscarPorTitulo():     O(n)  - Recorrido lineal");
            Console.WriteLine(" • OrdenarPorDuracion():  O(n²) - Algoritmo Burbuja");
            Console.WriteLine(" • ModoAleatorio():       O(n)  - Shuffle con Fisher-Yates");
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}