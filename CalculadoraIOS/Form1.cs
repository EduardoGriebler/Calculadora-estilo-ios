using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIOS
{
    public partial class Form1 : Form
    {
        // Atributos
        private bool calculoFeito = false;

        private enum Operadores { Soma, Subtracao, Multiplicacao, Divisao };
        private Operadores ValorOperador;

        // Ferramentas Para Mexer a Janela
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            txtResultado.Text = "0";
        }

        // Mexer a Janela
        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Botões (✖, 🗖, 🗕)
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Cor (✖, 🗖, 🗕)
        private void btnFechar_MouseEnter(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.Red;
        }
        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackColor = pnlBarraTitulo.BackColor;
        }
        private void btnMaximizar_MouseEnter(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.FromArgb(50, 50, 50);
        }
        private void btnMaximizar_MouseLeave(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = pnlBarraTitulo.BackColor;
        }
        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(50, 50, 50);
        }
        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = pnlBarraTitulo.BackColor;
        }

        // Botões (Numéros e Pontos)
        private void Numero_Click(object sender, EventArgs e)
        {
            if (calculoFeito)
            {
                txtResultado.Text = "0";
                txtResultado2.Text = "";
                calculoFeito = false;
            }

            Button botao = (Button)sender;
            string numeroPressionado = botao.Text;

            if (txtResultado.Text == "0" && numeroPressionado == "0")
            {
                return;
            }
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = numeroPressionado;
            }
            else
            {
                txtResultado.Text += numeroPressionado;
            }
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (calculoFeito)
            {
                txtResultado.Text = "0";
                txtResultado2.Text = "";
                calculoFeito = false;
            }

            string expressao = txtResultado.Text;

            string[] partesNumericas = expressao.Split('+', '-', '×', '÷');

            string numeroAtual = partesNumericas.Last().Trim();

            if (!numeroAtual.Contains(","))
            {
                txtResultado.Text += ",";
            }

        }

        // Botões ( +, -, x, /, Apagar, AC, Raiz, +/-, )
        private void btnSoma_Click(object sender, EventArgs e)
        {
            double valor1;
            valor1 = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = Convert.ToString($"{valor1}+");
            ValorOperador = Operadores.Soma;
            calculoFeito = false;
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            double valor1;
            valor1 = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = Convert.ToString($"{valor1}-");
            ValorOperador = Operadores.Subtracao;
            calculoFeito = false;
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            double valor1;
            valor1 = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = Convert.ToString($"{valor1}×");
            ValorOperador = Operadores.Multiplicacao;
            calculoFeito = false;
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            double valor1;
            valor1 = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = Convert.ToString($"{valor1}÷");
            ValorOperador = Operadores.Divisao;
            calculoFeito = false;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (calculoFeito)
            {
                txtResultado.Text = "0";
                txtResultado2.Text = "";
                calculoFeito = false;
            }

            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text = txtResultado.Text.Remove(txtResultado.Text.Length - 1);
            }

            if (txtResultado.Text == "")
            {
                txtResultado.Text = "0";
                txtResultado2.Text = "";
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            double valor1;
            double result;
            txtResultado.Text = "0";
            txtResultado2.Text = "";
            valor1 = 0;
            result = 0;
            calculoFeito = false;
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            double valor1;
            double result;
            valor1 = Convert.ToDouble(txtResultado.Text);
            result = Math.Sqrt(valor1);
            txtResultado.Text = Convert.ToString(result);
            txtResultado2.Text = Convert.ToString($"√{valor1}");
            calculoFeito = true;
        }

        private void btnMudancaDeSinal_Click(object sender, EventArgs e)
        {
            calculoFeito = false;

            string expressao = txtResultado.Text;

            string[] partes = expressao.Split('+', '-', '×', '÷');

            if (partes.Length == 0)
                return;

            string numeroAtual = partes.Last();

            if (string.IsNullOrWhiteSpace(numeroAtual))
                return;

            if (double.TryParse(numeroAtual, out double valor))
            {
                valor = -valor;
                int indiceUltimoNumero = expressao.LastIndexOf(numeroAtual);
                txtResultado.Text = expressao.Substring(0, indiceUltimoNumero) + valor.ToString();
            }
        }

        // Botão Igual
        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                double valor1, valor2, result = 0;
                char operadorChar = ' ';
                char[] operadores = { '+', '-', '×', '÷' };

                string expressaoCompleta = txtResultado.Text;

                int indiceOperador = expressaoCompleta.IndexOfAny(operadores, 1);

                if (indiceOperador == -1)
                {
                    return;
                }

                operadorChar = expressaoCompleta[indiceOperador];
                valor1 = Convert.ToDouble(expressaoCompleta.Substring(0, indiceOperador));
                valor2 = Convert.ToDouble(expressaoCompleta.Substring(indiceOperador + 1));
                result = 0;

                switch (ValorOperador)
                {
                    case Operadores.Soma:
                        result = valor1 + valor2;
                        break;
                    case Operadores.Subtracao:
                        result = valor1 - valor2;
                        break;
                    case Operadores.Multiplicacao:
                        result = valor1 * valor2;
                        break;
                    case Operadores.Divisao:
                        if (valor2 != 0)
                        {
                            result = valor1 / valor2;
                        }
                        else
                        {
                            txtResultado.Text = "Indefinido";
                            txtResultado2.Text = ($"{valor1}{operadorChar}{valor2}");
                            calculoFeito = true;
                            return;
                        }
                        break;
                }
                txtResultado2.Text = ($"{valor1}{operadorChar}{valor2}");
                txtResultado.Text = Convert.ToString(result);

                calculoFeito = true;
            }
            catch
            {
                txtResultado.Text = "Erro";
                calculoFeito = true;
            }
        }
    }
}