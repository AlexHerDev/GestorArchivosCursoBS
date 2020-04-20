using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparador_Archivos
{
    public interface IComparador
    {
        /// <summary>
		/// Propone al usuario las diferentes 
        /// alternatvas para comparar. 
		/// </summary>
		/// <returns>
        /// Devuelve:
        ///     1=> Si se elige comparar por 
        ///         fecha, nombre y tamaño. 
        ///     2=> Si se elige comparar por 
        ///         nombre y tamaño. 
        ///     3=> Solo por nombre. 
        /// </returns>
        int SeleccionCriterio();

        /// <summary>
        /// Compara todo el árbol de archivos y 
        /// subdirectorios, de dos directorios. 
        /// </summary>
        /// <param name="directorio1">nombre directorio 1</param>
        /// <param name="directorio2">nombre directorio 2</param>
        /// <param name="criterio">identificador de criterio(1,2,3)</param>
  
        void Compara(string directorio1, string directorio2, int criterio);
    }
}
