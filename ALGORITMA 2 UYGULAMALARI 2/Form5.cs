using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGORITMA_2_UYGULAMALARI_2
{
    delegate void OlayYoneticisi();

    

    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            label1.Text = "";
        }

     


        private void button1_Click(object sender, EventArgs e)
        {
            int sayi=0;

            try
            {
                sayi = 100 / sayi;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata var kardeş \n\rHata:"+ex.Message);
            }
            finally
            {
                MessageBox.Show("Finally bloğu");
            }
        }

        public delegate void Temsilci(Label label1);
        

        public static void Metot1(Label lbl)
        {
            lbl.Text += "\nMetot 1, Delegateler fonksiyonun hafızadaki adresini tutan değişkenlerdir";
        }
        public static void Metot2(Label lbl)
        {
            lbl.Text += "\nMetot 2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Temsilci t = new Temsilci(Metot1);
            
            t(label1);
            t = new Temsilci(Metot2);
            t(label1);

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Temsilci t = new Temsilci(Metot1);
            //delegate fonksiyon ekledik
            t += new Temsilci(Metot2);
            t(label1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Temsilci t = new Temsilci(Metot1);
            //delegate fonksiyon çıkardık
            t -= new Temsilci(Metot2);
            t(label1);
        }

        public static void Olay()
        {
            MessageBox.Show("Olaylar, temsilcilerin özel bir formudur." +
                " Olaylar ile yapılan işlemlerin tamamı temsilciler ile de yapılabilir.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sinif nesne = new Sinif();
            nesne.OlayAdi += new OlayYoneticisi(Olay);
            nesne.OlayiBaslat();

        }
    }

    class Sinif
    {
        public event OlayYoneticisi OlayAdi;

        public void OlayiBaslat()
        {
            if (OlayAdi != null)
            {
                OlayAdi();
            }
        }
    }

}
