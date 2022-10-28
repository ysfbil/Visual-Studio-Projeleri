using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıUygulaması
{
    public partial class Form1 : Form
    {

        SQLiteConnection con;

        public Form1()
        {
            InitializeComponent();

            /*
            if (!File.Exists("test.db"))
                SQLiteConnection.CreateFile("test.db");
            else
                Console.WriteLine("Veri tabanı zaten var");
            */ //Aşağıdaki New=True ifadesi kullanıldığında buna gerek kalmıyor

            String cs = "Data Source=.\\test.db;Version=3;New=True;Compress=True;"; //Veritabani debug klasorunda olmalı
            con= new SQLiteConnection(cs);
            con.Open();

            TabloOlustur();

        }

        private void TabloOlustur()
        {
            String ct = "CREATE TABLE if not exists ogrenci (No INTEGER PRIMARY KEY AUTOINCREMENT, Ad NVARCHAR(20)," +
              " Soyad NVARCHAR(20), Bolum NVARCHAR(20),Sınıf INTEGER,Puan INTEGER);";

          //  SQLiteCommand cmd = new SQLiteCommand(ct, con);
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = ct;
            cmd.ExecuteNonQuery();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
           
            String ct = "INSERT INTO ogrenci (Ad,Soyad,Bolum,Sınıf,Puan) VALUES (@p1,@p2,@p3,@p4,@p5);"; 
            
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", textBox5.Text);

            cmd.CommandText =ct;
            int s=cmd.ExecuteNonQuery();
            MessageBox.Show(s + " Kayıt Eklendi");

            
            

            /*
            SQLiteConnection connection = new SQLiteConnection("Data source=.\\Veritabani.db;Version=3"); //Veritabani debug klasorunda olmalı

            DataTable dt = new DataTable();
            string sql = "Select * from Ogrenciler";
            SQLiteDataAdapter adtr = new SQLiteDataAdapter(sql, connection);
            adtr.Fill(dt);
            */

            //dt doğrudan datagrid nesnesinin datasource'u olarak atanabilir
            //Select Id, Cast(Maas as varchar) as Maas from Bilgiler //şeklinde bir sutun alınırken çevrim yapılabilir

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); listBox2.Items.Clear(); listBox3.Items.Clear(); listBox4.Items.Clear(); listBox5.Items.Clear(); listBox6.Items.Clear();
            string sql="Select * from ogrenci Where Soyad='"+textBox7.Text+"'";
            
            if (checkBox1.Checked)
                sql = "Select * from ogrenci";

            SQLiteDataReader dR;
            SQLiteCommand cmd = con.CreateCommand();
         
            cmd.CommandText = sql;
            dR=  cmd.ExecuteReader();
            
            while (dR.Read())
            {
                listBox1.Items.Add(dR[0]);
                listBox2.Items.Add(dR[1]);
                listBox3.Items.Add(dR[2]);
                listBox4.Items.Add(dR[3]);
                listBox5.Items.Add(dR[4]);
                listBox6.Items.Add(dR[5]);
            }

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sind = ((ListBox)sender).SelectedIndex;

            listBox1.SelectedIndex =sind;
            listBox2.SelectedIndex = sind;
            listBox3.SelectedIndex = sind;
            listBox4.SelectedIndex = sind;
            listBox5.SelectedIndex = sind;
            listBox6.SelectedIndex = sind;

            textBox6.Text = listBox1.Text;
            textBox1.Text = listBox2.Text;
            textBox2.Text = listBox3.Text;
            textBox3.Text = listBox4.Text;
            textBox4.Text = listBox5.Text;
            textBox5.Text = listBox6.Text;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE ogrenci SET Ad=@p1,Soyad=@p2,Bolum=@p3,Sınıf=@p4,Puan=@p5 Where No=@p6";
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", textBox5.Text);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);
            int s=cmd.ExecuteNonQuery();
            MessageBox.Show(s + " kayıt güncellendi");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox7.Text = "";
                checkBox1.Checked = true;
            }
        }

       
    }
}
