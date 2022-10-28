using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaritaTest1
{

    public partial class Form1 : Form
    {

        bool test = false;
        double toplamMesafe = 0;
        private string receivedText;
        List<PointLatLng> PointList = null;
        double eveUzaklik = 0;

        public Form1()
        {
            InitializeComponent();
            initializeHarita();
         
            comListesi();
        }

        private void comListesi()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double lon = rnd.NextDouble() * (33.49 - 33.46) + 33.46;
            double lat = rnd.NextDouble() * (38.76 - 38.73) + 38.73;


            receivedText = lat.ToString().Replace(",", ".") + "," + lon.ToString().Replace(",", ".") + ";1;5;3000.115;400.23;45.23";


        }


       
        private void initializeHarita()
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyDoc8e6doqe2C2byub17q9Q-NqPAJx64QA"; //rota oluşturma için kredi kartı bilgileri istiyor
            //https://developers.google.com/maps/documentation/javascript/directions  ayrıntılar. Bu sebeple rota çalışmıyor

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CacheLocation = @"cache";


            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;

            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;
            gMapControl1.ShowCenter = false;

            PointList = new List<PointLatLng>();

        }

        private void HaritaGuncelle(double lat, double lon,double zoom)
        {
            gMapControl1.Position = new PointLatLng(lat, lon);
            gMapControl1.Zoom = zoom;
            isaretEkle(lat, lon);
           
        }


        

        private void isaretEkle(double lat, double lon)
        {
            PointLatLng pnt = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(pnt, GMarkerGoogleType.green_small);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            PointList.Add(pnt);

            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            eveUzaklik = 0;
            List<PointLatLng> tempList = new List<PointLatLng>();

            if (PointList.Count() > 0)
            {
                tempList.Add(PointList.Last());
                tempList.Add(PointList.First());

                polygonCiz(tempList, Color.Red);

                label1.Text = "Eve uzaklık: \n" + Convert.ToString(eveUzaklik);

            }
            
            

        }



        private void button3_Click(object sender, EventArgs e)
        {



            polygonCiz(PointList, Color.Green);

           


        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            List<PointLatLng> tempList=null;
            PointLatLng tempP;
            PointLatLng pnt;

            toplamMesafe = 0;

            for (int i=0;i<PointList.Count-1;i++)
            
            {
                tempList = new List<PointLatLng>();
                pnt = PointList[i];
                tempP = PointList[i+1];
                                            
                tempList.Add(pnt);
                tempList.Add(tempP);
               
                polygonCiz(tempList, Color.Orange);

                
            }

            label1.Text = "Toplam rota uzunluğu: \n" + toplamMesafe.ToString();

            
        }

        private void polygonCiz(List<PointLatLng> plist, Color renk)
        {
            var polygon = new GMapPolygon(plist, "My Route")
            {
                Stroke = new Pen(renk, 2),
                Fill = new SolidBrush(Color.Transparent)
            };

            var polygons = new GMapOverlay("polygons");
            polygons.Polygons.Add(polygon);

            
            gMapControl1.Overlays.Add(polygons);

            gMapControl1.UpdatePolygonLocalPosition(polygon);

            toplamMesafe += polygon.Distance;

            eveUzaklik = polygon.Distance;
  
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void temizle()
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Refresh();
            PointList.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comListesi();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void btn_Gonder_Click(object sender, EventArgs e)
        {
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

        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            MessageBox.Show("Bağlantı kesildi!");
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // var rnd = new Random();

            receivedText = serialPort1.ReadLine(); //rnd.Next(20, 50).ToString()+"," + rnd.Next(10, 100).ToString();//           

            textBox2.Text += receivedText + Environment.NewLine;
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
            textBox2.Refresh();
            if (textBox2.Lines.Count() > 100)
                textBox2.Clear();
        }
        String[] gelenler;
        string lati_lonStr,kaynak,sat,alt,vel,yon,prevText = "";
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(receivedText) && receivedText != prevText && receivedText!="Err")
            {
                gelenler = receivedText.Split(';');
                if (gelenler.Length == 6)
                {
                    lati_lonStr = gelenler[0];
                    kaynak = gelenler[1];
                    sat = gelenler[2];
                    alt = gelenler[3];
                    vel = gelenler[4];
                    yon = gelenler[5];
                    labelSat.Text = sat;
                    labelAlt.Text = alt;
                    labelVel.Text = vel;
                    labelYon.Text = yon;
                    labelKaynak.Text = kaynak;
                }
                
                prevText = receivedText.Trim();

                if (!String.IsNullOrWhiteSpace(lati_lonStr) && lati_lonStr != "0.000000,0.000000")
                {
                    double lat = 0, lon = 0;

                    lati_lonStr = lati_lonStr.Trim();
                    string[] lat_lot = lati_lonStr.Split(',');
                    if (lat_lot.Length > 1)
                    {
                        lat = Convert.ToDouble(lat_lot[0].Replace(".", ","));
                        lon = Convert.ToDouble(lat_lot[1].Replace(".", ","));
                    }

                    HaritaGuncelle(lat, lon, 15);
                    

                    label1.Text = lati_lonStr;

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
         //   ResourceManager res = new ResourceManager(, this.GetType().Assembly);
            

            if (button9.Tag == "1")
            {
                button9.Tag = "0";
                button9.BackgroundImage = Properties.Resources.play;
                timer1.Enabled = false;
            }
            else
            {
                
                button9.Tag = "1";
                button9.BackgroundImage = Properties.Resources.pause;
                timer1.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HaritaGuncelle(37.926635, 41.943835,10);
            temizle();
        }
    }
}
