namespace PlaylistMusical
{
    /// <summary>
    /// Nodo de la lista ligada simple
    /// Contiene una canción y la referencia al siguiente nodo
    /// 
    /// Comparación con Proyecto 1:
    /// LLSNodo tenía: int info, LLSNodo next
    /// NodoCancion tiene: Cancion dato, NodoCancion siguiente
    /// </summary>
    public class NodoCancion
    {
        // Dato almacenado (antes era "int info", ahora es "Cancion dato")
        public Cancion dato;
        
        // Referencia al siguiente nodo (antes era "next", ahora "siguiente")
        public NodoCancion siguiente;
        
        /// <summary>
        /// Constructor: Crea un nodo con una canción
        /// Por defecto, siguiente = null
        /// </summary>
        public NodoCancion(Cancion cancion)
        {
            dato = cancion;
            siguiente = null;
        }
        
        /// <summary>
        /// Constructor sobrecargado: Crea un nodo ya enlazado
        /// </summary>
        public NodoCancion(Cancion cancion, NodoCancion sig)
        {
            dato = cancion;
            siguiente = sig;
        }
    }
}