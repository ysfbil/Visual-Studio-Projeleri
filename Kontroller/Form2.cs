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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

        int genislik;


        private void Form2_Load(object sender, EventArgs e)
        {
            genislik = panel1.Width;
            panel1.Width = genislik - 120;
            this.Text = genislik.ToString();

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Width = genislik + 120;

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Width = genislik - 120;

        }
    }
}
