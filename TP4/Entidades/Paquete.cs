using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public delegate void DelegadoEstado(object obj, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public event DelegadoEstado InformaEstado;

        #region Propiedades

        public string TrackingID
        {
            get {
                return trackingID;
            }
            set {
                trackingID = value;
            }
        }

        public EEstado Estado
        {
            get {
                return estado;
            }
            set {
                estado = value;
            }
        }

        public string DireccionEntrega
        {
            get {
                return direccionEntrega;
            }
            set {
                direccionEntrega = value;
            }
        }
        #endregion

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        
        /// ingreso el paquete en la base de datos
       
        public void MockCicloDeVida()
        {
            try
            {
                while (this.estado != EEstado.Entregado)
                {
                    Thread.Sleep(10000);
                    estado++;
                    InformaEstado.Invoke(this, new EventArgs());
                }
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {

            }
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} Estado {1}\n", MostrarDatos(this), Estado.ToString());
            return sb.ToString();
        }

        #region Sobrecarga de operadores
        
        /// Comparo paquetes segun el tracking
        
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }
        
        /// Comparo si dos paquetes son distintos segun el numero de tracking
        
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }

}
