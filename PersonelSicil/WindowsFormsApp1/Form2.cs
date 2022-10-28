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
        public string gelenVeri = "";
        DataTable table = new DataTable();
      

        public Form2()
        {
            InitializeComponent();
            Random rnd = new Random();
            textBox1.Text = rnd.Next(101, 1001).ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblGelenVeri.Text = gelenVeri;
            comboBox1.Items.Add("Muhasebe");
            comboBox1.Items.Add("Satış");
            comboBox1.Items.Add("İnsan Kaynakları");
            table.Columns.Add("Sicil No");
            table.Columns.Add("Ad");
            table.Columns.Add("Soyad");
            table.Columns.Add("Departman");
            dataGridView1.DataSource = table;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;

            Boolean hata = false;
            if (textBox1.Text.Equals("")) {
                hata = true;
            }
            if (textBox2.Text.Equals("")) {
                hata = true;
            }
            if (textBox3.Text.Equals("")) {
                hata = true;
            }
            if (comboBox1.Text.Equals("")) {
                hata = true;
            }
            if (hata == true)
            {
                lblHata.Visible = true;
            }
            else
            {
                table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
                dataGridView1.DataSource = table;
                Random rnd = new Random();
                textBox1.Text = rnd.Next(101, 1001).ToString();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                dataGridView1.Rows.Remove(row);
            }
            else
            {
                MessageBox.Show("Silmek istediğiniz veriyi seçiniz.");
            }
        }

        
    }
}
