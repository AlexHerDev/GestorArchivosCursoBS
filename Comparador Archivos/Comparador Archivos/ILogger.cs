using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparador_Archivos
{
    public interface ILogger
    {
        void EscribeLog(List<(string, string)> textLog, string nombreFichero = null);
    }
}
