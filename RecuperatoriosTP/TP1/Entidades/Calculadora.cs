using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion solicitada entre dos numeros, previo validar operador y convertirlo a char para usar ValidarOperador
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operador">string con el tipo de operador</param>
        /// <returns>double con el resultado de la operacion</returns>
        public static double Operar(Numero number1, Numero number2, string operador)
        {
            char aux = Convert.ToChar(operador);
            operador = ValidarOperador(aux);
            
            if (aux == '-')
            {
                return number1 - number2;
            }else if(aux == '*')
            {
                return number1 * number2;
            }else if (aux == '/')
            {
                return number1 / number2;
            }
            else
            {
                return number1 + number2;
            }
        }
        /// <summary>
        /// Valida q el string operador contenga signo de operacion correcta,
        /// que el operador recibido sea +, -, / o*. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador">contiene signo de la operacion</param>
        /// <returns>retorna el operador valido o en su defecto +</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }
            else {
                return "+";
            }
        }
    }
}
