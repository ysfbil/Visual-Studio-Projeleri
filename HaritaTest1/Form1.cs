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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaritaTest1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            initializeHarita();
           HaritaGuncelle(37.926635, 41.943835,10);
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double lat = rnd.NextDouble() * (42 - 36) + 36;
            double lon = rnd.NextDouble() * (45 - 26) + 26;
          
           HaritaGuncelle(lat,lon,7.5);


        }


        List<PointLatLng> PointList = null;
        private void initializeHarita()
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyDoc8e6doqe2C2byub17q9Q-NqPAJx64QA"; //para istiyo
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
            label1.Text = "";
        }


        

        private void isaretEkle(double lat, double lon)
        {
            PointLatLng pnt = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(pnt, GMarkerGoogleType.blue_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            PointList.Add(pnt);

            
        }

        double eveUzaklik=0;
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
            
            /*
             // Kredi kartı bilgileri istiyor. Bu şekilde oluşturulan api code en başta kullanmak gererkiyor
            // aksi halde çalışmıyor
            // https://developers.google.com/maps/documentation/javascript/directions  ayrıntılar.

            // api anahtarı kontrol için aşağıdaki link
            // https://maps.googleapis.com/maps/api/directions/json?origin=Disneyland&destination=Universal+Studios+Hollywood&key={api anahtarı}

            PointLatLng homeLoc = new PointLatLng(37.926635, 41.943835);


            var route = GoogleMapProvider.Instance.GetRoute(gMapControl1.Position, homeLoc,false, false, 14);
            var r = new GMapRoute(route.Points, "My Route")
            {
                Stroke = new Pen(Color.Red, 5)
            };

            var routes = new GMapOverlay("routes");
            routes.Routes.Add(r);
            gMapControl1.Overlays.Add(routes);

            label1.Text = route.Distance + " km";

            */

        }



        private void button3_Click(object sender, EventArgs e)
        {



            polygonCiz(PointList, Color.Green);

           


        }

        double toplamMesafe=0;

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
              gMapControl1.Overlays.Clear();
              gMapControl1.Refresh();
              PointList.Clear();
        }
    }
}
