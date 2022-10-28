using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1_ListBoxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rst = new Random();
            temizle();
            
            for (int i=0;i<100;i++)
            {
                listBox1.Items.Add(rst.Next().ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection elms = new ListBox.ObjectCollection(listBox1);

            foreach (object elm in listBox1.Items)
            {
                
                if (elm.ToString().EndsWith("7"))
                {                    
                    listBox2.Items.Add(elm);                   
                } 
                else
                {
                    elms.Add(elm);
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(elms);

            

        }

        private void temizle()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object temp;
            int sayi = listBox1.Items.Count;

            for (int i=0;i<sayi;i++)
            {
                temp = listBox1.Items[i];

                if (temp.ToString().EndsWith("7"))
                {
                    listBox2.Items.Add(temp);
                    listBox1.Items.Remove(temp);
                    i--;
                    sayi--;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int c = 0;

            foreach (object itm in listBox1.Items)
            {
                if (itm.ToString().EndsWith("7"))
                {
                    c++;       
                }
            }

            MessageBox.Show(c.ToString() + " tane 7 bulundu");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ArrayList temp = new ArrayList();
            List<object> temp = new List<object>(); //bu da oluyor
            

            foreach (object item in listBox1.Items)
            {
                if (item.ToString().EndsWith("7"))
                {
                    listBox2.Items.Add(item);
                }
                else
                {
                    temp.Add(item);
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(temp.ToArray());
        }
    }

   
}
