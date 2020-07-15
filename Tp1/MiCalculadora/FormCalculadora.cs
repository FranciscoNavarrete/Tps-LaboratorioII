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
    public partial class FormCalculadora : Form
    {
        bool flagBinario=false;
        bool flagDecimal = false;
        bool operacion = false;
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar (string numero1, string numero2, string operador)
        {
            double result;

            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            result=Calculadora.Operar(n1, n2, operador);

            return result;            
        }
       

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperardor.Text = "";
            lblResultado.Text = "0";
            flagBinario = false;
            flagDecimal = false;
            operacion = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperardor.Text == "+" || cmbOperardor.Text=="-" || cmbOperardor.Text=="*" || cmbOperardor.Text=="/") 
            {
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperardor.Text).ToString();
                flagBinario = false;
                flagDecimal = true;
                operacion = true;
            }
            else
            {
                lblResultado.Text = "Falta operador";
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
                if (lblResultado.Text != "Valor invalido")
                {
                    if (!flagBinario)
                    {
                        lblResultado.Text = Entidades.Numero.DecimalBinario(lblResultado.Text);
                        flagBinario = true;
                    }
                    else
                    {
                        MessageBox.Show("El numero Ya es binario!");
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
                if (lblResultado.Text != "Valor invalido")
                {
                    if ((flagBinario) || (!flagDecimal))
                    {
                        lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
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
        /// Llama al metodo Close y cierra la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
