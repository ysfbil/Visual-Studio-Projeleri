using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGORITMA_2_UYGULAMALARI_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string path = @"dosyam.txt";
        string path2 = @"dosyam.dat";

        private void button1_Click(object sender, EventArgs e)
        {
            
            string ilksatir = string.Format("{0,20:G}", "Bu ilk satırdır.");
            string ikincisatir = string.Format("{0,20:G}", "Bu da ikinci satırdır.");

            using (StreamWriter swr = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-1")))
            {
                swr.WriteLine(ilksatir);
                swr.WriteLine(ikincisatir);
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("iso-8859-1")))
                {
                    string sRead = String.Empty;
                    while ((sRead = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(sRead);
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point p = new Point();
            FileStream fs = new FileStream(path2, FileMode.Create);
            BinaryFormatter f = new BinaryFormatter();
            p.X = 1;
            p.Y = 2;
            f.Serialize(fs, p);
            fs.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point p = new Point();
            FileStream fs = new FileStream(path2, FileMode.Open);
            BinaryFormatter f = new BinaryFormatter();
            p = (Point)f.Deserialize(fs);
            MessageBox.Show(p.X.ToString() + "," + p.Y.ToString());
            fs.Close();
        }
    }
}
