using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cozumler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //OleDB engine kurmayı unutma
            //OleDB Engine 2016 https://www.microsoft.com/en-us/download/details.aspx?id=54920
            //OleDB Engine 2010 (Bunun x86'sı kurulabildi) https://www.microsoft.com/en-us/download/details.aspx?id=13255
            //Çalışmazsa Net Frame Work 4.0 ayarına geç
            //Çalışmazsa x86 olarak Debug dene
            /*
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
               
                textBox11.Text += rnd.Next().ToString() + "\r\n";
            }
            */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"deneme.txt";
            string[] isimler = System.IO.File.ReadAllLines(path);
            OleDbConnection dbCon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = VT.accdb;");
            dbCon.Open();
            string cmdText = "Insert Into PERSONEL(AD) Values (@isim)";
            OleDbCommand dbCom;

            foreach (string isim in isimler)
            {
                dbCom = new OleDbCommand(cmdText, dbCon);
                dbCom.Parameters.AddWithValue("@isim", isim);
                dbCom.ExecuteNonQuery();
               
            }

            MessageBox.Show("İsimler Eklendi");
            dbCon.Close();
            

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=VT.accdb;");
            dbcon.Open();

            string sql1 = "Select Kimlik from PERSONEL";
            string sql2 = "UPDATE PERSONEL SET TCNO=@TCNO WHERE Kimlik=@id";
            //var rnd = new Random();
            long rndTC = 11111111111;

            OleDbCommand com = new OleDbCommand(sql1, dbcon);

            OleDbDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                // rndTC = Convert.ToInt64(rnd.NextDouble()*10000000000);
                rndTC++;
                com = new OleDbCommand(sql2, dbcon);
                com.Parameters.AddWithValue("@TCNO", rndTC);
                com.Parameters.AddWithValue("@id", dr[0]);
                com.ExecuteNonQuery();


            }

            MessageBox.Show("TC Nolar Güncellendi");
            dbcon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=VT.accdb;");
            dbcon.Open();

            string sql = "Delete * From PERSONEL Where TCNO=@TCNO";
            OleDbCommand com = new OleDbCommand(sql, dbcon);
            com.Parameters.AddWithValue("@TCNO", textBox1.Text);

            com.ExecuteNonQuery();

            MessageBox.Show("Kayıt silindi");

            dbcon.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=VT.accdb;");
            dbcon.Open();

            string sql = "Insert Into PERSONEL (AD,SOYAD,TELEFON) Values (@AD,@SOYAD,@TELEFON)";
            OleDbCommand com = new OleDbCommand(sql, dbcon);

            com.Parameters.AddWithValue("@AD", textBox4.Text);
            com.Parameters.AddWithValue("@SOYAD", textBox5.Text);
            com.Parameters.AddWithValue("@TELEFON", textBox6.Text);

            com.ExecuteNonQuery();

            MessageBox.Show("Kayıt Eklendi");

            dbcon.Close();

        }

      

       

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=VT.accdb");
            dbcon.Open();
            string sql;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = dbcon;

            if (checkBox1.Checked)
                sql = "Select * From Personel";
            else
            {
                sql = "Select Kimlik,AD,SOYAD,TCNO,TELEFON From Personel Where AD=@AD;";                
                cmd.Parameters.AddWithValue("@AD", textBox7.Text);
            }

            cmd.CommandText = sql;
           
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["Kimlik"].ToString() + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3].ToString() + "\t"
                    + dr[4].ToString());

            }

            MessageBox.Show("Tamamlandı");

            dbcon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //HashTable genel değildir ve her türü kabul eder bu sebeple daha yavaş çalışır.
            //Dictionary geneldir (generic) ve tanımda tür belirtilerek kullanılır. Bu sebeple daha hızlıdır

            Hashtable tescil = new Hashtable();
            tescil.Add("plakaNo", textBox2.Text);
            tescil.Add("il", textBox3.Text);
            tescil.Add("sayi", 1000);


            foreach (DictionaryEntry kayit in tescil)
            {
                MessageBox.Show(kayit.Key + ":" + kayit.Value);

            }

            MessageBox.Show(tescil["il"].ToString());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            Random rnd = new Random();
            ArrayList lst = new ArrayList();
            char mychr;
            
            for (int i=0;i<1000;i++)
            {
                mychr = (char)rnd.Next('A', 'Z');
              //  mychr = Convert.ToChar(rnd.Next('A', 'Z'));
                lst.Add(mychr);
                textBox8.Text += mychr;
            }
         
            int sayi = 0;
            while (lst.IndexOf('A')!=-1)
            {
                lst.Remove('A');
                sayi++;
            }

            MessageBox.Show(String.Format("{0} adet A bulundu", sayi));

        }

        private void button8_Click(object sender, EventArgs e)
        {
           MessageBox.Show( ortalamaBul(textBox9.Lines).ToString());
        }

        private Double ortalamaBul(string[] sayilar)
        {
            Double toplam = 0;
            foreach (string sayi in sayilar)
            {
                toplam += Double.Parse(sayi);
            }

            return toplam/sayilar.Length;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear(); 

            foreach (string kelime in textBox10.Text.Split(' '))
            {
                if (kelime.EndsWith("a"))
                    listBox2.Items.Add(kelime);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int temp;
            int cift=0, tek=0;

           
               foreach (char c in textBox11.Text)
                {
                   temp=(int)c-48;
                    if (temp % 2 == 0)
                        cift++;
                    else
                        tek++;

                }

            if (tek == cift)
                MessageBox.Show("Dengeli Sayı");
            else
                MessageBox.Show("Dengeli Sayı Değil");
                
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Double sayi;

            for (int i=1;i<=250;i++)
            {
                sayi = Math.Sqrt(i);
                if (sayi % 1 == 0)
                    listBox3.Items.Add("Kök("+i.ToString()+")="+sayi);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i,sayi = int.Parse(textBox12.Text);
            bool asalMi = true;

            for (i=2;i<sayi;i++)
            {
                if (sayi % i == 0)
                {
                    asalMi = false;
                    break;
                }
            }

            if (asalMi)
                MessageBox.Show("Sayı Asal");
            else
                MessageBox.Show("Asal Değil Bölen:" + i.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            for (int i=0;i<255;i++)
            {
                listBox4.Items.Add(i.ToString() + "\t" + (char)i);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            Random rnd = new Random();
            int sayi;
            int[] sayilar=new int[10];

            for (int i=0;i<10;i++)
            {
                sayi =  rnd.Next();
                listBox5.Items.Add(sayi);
                sayilar[i] = sayi;
            }

            Array.Sort(sayilar);

            MessageBox.Show(sayilar[sayilar.Length-1].ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int s1, s2;
           s1 = DateTime.Now.Millisecond ;
           

            for (int i=1;i<1000000;i++)
            {

            }

           s2 = DateTime.Now.Millisecond;
           

           
            MessageBox.Show((s2 - s1).ToString()+" ms");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Çiftlikte 1042 tavşan , 2272 kuş var, tavşanlar yılda %3.8, kuşlar %1.2 çoğalıyor. Kaç yıl sonra tavşanlar daha fazla olur

            int yil = 0, tavsan = 1042, kus = 2272;
            
            while (tavsan<=kus)
            {
                tavsan += Convert.ToInt32( tavsan * 0.038);
                kus += Convert.ToInt32(kus * 0.012);
                yil++;
            }

            MessageBox.Show(yil.ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Double i = -1000,j = -1000,sonuc;
            listBox6.Items.Clear();
            listBox6.Items.Add("i\tj");

            for (int k=0;k<20000;k++)
            {
                for (int l=0;l<20000;l++)
                {
                    sonuc = 6 * i + 9 * j;
                    if (sonuc == 153)
                        listBox6.Items.Add(i.ToString() + "\t" + j.ToString());
                    j += 1;
                }
                i += 1;
                j = -1000;
            }

            MessageBox.Show("Tamamlandı");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int onlu=0,temp;
            string sayi = textBox13.Text;
           for (int i=0;i<sayi.Length;i++)
            {
                temp= (int)sayi[sayi.Length-i-1]-48;
                onlu += temp *Convert.ToInt32(Math.Pow(2, i));
            }
           
            MessageBox.Show(onlu.ToString());
        }
    }
}
