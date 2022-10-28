namespace ALGORITMA_2_UYGULAMALARI_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
        }
    }
}