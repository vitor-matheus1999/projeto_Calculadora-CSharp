using System.Configuration;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        //Propriedade
        public string Operador { get; set; } // Propriedade que definine o operador que será utilizado
        public char[] charArray // Propriedade que converte a string presente na textBox em um array de caracteres para que possa ser trabalhado a exclusão do zero a esquerda. 
        {
            get
            {
                this.arrayCaracteres = textBox1.Text.ToCharArray(0, textBox1.Text.Length);           
                return this.arrayCaracteres;
            }
        }
        //Atributos
        public char[] arrayCaracteres; // Atributo que recebe o array de caracteres que será trabalhado nas exceções
        public string[] valor = new string[2]; // Atributo responsável por receber um Array de duas posições que controla os valores das variáveis que estarão no cálculo realizado pela cálculadora.
        public int posicaoArray = 0; // Atributo que contém a posição em que o array de valor está, seu valor padrão inícial é zero.
        public bool divisaoPorZeroConfirmacao;//Atributo que retorna verdadeiro caso sejá realizado uma divisão por zero, reiniciando a calculadora para estado inicíal.
        public int quantidadeVezesBotaoClicado;//Atributo responsável por atuar como contador de vezes que o botão que insere as operações matemáticas é clicado.

        struct ValorInicial
        {
            
        }

        //Métodos
        public Form1()
        {
            this.valor[0] = "0";
            this.valor[1] = "0";
            InitializeComponent();
        }
        public void excluirZeroAEsquerda()
        {
            if (this.charArray[0] == '0')
            {
                textBox1.Clear();
            };
        }
        public void exibirExcecaoDividirPorZero(bool confirmacao)
        {
            if (confirmacao == true)
            {
                textBox1.Clear();
                textBox1.BackColor = SystemColors.Control;
                textBox1.Font = new Font(textBox1.Font.FontFamily, 24);
                textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
                this.valor[0] = "0";
                this.valor[1] = "0";
                divisaoPorZeroConfirmacao = false;
                posicaoArray = 0;
            }
        }
        public int clicouOperador(bool confirmarOperador)
        {
            if (confirmarOperador == true)
            { posicaoArray = 1; }
       
            return posicaoArray;
        }
        public void realizarConta(string operador)
        {
            long resultado;
            float resultadoFloat;

            switch (operador)
            {
                case "+":
                    resultado = Int64.Parse(this.valor[0]) + Int64.Parse(this.valor[1]);
                    this.valor[0] = resultado.ToString();
                    this.valor[1] = "0";
                    textBox1.Text = this.valor[0];
                    break;

                case "-":
                    resultado = Int64.Parse(this.valor[0]) - Int64.Parse(this.valor[1]);
                    this.valor[0] = resultado.ToString();
                    this.valor[1] = "0";
                    textBox1.Text = this.valor[0];
                    break;

                case "*":
                    resultado = Int64.Parse(this.valor[0]) * Int64.Parse(this.valor[1]);
                    this.valor[0] = resultado.ToString();
                    this.valor[1] = "0";
                    textBox1.Text = this.valor[0];
                    break;
                case "/":
                   
                    resultadoFloat = float.Parse(this.valor[0]) / float.Parse(this.valor[1]);
                    this.valor[0] = resultadoFloat.ToString();
                    this.valor[1] = "0";
                    textBox1.Text = this.valor[0];
                                                      
                    if(float.IsInfinity(resultadoFloat) == true)
                    {

                        divisaoPorZeroConfirmacao = true;
                        textBox1.Font = new Font(textBox1.Font.FontFamily, 15);
                        textBox1.Text = "Não é possível dividir por zero";
                    }
                    break;   
                default:
                    this.valor[0] = "0";
                    this.valor[1] = "0";
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if(quantidadeVezesBotaoClicado > 1 )
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            this.valor[posicaoArray] = textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 2;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 3;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 4;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 5;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 6;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 7;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();
            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 8;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            excluirZeroAEsquerda();

            if (quantidadeVezesBotaoClicado > 1)
            {
                textBox1.Clear();
                textBox1.Text += this.valor[1];
                excluirZeroAEsquerda();
            }
            exibirExcecaoDividirPorZero(divisaoPorZeroConfirmacao);
            int valor = 9;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (this.charArray[0] == '0')
            {
                return;
            }
            
            int valor = 0;
            this.valor[posicaoArray] = textBox1.Text += Convert.ToString(valor);
        }


        private void button11_Click(object sender, EventArgs e)
        {
            string soma = "+";
            quantidadeVezesBotaoClicado++;

            if(quantidadeVezesBotaoClicado > 1)
            {
                realizarConta(soma);
                textBox1.Text = this.valor[0];         
            }
            else
            {
                textBox1.Clear();
                textBox1.Text = "0";
                this.Operador = soma;
                clicouOperador(true);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {

            string subtracao = "-";
            quantidadeVezesBotaoClicado++;

            if (quantidadeVezesBotaoClicado > 1) 
            {
                realizarConta(subtracao);
                textBox1.Text = this.valor[0];
            }
            else
            {
                textBox1.Clear();
                textBox1.Text = "0";
                this.Operador = subtracao;
                clicouOperador(true);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string divisao = "/";
            quantidadeVezesBotaoClicado++;

            if (quantidadeVezesBotaoClicado > 1)
            {
                realizarConta(divisao);
                textBox1.Text = this.valor[0];
            }
            else
            {

                textBox1.Clear();
                textBox1.Text = "0";
                this.Operador = divisao;
                clicouOperador(true);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string multiplicacao = "*";
            quantidadeVezesBotaoClicado++;

            if (quantidadeVezesBotaoClicado > 1)
            {
                realizarConta(multiplicacao);
                textBox1.Text = this.valor[0];
            }
            else
            {
                textBox1.Clear();
                textBox1.Text = "0";
                this.Operador = multiplicacao;
                clicouOperador(true);

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.BackColor = SystemColors.Control;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 24);
            textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            textBox1.Text = this.valor[0] = "0";
            this.valor[1] = "0";
            clicouOperador(false);
            posicaoArray = 0;
            quantidadeVezesBotaoClicado = 0;
            divisaoPorZeroConfirmacao = false;
        }


        private void Resultado_Click(object sender, EventArgs e)
        {
            this.posicaoArray = 0;

            string operador = this.Operador;

            quantidadeVezesBotaoClicado = 0;

            realizarConta(operador);
        }
    }
}