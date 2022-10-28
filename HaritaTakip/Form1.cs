using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaritaTakip
{
    public partial class Form1 : Form
    {
        
        String receivedText="";
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            comListesi();
           
        }

        private void comListesi()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (comboBox2.Text.Trim() != "")
            {
                if (comboBox1.Text.Trim() != "")
                {
                    serialPort1.BaudRate = Int32.Parse(comboBox2.Text);
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    MessageBox.Show("Bağlantı sağlandı!");
                }
                else
                {
                    MessageBox.Show("Lütfen bir port seçiniz!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir baud rate seçiniz!");
            }

            }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           // var rnd = new Random();

            receivedText = serialPort1.ReadLine(); //rnd.Next(20, 50).ToString()+"," + rnd.Next(10, 100).ToString();//           
                   
            textBox2.Text += receivedText + Environment.NewLine;
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
            textBox2.Refresh();
           if (textBox2.Lines.Count()>100)
                textBox2.Clear();
        }



        private void btn_Gonder_Click(object sender, EventArgs e)
        {
           // receivedText = "0.000000,0.000000";
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(textBox1.Text);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Önce bağlantı kurmalısınız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            MessageBox.Show("Bağlantı kesildi!");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
            labelDurum.Text = "sayfa yüklendi...";
            timer1.Enabled = true;
            timer1.Start();

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
           
            labelDurum.Text = "sayfa yükleniyor!";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comListesi();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance=260;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDurum.Text = "Bekliyor...";
                                   
            if (receivedText.Trim() != "" && receivedText.Trim() != "0.000000,0.000000" && receivedText.Trim() != "Hata baglantilari kontrol edin")
            {
                timer1.Enabled = false;
                timer1.Stop();
                webBrowser1.Navigate("https://maps.google.com?q=" + receivedText);
            }
        }
    }
}
