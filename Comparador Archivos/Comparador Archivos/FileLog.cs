using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparador_Archivos
{
    class FileLog : ILogger
    {
        public void EscribeLog(List<(string,string)> texto, string nombreFichero = null)
        {
            DateTime fechaActual = DateTime.Now;

            string extension = ".txt";

            if (nombreFichero == null)
            {
                nombreFichero = fechaActual.ToString("yyyyMMddHHmmss") + extension;
            } else
            {
                nombreFichero = nombreFichero + extension; 
            }

            StreamWriter fichero;

            try
            {
                fichero = File.CreateText(nombreFichero);

                if (texto.Count == 0)
                {
                    fichero.WriteLine("Nada que mostrar");
                }
                else
                {
                    foreach (var linea in texto)
                    {
                        fichero.WriteLine(linea);
                    }
                }

                fichero.Close();
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }
    }
}
