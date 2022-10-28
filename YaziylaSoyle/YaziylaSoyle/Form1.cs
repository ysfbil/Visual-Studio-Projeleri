namespace YaziylaSoyle
{
    public partial class Form1 : Form
    {
        enum Birler { S�f�r, Bir, �ki, ��, D�rt, Be�, Alt�, Yedi, Sekiz, Dokuz }
        enum Onlar {S�f�r, On,Yirmi,Otuz,K�rk,Elli,Altm��,Yetmi�,Seksen,Doksan }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") textBox1.Text = "0";
            int sayi = Convert.ToInt32(textBox1.Text);
            int birler = sayi % 10;
            int onlar = (sayi/10)% 10;
            int yuzler = (sayi / 100) % 10;
            int binler = (sayi / 1000) % 10;
            int onbinler = (sayi / 10000) % 10;

            textBox2.Text = "";

              label1.Text = onbinler.ToString() + "-" + binler.ToString() + "-" + yuzler.ToString() + "-" +
                  onlar.ToString() + "-" + birler;

            if (sayi == 0) yaz(Birler.S�f�r.ToString());
            else
            {
                if (onbinler != 0)
                {
                    if (binler==0)
                    yaz(((Onlar)onbinler).ToString(), "Bin");
                    else
                    yaz(((Onlar)onbinler).ToString());
                }
                if (binler!=0)
                    {
                    if (binler == 1) yaz("Bin");
                    else
                        yaz(((Birler)binler).ToString(), "Bin");
                    }

                if (yuzler != 0)
                {
                    if (yuzler == 1) yaz("Y�z");
                    else
                        yaz(((Birler)yuzler).ToString(), "Y�z");
                }

                if (onlar != 0) yaz(((Onlar)onlar).ToString());

                if (birler != 0) yaz(((Birler)birler).ToString());
            }


         

        }

        private void yaz(string txt1, string txt2)
        {
            textBox2.Text += txt1+txt2;
        }

        private void yaz(string txt)
        {
            textBox2.Text += txt;
        }
    }
}