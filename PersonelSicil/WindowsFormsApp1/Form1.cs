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
    public partial class Form1 : Form
    {
        string kullaniciAdi = "yusuf";
        string sifre = "123";
        Boolean hata = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hata = false;

            if (!txtbAd.Text.Equals(kullaniciAdi))
            {
                lblAdHata.Text = "Kullanıcı adını yanlış girdiniz.";
                lblAdHata.Visible = true;
                hata = true;
            }
            if (!txtbSifre.Text.Equals(sifre))
            {
                lblSifreHata.Text = "Şifrenizi yanlış girdiniz.";
                lblSifreHata.Visible = true;
                hata = true;
            }
            if (hata == false)
            {

                Form2 frm = new Form2();
                frm.gelenVeri = txtbAd.Text;
                frm.Show();
                this.Visible = false;
            }
        }

        private void txtbSifreTekrar_TextChanged(object sender, EventArgs e)
        {
            if (!txtbSifre.Text.Equals(txtbSifreTekrar.Text))
            {
                lblSifreTekrarHata.Text = "Şifreler eşleşmiyor.";
                lblSifreTekrarHata.Visible = true;
                hata = true;
            }
            else
            {
                 lblSifreTekrarHata.Visible = false;
            }
        }
    }
}
