using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        double sayi1, sayi2;
        string islem,islev;

        public Form2()
        {
            InitializeComponent();
        }




        private void buttonIslem(object sender, EventArgs e)
        {
            sayi1 = Double.Parse(textBox1.Text);
            islem = ((Button)sender).Text;
            textBox1.Text = "";
            textBox2.Text += islem;
        }

        private void buttonEsittir(object sender, EventArgs e)
        {
            sayi2 = Double.Parse(textBox1.Text);
            textBox2.Text += "=";
            switch (islem)
            {
                case "X":
                    {
                        textBox1.Text = (sayi1 * sayi2).ToString();
                    }
                    break;
                case "/":
                    {
                        textBox1.Text = (sayi1 / sayi2).ToString();
                    }
                    break;
                case "+":
                    {
                        textBox1.Text = (sayi1 + sayi2).ToString();
                    }
                    break;
                case "-":
                    {
                        textBox1.Text = (sayi1 - sayi2).ToString();
                    }
                    break;
            }


        }

        private void buttonSayiClick(object sender, EventArgs e)
        {

            textBox1.Text += ((Button)sender).Text;
            textBox2.Text += ((Button)sender).Text;
        }

        private void buttonC(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonIslev(object sender, EventArgs e)
        {
            islev = ((Button)sender).Text;


            switch (islev)
            {
                case "KKÖK":
                    {
                        textBox2.Text = "Karekok(" + textBox1.Text + ")=";
                        textBox1.Text = Math.Sqrt(Double.Parse(textBox1.Text)).ToString();
                    }
                    break;
                case "x^2":
                    {
                        textBox2.Text = "(" + textBox1.Text + ")^2=";
                        textBox1.Text = Math.Pow(Double.Parse(textBox1.Text), 2).ToString();
                    }
                    break;
            }

        }

        private void buttonArtiEksi(object sender, EventArgs e)
        {
            textBox1.Text = "-" + textBox1.Text;
        }

        }
}
