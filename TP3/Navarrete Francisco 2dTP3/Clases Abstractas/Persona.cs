using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Propiedades
   
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
       
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); ; }
        }

       
        public ENacionalidad Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }
       
        public int Dni
        {
            get { return this.dni; }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
      
        public string StringToDni
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
       
        public Persona()
        {
           
        }
        
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.Dni = dni;
        }
       
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        
        /// Valida el dni dependiendo de la nacionalidad si es correcto caso contrario lanza excepcion
        
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni;

            if (nacionalidad == (ENacionalidad)0 && dato >= 1 && dato <= 89999999)
            {
                dni = dato;
            }
            else if (nacionalidad == (ENacionalidad)1 && dato >= 90000000 && dato <= 99999999)
            {
                dni = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La Nacionalidad no se condice con el Dni.");
            }
            return dni;
        }

        
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if ((dato.Length <= 8)&&int.TryParse(dato, out int dni))
            {
                resultado = ValidarDni(nacionalidad, dni);
                if (resultado != 0)
                {
                    return resultado;
                }
            }

            throw new DniInvalidoException(" El Dni no es válido");
        }

       
        private string ValidarNombreApellido(string dato)
        {
            int aux = 0;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                {
                    aux++;
                }
            }
            if (aux != 0)
            {
                dato = string.Empty;
                return dato;
            }
            else
            {
                return dato;
            }
        }

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NOMBRE COMPLETO :" + apellido);
            sb.AppendLine(", " + nombre);
            //sb.Append(dni.ToString()); --> el ejemplo no muestra DNI
            sb.AppendLine("NACIONALIDAD: " + nacionalidad.ToString());
            return sb.ToString();
        }
        #endregion
    }
}