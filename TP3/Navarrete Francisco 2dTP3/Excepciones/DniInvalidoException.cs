using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensaje = "DNi invalido";
        
        public DniInvalidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
        
        public DniInvalidoException(string mensaje) : base(mensaje) 
        {
        }
        
        public DniInvalidoException(Exception innerException) : base("DNi invalido", innerException)
        {
        
        }

        public DniInvalidoException() : base()
        {

        }
       

   
       
    }
}
