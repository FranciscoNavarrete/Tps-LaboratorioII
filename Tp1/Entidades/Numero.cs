using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        public Numero ()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;

        }
        public Numero (string strNumber)
        {
           this.SetNumero=strNumber;
           
        }
        #endregion

        /// <summary>
        /// Asigno al campo numero un string previamente validado por la funcion ValidarNumero
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Seteara el numero validado
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el string recibido sea numerico y lo convierto a double
        /// </summary>
        private double ValidarNumero (string strNumber)
        {
            double numero;
            if(double.TryParse(strNumber, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Convierto un string que contiene un binario en decimal
        /// </summary>
        public static string BinarioDecimal (string binario)
        {
            char[] numBinario = binario.ToCharArray();

            Array.Reverse(numBinario);
            int sum = 0;
            for (int i = 0; i < numBinario.Length; i++)
            {
                if (numBinario[i] != '1' && numBinario[i] !='0')
                {
                    return "Valor invalido";
                }
            }

            for (int i = 0; i < numBinario.Length; i++)
            {
                if (numBinario[i] == '1')
                {
                      sum += (int)Math.Pow(2, i);
                }
            }
            return sum.ToString();
        }
    /// <summary>
    /// Convierto un double a string binario
    /// </summary>
        public static string DecimalBinario (double numero)
        {
            int entero = (int)numero;
            if (entero <= 0)
            {
                return "Valor invalido";
            }
            string binario = "";
            while (entero > 0)
            {
                binario = (entero % 2).ToString() + binario;
                entero = entero / 2;
            }
            return binario.ToString();

    }
        /// <summary>
        /// Convierto decimal a Binario
        /// </summary>
        public static string DecimalBinario (string numero)
        {
            double entero;
            string strBinario;
            if(double.TryParse(numero, out entero)){
                strBinario = DecimalBinario(entero);
                return strBinario;
            }
            else
            {
                return "Valor invalido";
            }
            
        }
        #region Sobrecarga de operadores
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero!= 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}
