using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        

        static SqlCommand command;
        static SqlConnection connection;

        static PaqueteDAO()
        {
            
        }

        public static bool Insertar (Paquete p)
        {
            string alumno = "FranciscoNavarrete";
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection();

                connection.ConnectionString = @"Data Source=FRANCISCO\SQLEXPRESS; Initial Catalog=correo-sp-2017;Integrated Security=True";
                connection.Open();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("direccion", p.DireccionEntrega));
                command.Parameters.Add(new SqlParameter("tracking", p.TrackingID));
                command.Parameters.Add(new SqlParameter("alumno", alumno));
                command.CommandText = "Insert into Paquetes (direccionEntrega, trackingID, alumno) values (@direccion, @tracking, @alumno)";

                SqlDataReader sqlDataReader = command.ExecuteReader();
               
            }
            catch(Exception ex)
            {
                throw new Exception("Error en la conexion a la base de datos", ex);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
