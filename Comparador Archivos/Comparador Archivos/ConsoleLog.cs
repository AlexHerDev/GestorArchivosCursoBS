using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparador_Archivos
{
    class ConsoleLog : ILogger
    {
        public void EscribeLog(List<(string,string)> texto, string nombre = null)
        {
            foreach (var linea in texto)
            {
                Console.WriteLine(linea);
            }

        }
    }
}
