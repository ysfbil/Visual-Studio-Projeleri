using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string baglanti = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source ="+ Application.StartupPath + "/AJANDA.accdb";
            OleDbConnection con = new OleDbConnection(baglanti);
            con.Open();

            string sqlifade="insert into KISILER(AD,SOYAD,TELEFON,ADRES,DOGUMTARIHI) values(@T1,@T2,@T3,@T4,@T5)";
            OleDbCommand komut = new OleDbCommand(sqlifade,con);

            komut.Parameters.AddWithValue("@T1", textBox1.Text);
            komut.Parameters.AddWithValue("@T2", textBox2.Text);
            komut.Parameters.AddWithValue("@T3", textBox3.Text);
            komut.Parameters.AddWithValue("@T4", textBox5.Text);
            komut.Parameters.AddWithValue("@T5", textBox4.Text);
            
            int sonuc = komut.ExecuteNonQuery();

            MessageBox.Show("Kayıt Eklendi");

            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            listBox2.Items.Clear(); 
            listBox3.Items.Clear(); 
            listBox4.Items.Clear(); 
            listBox5.Items.Clear(); 
            listBox6.Items.Clear();
            string baglanti = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + "/AJANDA.accdb";
            OleDbConnection con = new OleDbConnection(baglanti);
            con.Open();

            string sqlifade;

            if (checkBox1.Checked)
            {
            sqlifade= "select * from KISILER";
            }
            else
            {
                sqlifade = "select * from KISILER where AD='" +textBox6.Text+  "'";
            }

            OleDbCommand komut = new OleDbCommand(sqlifade, con);

            OleDbDataReader oku;
            oku = komut.ExecuteReader();

            while (oku.Read())
            {
                listBox1.Items.Add(oku[0].ToString());
                listBox2.Items.Add(oku["AD"].ToString());
                listBox3.Items.Add(oku["SOYAD"].ToString());
                listBox4.Items.Add(oku[3].ToString());
                listBox5.Items.Add(oku[4].ToString());
                listBox6.Items.Add(oku[5].ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sira = listBox1.SelectedIndex;
            listBox2.SelectedIndex = sira;
            listBox3.SelectedIndex = sira;
            listBox4.SelectedIndex = sira;
            listBox5.SelectedIndex = sira;
            listBox6.SelectedIndex = sira;

            textBox7.Text = listBox1.Text;
            textBox1.Text = listBox2.Text;
            textBox2.Text = listBox3.Text;
            textBox3.Text = listBox4.Text;
            textBox4.Text = listBox6.Text;
            textBox5.Text = listBox5.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string baglanti = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + "/AJANDA.accdb";
            OleDbConnection con = new OleDbConnection(baglanti);
            con.Open();


            string sqlifade = "UPDATE KISILER ";
            sqlifade = sqlifade + "Set AD=@T1, SOYAD=@T2,TELEFON=@T3, ADRES=@T4, DOGUMTARIHI=@T5 ";
            sqlifade = sqlifade + " where SIRANO=@T6";
            
           
            OleDbCommand komut = new OleDbCommand(sqlifade, con);

            komut.Parameters.AddWithValue("@T1", textBox1.Text);
            komut.Parameters.AddWithValue("@T2", textBox2.Text);
            komut.Parameters.AddWithValue("@T3", textBox3.Text);
            komut.Parameters.AddWithValue("@T4", textBox5.Text);
            komut.Parameters.AddWithValue("@T5", textBox4.Text);
            komut.Parameters.AddWithValue("@T6", textBox7.Text);
            int sonuc = komut.ExecuteNonQuery();
            
            MessageBox.Show("Kayıt Değiştirildi");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=AJANDA.accdb;");
            con.Open();

            string sql = "Delete From KISILER where SIRANO=@SIRANO";
            var com = new OleDbCommand(sql, con);

            com.Parameters.AddWithValue("@SIRANO", textBox7.Text);
            com.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Silme başarılı");
        }
    }
}
