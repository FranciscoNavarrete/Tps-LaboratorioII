using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    public class Jornada
    {
        

        private List<Alumno> alumnos;
        private Profesor instructor;
        private Universidad.EClases clase;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        public Profesor Instructor
        {
            get 
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        #endregion

        #region Constructores
        public Jornada (Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        
        ///  constructor privado, inicializa la lista alumnos
       
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        #endregion

        
        /// Metodo estatico Guarda objeto Jornada en un archivo txt en el desktop de la pc
        
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Archivo.txt";
                Texto texto = new Texto();

                texto.Guardar(ruta, jornada.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
       
        /// Metodo estatico Lee archivo txt en el desktop de la pc
        
        
        public static string Leer()
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Archivo.txt";

                string lectura;

                Texto texto = new Texto();

                texto.Leer(ruta, out lectura);

                return lectura;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE: "+clase.ToString());
            sb.AppendLine(" POR "+this.Instructor.ToString());
            
            sb.AppendLine("Alumnos:");
            for (int i = 0; i < alumnos.Count; i++)
            {
                sb.AppendLine(alumnos[i].ToString());
            }
            return sb.ToString();
        }

        #region Sobrecarga operadores
        
        
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);   
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }
        
        public static Jornada operator +(Jornada j, Alumno a)
        {
            // foreach (var item in j.alumnos)
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;    
        }
        #endregion
    }
}
