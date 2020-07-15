using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    public class Profesor : Universitario
    {
        

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Propiedades
        public Queue<Universidad.EClases> ClasesDelDia
        {
            get
            {
                return clasesDelDia;
            }
            set
            {
                clasesDelDia = value;
            }
        }
        #endregion

        #region Constructores
        
        static Profesor()
        {
            random = new Random();
        }
   
        
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(legajo:id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        
        public Profesor() : base()
        {

        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases clases in this.clasesDelDia)
            {            
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
            
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
        #endregion
    }
}
