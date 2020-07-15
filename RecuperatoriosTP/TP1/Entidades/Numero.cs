using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        /// <summary>
        /// Constructor, setea numero en 0.
        /// </summary>
        public Numero ()
        {
            this.numero = 0;
        }

        public Numero(double numero):this()
        {
            this.numero = numero;

        }
        /// <summary>
        /// Constructor que setea el string numero mediante la propiedad SetNumero
        /// </summary>
        /// <param name="strNumber"></param>
        public Numero (string strNumber)
        {
           this.SetNumero=strNumber;
           
        }
        #endregion

        /// <summary>
        /// Propiedad q seteara el numero validado
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
        /// <param name="strNumber">strign conteniendo un numero</param>
        /// <returns>numero convertido a double o 0 si no lo pudo parsear</returns>
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

        public static bool EsBinario(string binario)
        {
            char[] numBinario = binario.ToCharArray();
            for (int i = 0; i < numBinario.Length; i++)
            {
                if (numBinario[i] != '1' && numBinario[i] != '0')
                {
                    return false;
                }
            }
            return true;

        }
        /// <summary>
        /// Convierto un string que contiene un binario en decimal
        /// </summary>
        /// <param name="binario">strign que contiene binario</param>
        /// <returns></returns>
        public static string BinarioDecimal (string binario)
        {
            if (!EsBinario(binario))
            {
                return "Valor invalido";
            }
            else
            {
                char[] numBinario = binario.ToCharArray();

                Array.Reverse(numBinario);
                int sum = 0;

                for (int i = 0; i < numBinario.Length; i++)
                {
                    if (numBinario[i] == '1')
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
                return sum.ToString();
            }
        }
    /// <summary>
    /// Convierto un double a string binario tomando su parte entera
    /// </summary>
    /// <param name="numero"></param>
    /// <returns>retorno string con binario o valor invalido si fuera negativo o 0</returns>
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
        /// Convierto decimal a Binario previa validacion
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>string conteniendo binario</returns>
        public static string DecimalBinario (string numero)
        {
            double entero;
            string strBinario;
            if(double.TryParse(numero, out entero)){
                if (entero > 0)
                {
                    strBinario = DecimalBinario(entero);
                    return strBinario;
                }
                else
                {
                    return "Valor invalido";
                }
            }
            else
            {
                return "Valor invalido";
            } 
        }

        #region Sobrecarga de operadores

        /// <summary>
        /// Resta el atributo numero de dos objetos de la clase Numero.
        /// </summary>
        /// <param name="n1">objeto de tipo Numero</param>
        /// <param name="n2">objeto de tipo Numero</param>
        /// <returns>Retorno el resultado de la operacion resta</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Multiplica el atributo numero de dos objetos de la clase Numero.
        /// </summary>
        /// <param name="n1">objeto de tipo Numero</param>
        /// <param name="n2">objeto de tipo Numero</param>
        /// <returns>Retorno el resultado de la operacion multiplicar</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Divide el atributo numero de dos objetos de la clase Numero. Valido que el divisor sea != 0
        /// </summary>
        /// <param name="n1">objeto de tipo Numero</param>
        /// <param name="n2">objeto de tipo Numero</param>
        /// <returns>retorno el resultado de la operacion division, si el divisor es 0 retorno MinValue</returns>
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
        /// <summary>
        /// Suma el atributo numero de dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">objeto de tipo Numero</param>
        /// <param name="n2">objeto de tipo Numero</param>
        /// <returns>retorno el resultado de la operacion suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}
