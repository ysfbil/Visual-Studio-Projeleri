using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontroller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.Load(openFileDialog1.FileName);
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void merhabaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selamun aleyküm");
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
          //  toolStripButton1.Image = imageList1.Images[0];
            toolStrip1.ImageList = imageList1;

            for (int i = 0; i < 5; i++)
                toolStrip1.Items[i].ImageIndex = i;

            toolTip1.SetToolTip(button2, "Form 3'ü açar");
            toolTip1.SetToolTip(button3, "İşlem yapar");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "yusuf")
                errorProvider1.SetError(textBox1, "Yanlış isim");
            else
                errorProvider1.SetError(textBox1, "");
           
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "1234")
                errorProvider1.SetError(textBox2, "Hatalı Şifre");
            else
                errorProvider1.SetError(textBox2, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = errorProvider1.GetError(textBox1)+"\r\n";
            label1.Text+= errorProvider1.GetError(textBox2);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToString());
            monthCalendar1.SetDate(dateTimePicker1.Value);
        }
    }
}
