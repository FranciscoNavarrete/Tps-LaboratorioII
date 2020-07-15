using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        
        public ArchivosException(Exception innerException):base ("Excepcion, No se ha guardado el archivo", innerException)
        {

        }
        
        public ArchivosException() : base()
        {

        }
    }
}
