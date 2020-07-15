using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        
        public static bool Guardar(this string texto, string archivo) {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                StreamWriter writer = new StreamWriter(Path.Combine(path, archivo), true, System.Text.Encoding.UTF8);
                writer.WriteLine(texto);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
