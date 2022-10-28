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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        struct ogrenci
        {
            public string ad;
            public string soyad;
            public int yas;
            public string sinif;

            public struct Veli
            {
             public string veliadsoyad;
             public string velitelefon;
             }

            public void yaz(ListBox liste)
            {
                liste.Items.Add(this.ad);
                liste.Items.Add(soyad);
                liste.Items.Add(yas);
                liste.Items.Add(sinif);

            }

        }





        ogrenci ogr = new ogrenci();
        ogrenci.Veli vl = new ogrenci.Veli();

        enum gunler
        {
            Ptesi,
            Salı,
            Çarşamba,
            Perşembe,
            Cuma,
            Ctesi,
            Pazar
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ogr.ad = "ALİ";
            ogr.soyad = "CAN";
            ogr.yas = 22;
            ogr.sinif = "2-B";

            vl.veliadsoyad = "CAN";
            vl.velitelefon = "05059990998";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogr.yaz(listBox1);
            listBox1.Items.Add(vl.veliadsoyad);
            listBox1.Items.Add(vl.velitelefon);
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                listBox2.Items.Add((gunler)i);
            }

        }

        private class ogrenciler
        {
            ~ogrenciler() //destructor metod. İş bitince çalışır
            {
                Console.WriteLine("Yıkıcı metod ogrenciler sınıfı için çalıştı");
            }

            public ogrenciler()
            {
                ogrenciNo = 0;
                Ad = "NoName";
                Soyad = "NoSirName";
                Bolum = "Issiz";
                sinif = 0;
                p_DogumYili = 0;
            }

            private string ozelAlan="Ben Private Alan"; //bu alana sınıf dışından erişilemez çünkü private
            protected string korunmusAlan="Ben Protected Alan"; //bu alana sınıf dışından erişilemez çünkü protected
            internal string icerden = "Ben internal alan";
            public ulong ogrenciNo;
            public string Ad;
            public string Soyad;
            public string Bolum;
            public byte sinif;
            private int p_DogumYili;

            public int yas { set; get; }
            public int DogumYili { get { return p_DogumYili % 100; } set { p_DogumYili = value; } }

            public void bilgileriGetir(ListBox liste)
            {
                liste.Items.Add(ogrenciNo);
                liste.Items.Add(Ad);
                liste.Items.Add(Soyad);
                liste.Items.Add(Bolum);
                liste.Items.Add(sinif);
                liste.Items.Add(DogumYili);
            }

        }

        private class ogrenciCocugu : ogrenciler
        {
            public void bilgiVer(ListBox liste)
            {
                liste.Items.Add(korunmusAlan); //bu çalışır çünkü protected
              //  liste.Items.Add(ozelAlan); //bu çalışmaz çünkü alan private
            }
        }

        ogrenciler ogr1 = new ogrenciler();

        private void button4_Click(object sender, EventArgs e)
        {
            ogr1.ogrenciNo = 12548;
            ogr1.Ad = "Ahmet";
            ogr1.Soyad = "CAN";
            ogr1.Bolum = "BilMuh";
            ogr1.sinif = 1;
            ogr1.yas = 10;
            ogr1.DogumYili = 2002;
            

            ogrenciCocugu oc1 = new ogrenciCocugu();
            oc1.bilgiVer(listBox3);
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ogr1.bilgileriGetir(listBox3);
            listBox3.Items.Add(ogr1.icerden); //icerden internal olduğu için ve aynı disk konumunda olduğu için erişilebiliyor

            ogrenciler ogr2 = new ogrenciler();
            ogr2.bilgileriGetir(listBox3);

            GC.Collect(); //garbage collector çalıştırılarak gereksiz nesneler hafızadan temizleniyor
            
        }

        class arac
        {
            public arac()
            {
                MessageBox.Show("Araç yapıcısı çalıştı");
                esayisi = 2.72; //readonly olduğundan constructor da değeri değiştilebilir                
               // pi = 3; //const olduğundan değeri en başta verilir sonra değişmez
               
            }

            public const double pi = 3.14;
            public readonly double esayisi=0;
            public static int statikSayi;
            protected  double boy = 5;
            protected double agirlik = 1.5;
            protected string renk = "sarı";

            public static void say()
            {
                statikSayi++;
                MessageBox.Show(statikSayi.ToString());
                
            }

            public string goster()
            {
                return String.Format("Boyu {0} metre, ağırlığı {1} ton ve rengi {2}'dır", boy, agirlik, renk);
            }

        }

        class model1:arac
        {
            public model1()
            {
                tur = "Sedan";
                silindir_sayisi = 4;
                supab_sayisi = 8;
                tork = 150;
                guc = 300;
            }

            public string tur;
            public int silindir_sayisi;
            public int supab_sayisi;
            public int tork;
            public int guc;

            public string ozellikler()
            {
                return String.Format("TÜr={0},Silindir Sayısı={1}, Süpab sayısı={2}, Tork={3}, Güç={4}",
                    tur, silindir_sayisi, supab_sayisi, tork, guc);
            }
        }

        class model2:arac
        {
            public double model2_boy
            {
                get { return boy; }
                set { boy = value; }
            }

            public double model2_agirlik
            {
                get { return agirlik; }
                set { agirlik = value; }
            }

            public string model2_renk
            {
                get { return renk; }
                set { renk = value; }
            }

            public string tur="Hatchback";
            public int silindir_sayisi=8;
            public int supab_sayisi=16;
            public int tork=300;
            public int guc=210;

            public string ozellikler()
            {
                return String.Format("Tür={0},Silindir Sayısı={1}, Süpab sayısı={2}, Tork={3}," +
                    " Güç={4}, Boy={5}, Ağırlık={6}, Renk={7}",
                    tur, silindir_sayisi, supab_sayisi, tork, guc,model2_boy,model2_agirlik,model2_renk);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            arac arac1 = new arac();
            textBox1.Text = arac1.goster();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            model2 md2 = new model2();
            textBox1.Text= md2.ozellikler();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            model1 md1 = new model1();
            textBox1.Text = md1.ozellikler();
        }

        int[] degerDegistir(int a,int b)
        {
            int tmp = b;
            b = a;
            a = tmp;

            return new int[] { a, b };
        }

        int[] degerDegistir2(ref int a, ref int b)
        {
            int tmp = b;
            b = a;
            a = tmp;

            return new int[] { a, b };
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = 4, b = 5;
            MessageBox.Show(String.Format("Önce a={0}, b={1}", a, b));
            degerDegistir(a, b);
            MessageBox.Show(String.Format("Sonra a={0}, b={1} (Yer değişmedi)",a,b));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = 4, b = 5;
            MessageBox.Show(String.Format("Önce a={0}, b={1}", a, b));
            degerDegistir2(ref a, ref b);
            MessageBox.Show(String.Format("Sonra a={0}, b={1} (Yer değiştis)", a, b));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            arac.statikSayi = 10;
            MessageBox.Show("Alt sınıfta da statik değer aynen değişti: "+model1.statikSayi.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //statik nesneler bir sınıf ve ondan türetilenlerden aynı hafıza adresini işaret eder.
            arac.say();
            model1.say();
            model2.say();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            arac a1 = new arac();
            //  a1.esayisi = 10; //readonly olduğundan artık değiştirlemez
            MessageBox.Show(a1.esayisi.ToString()); //readonly okunabiir
           // MessageBox.Show(a1.pi.ToString()); // const public olduğu halde buradan erişilemiyor
            
        }
    }
}
