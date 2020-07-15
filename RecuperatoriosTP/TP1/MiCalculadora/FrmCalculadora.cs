using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        bool flagBinario=false;
        bool flagDecimal = false;
        bool operacion = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Realiza la operacion solicitada entre dos numeros con string operador
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna resultado de la operacion hecha llamando a Operar de Calculadora</returns>
        private static double Operar (string numero1, string numero2, string operador)
        {
            double result;

            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            result=Calculadora.Operar(n1, n2, operador);

            return result;            
        }
        /// <summary>
        /// Limpia todos los campos y flags
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            txtResultado.Text = "0";
            flagBinario = false;
            flagDecimal = false;
            operacion = false;
        }
        /// <summary>
        /// Llama al metodo Limpiar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text == "+" || cmbOperador.Text=="-" || cmbOperador.Text=="*" || cmbOperador.Text=="/") 
            {
                txtResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                flagBinario = false;
                flagDecimal = true;
                operacion = true;
            }
            else
            {
                txtResultado.Text = "Falta operador";
            }
        }

        /// <summary>
        /// Convierte numero decimal en binario previa validacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (operacion)
            {
                if (txtResultado.Text != "Valor invalido")
                {
                    if (!flagBinario)
                    {
                        txtResultado.Text = Numero.DecimalBinario(txtResultado.Text);
                        flagBinario = true;
                    }
                    else
                    {
                        MessageBox.Show("El numero ya es binario!");
                    }
                }
                else
                {
                    MessageBox.Show("Hay un error. Reingrese operacion");
                }
            }
            else
            {
                MessageBox.Show("No se ha realizado ninguna operacion aún");
            }
        }
        /// <summary>
        /// Convierte numero Binario a Decimal previa validacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (operacion)
            {
                if (txtResultado.Text != "Valor invalido")
                {
                    if ((flagBinario) || (!flagDecimal))
                    {
                        txtResultado.Text = Numero.BinarioDecimal(txtResultado.Text);
                        flagDecimal = true;
                        flagBinario = false;
                    }
                    else
                    {
                        MessageBox.Show("El numero debe ser Binario");
                    }
                }
                else
                {
                    MessageBox.Show("Hay un error. Reingrese operacion");
                }
            }
            else
            {
                MessageBox.Show("No se ha realizado ninguna operacion aún");
            }
        }
        /// <summary>
        /// Llama al metodo Close y cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
