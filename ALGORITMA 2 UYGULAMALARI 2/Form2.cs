using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGORITMA_2_UYGULAMALARI_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(UzunSay);
            th1.Start();
        }

        private void UzunSay()
        {
            for (int i = 0; i < 2000000000; i++)
            {

            }

            MessageBox.Show("İşlem Bitti");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İkinci işlem");
        }

        public void sayac1()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(1000);
                label1.Text = i.ToString();
            }
        }

        public void sayac2()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(1000);
                label2.Text = i.ToString();
                if (i > 10)
                    Thread.Sleep(1000);
            }
        }

        Thread kanal1;
        Thread kanal2;


        private void button3_Click(object sender, EventArgs e)
        {
            kanal1 = new Thread(new ThreadStart(sayac1));
            kanal2 = new Thread(new ThreadStart(sayac2));
            CheckForIllegalCrossThreadCalls = false;
            kanal1.Start();
            kanal2.Start();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kanal1.Suspend();
            kanal2.Suspend();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            kanal1.Resume();
            kanal2.Resume();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            kanal1.Abort();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            CheckForIllegalCrossThreadCalls = false;
            Parallel.For(0, 20, i =>
            {
                Parallel.For(0, 10, j => listBox1.Items.Add(i.ToString() + "-" + j.ToString()));

            });

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            CheckForIllegalCrossThreadCalls = false;
            string[] ad = { "Ali", "Ahmet", "Müzeyyen", "Nihal", "Serdar" };
            Parallel.ForEach(ad, i =>
            {
                listBox2.Items.Add(i);
            }

                );

        }

        private void button9_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Parallel.Invoke(
                    () => DoSomeTask(1,listBox3),
                    () => DoSomeTask(2, listBox3),
                    () => DoSomeTask(3, listBox3),
                    () => DoSomeTask(4, listBox3)
                   
                );

        }

        static void DoSomeTask(int number,ListBox lb)
        {
            lb.Items.Add($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            //Sleep for 5000 milliseconds
            Thread.Sleep(1000);
            lb.Items.Add($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Parallel.Invoke
                (
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Thread.Sleep(50);
                        listBox3.Items.Add(Thread.CurrentThread.ManagedThreadId + ":i:" + i.ToString());
                    }
                },
                () =>
                {
                    for (int k = 1; k <= 10; k++)
                    {
                        Thread.Sleep(50);
                        listBox3.Items.Add(Thread.CurrentThread.ManagedThreadId + ":k:" + k.ToString());
                        Thread.Sleep(20);
                    }
                }
                );


        }
    }
}
