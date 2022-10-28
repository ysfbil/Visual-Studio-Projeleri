using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Koleksiyonlar
{
    public partial class Form1 : Form
    {

        ArrayList elemanlar;
        Queue kuyruk = new Queue();
        Stack kirtas = new Stack();
        Hashtable cirpi = new Hashtable();
        SortedList sliste = new SortedList();



        public Form1()
        {
            InitializeComponent();

            elemanlar = new ArrayList();
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {

                elemanlar.Add(rnd.Next());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] dizi = new int[10];
            dizi[0] = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            listBox1.Items.Clear();

            foreach (int sayi in elemanlar)
            {
                listBox1.Items.Add(sayi);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            elemanlar.Remove(listBox1.Items[listBox1.SelectedIndex]);
            
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            elemanlar.Insert(listBox1.SelectedIndex, int.Parse(textBox1.Text));
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            elemanlar.RemoveAt(5);
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(elemanlar.Count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            elemanlar.Add(int.Parse(textBox1.Text));
            
            listele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            for (int i = 1; i < 11; i++)
                kuyruk.Enqueue(i);

            label1.Text = kuyruk.Count.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kuyruk.Dequeue().ToString());

            label1.Text = kuyruk.Count.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kuyruk.Peek().ToString());

            label1.Text = kuyruk.Count.ToString();
        }

     
        private void button12_Click(object sender, EventArgs e)
        {
            kuyruk.Clear();

            label1.Text = kuyruk.Count.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            kirtas.Push(textBox2.Text);
            label3.Text = kirtas.Count.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kirtas.Pop().ToString());
            label3.Text = kirtas.Count.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kirtas.Peek().ToString());
            label3.Text = kirtas.Count.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            foreach (string eleman in kirtas)
                listBox2.Items.Add(eleman);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cirpi[textBox3.Text] = textBox4.Text; //bunda eleman varsa güncelliyor, yoksa ekliyor.
                                                  //cirpi.Add(textBox3.Text, textBox4.Text); //bunda eleman varsa hata veriyor.
            MessageBox.Show(cirpi[textBox3.Text].ToString());

        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach (DictionaryEntry eleman in cirpi)
            {
                string anahtar = (string)eleman.Key;
                string il = (string)eleman.Value;
                listBox3.Items.Add(anahtar);
                listBox4.Items.Add(il);

            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            //   sliste[textBox6.Text] = textBox5.Text;
            sliste.Add(textBox6.Text, textBox5.Text); //sıralı ekler
            MessageBox.Show(sliste[textBox6.Text].ToString());
           

        }

        private void button18_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            listBox5.Items.Clear();

            foreach (DictionaryEntry eleman in sliste)
            {
                string kisi = (string)eleman.Key;
                string yas = (string)eleman.Value;
                listBox6.Items.Add(kisi);
                listBox5.Items.Add(yas);
                
            }

        }
    }
}
