using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaMusteriSimulasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
          
        }


        //100 ortalama müşteri var her müşteri için 1-10 dk arası işlem süresi, sonraki müşteri için 1-9 dk arası bekleme süresi
        //2 gişe var. Tüm durumlar için müşteriler rastgele sürelerde simüle edilecek. 
        /*
         * eğer müşterinin geliş saatin iki gişenin de bitiş saatinden küçükse bitiş saati küçük olan gişenin bitişine
         * kadar bekleyecek ve işlem saati bu saat olarak kaydedilecek.
         * */



        private void button1_Click(object sender, EventArgs e)

            
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            Random rastgele = new Random();
            int[] gelisSureleri=new int[100];
            int[] islemSureleri = new int[100];
            int toplamSure1=0, toplamSure2=0, ortalamaSure=0, aktifGise=1;
          
            DateTime giseBaslangic = new DateTime(2022, 03, 27, 8,0,0);
            DateTime giseBitis = new DateTime(2022, 03, 27, 8, 0, 0);
            DateTime oncekiBitis1 = new DateTime(2022, 03, 27, 8, 0, 0);
            DateTime oncekiBitis2 = new DateTime(2022, 03, 27, 8, 0, 0);
           
           
            for (int i = 0; i < 100; i++) //rastgele işlem süresi ve geliş süresi oluşturuyoruz
            {
                gelisSureleri[i] = rastgele.Next(1, 9);
                islemSureleri[i] = rastgele.Next(1, 10);
            }

                for (int i = 0; i < 100; i++)
            {

              
                 aktifGise = (i%2)==0?1:2; //gişeleri sırası ile geziyoruz
                              

                giseBaslangic = giseBaslangic.AddMinutes(gelisSureleri[i]); //müşteri işlem başlangıcını hesapladık

                
                
                if (aktifGise==1) //müşteri geldiğinde aktif gişe doluysa iki gişenin de bitiş saatine baksın ve kendi geliş saatinden büyük eşit olan gişeye gitsin
                {
                    if (giseBaslangic<oncekiBitis1)
                    {
                        if (oncekiBitis2<oncekiBitis1)
                        {
                            giseBaslangic = oncekiBitis2;
                            aktifGise = 2;
                        }
                        else
                        {
                            giseBaslangic = oncekiBitis1;
                            aktifGise = 1;
                        }
                    }
                }
                else
                {
                    if (giseBaslangic < oncekiBitis2)
                    {
                        if (oncekiBitis2 < oncekiBitis1)
                        {
                            giseBaslangic = oncekiBitis2;
                            aktifGise = 2;
                        }
                        else
                        {
                            giseBaslangic = oncekiBitis1;
                            aktifGise = 1;
                        }
                    }
                }

                giseBitis = giseBaslangic.AddMinutes(islemSureleri[i]); //işlem bitişini başlangıç ve işlem süresine göre hesaplıyoruz.

                if (giseBitis.Hour >= 17 && giseBitis.Minute > 0) break; //mesai bitimi

              
                if (aktifGise == 1) //ilgili listeye sonucu yazdırıyoruz
                {
                    listBox2.Items.Add((i + 1).ToString() + ". Müşteri\t İşlem Saati: " + giseBaslangic.ToString("HH:mm") + "\t İşlem Bitiş:" +
                         giseBitis.ToString("HH:mm") + "\t İşlem Süresi:" + islemSureleri[i]); ;
                    toplamSure1 += islemSureleri[i];
                    oncekiBitis1 = giseBitis; //kontrol amaçlı önceki bitişi kaydediyoruz.
                }
                else
                {
                    listBox1.Items.Add((i + 1).ToString() + ". Müşteri\t İşlem Saati: " + giseBaslangic.ToString("HH:mm") + "\t İşlem Bitiş:" +
                         giseBitis.ToString("HH:mm") + "\t İşlem Süresi:" + islemSureleri[i]);
                    toplamSure2 += islemSureleri[i];
                    oncekiBitis2 = giseBitis; //kontrol amaçlı önceki bitişi kaydediyoruz.
                }
                
                

               

            }

                //istatistikleri yazdırıyoruz.
            ortalamaSure = (toplamSure1 + toplamSure2) / (listBox1.Items.Count+listBox2.Items.Count);

            label1.Text = String.Format("1. Gişedeki işlem sayısı: {0}, 2. Gişedeki işlem sayısı: {1}," +
                " 1. Gişede toplam çalışma süresi: {2},  2. Gişede toplam çalışma süresi: {3}" +
                " Ortalama işlem zamanı: {4}",listBox2.Items.Count,listBox1.Items.Count,toplamSure1,toplamSure2,ortalamaSure);
        }
    }
}
