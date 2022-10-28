namespace KalitimOrnegi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Dikdortgen dikdortgen1 = new Dikdortgen();
            dikdortgen1.ad = "Dikdörtgen";
            dikdortgen1.genislik = 5;
            dikdortgen1.yukseklik = 10;
            dikdortgen1.renk = "Mavi";
            dikdortgen1.koseSayisi = 4;
            dikdortgen1.AlanHesapla();
            dikdortgen1.CevreHesapla();
            dikdortgen1.bilgileriYaz();

            Dikdortgen dikdortgen2 = new Dikdortgen();
            dikdortgen2.ad = "Kare";
            dikdortgen2.genislik = 25;
            dikdortgen2.yukseklik = 25;
            dikdortgen2.renk = "Kýrmýzý";
            dikdortgen2.koseSayisi = 4;
            listBox1.Items.Add(dikdortgen2.AlanHesapla());
            listBox1.Items.Add(dikdortgen2.CevreHesapla());
            listBox1.Items.Add(dikdortgen2.bilgileriYaz());
            listBox1.Items.Add("");

            Ucgen ucgen1 = new Ucgen();
            ucgen1.ad = "Üçgen";
            ucgen1.kenar1 = 15;
            ucgen1.kenar2 = 10;
            ucgen1.kenar3 = 20;
            ucgen1.renk = "Mavi";
            ucgen1.koseSayisi = 3;

            double ualan = ucgen1.AlanHesapla();
            if (Double.IsNaN(ualan))
                listBox1.Items.Add("Üçgen oluþmadý, deðerleri deðiþtirin");
            else
            {
                listBox1.Items.Add(ucgen1.AlanHesapla());
                listBox1.Items.Add(ucgen1.CevreHesapla());
                listBox1.Items.Add(ucgen1.bilgileriYaz());              
            }
            listBox1.Items.Add("");

            Daire daire1 = new Daire();
            daire1.ad = "Daire";
            daire1.yaricap = 5;
            daire1.renk = "Mavi";
            daire1.koseSayisi = 0;
            listBox1.Items.Add(daire1.AlanHesapla());
            listBox1.Items.Add(daire1.CevreHesapla());
            listBox1.Items.Add(daire1.bilgileriYaz());
            listBox1.Items.Add("");
        }


    }

    public class GeometrikSekiller
    {
        public string ad { get; set; }
        public double alan { get; set; }

        public double cevre { get; set; }
        public int koseSayisi { get; set; }
        public string renk { get; set; }

        private string cizgi;

        public string Cizgi
        {
            get
            {
                return cizgi;
            }
            set
            {
                cizgi = value;
            }
        }

        public string bilgileriYaz()
        {
            string sonuc;
            sonuc = String.Format("Bu þekil {0} adet köþesi olan {1} renkli bir {2} þeklidir.\n", koseSayisi, renk, ad);
            Console.WriteLine(sonuc);
            return sonuc;
        }

        public virtual double AlanHesapla() { return 0; }

        public virtual double CevreHesapla() { return 0; }
    }

    public class Dikdortgen : GeometrikSekiller
    {
        public double genislik { get; set; }
        public double yukseklik { get; set; }

        public override double AlanHesapla()
        {
            alan = genislik * yukseklik;
            Console.WriteLine(alan);
            return alan;
        }

        public override double CevreHesapla()
        {
            cevre = 2 * genislik + 2 * yukseklik;
            Console.WriteLine(cevre);
            return cevre;
        }
    }

    public class Ucgen : GeometrikSekiller
    {
        public double kenar1 { get; set; }
        public double kenar2 { get; set; }

        public double kenar3 { get; set; }


        public override double AlanHesapla()
        {
            double u = CevreHesapla() / 2;
            double alankare = u * (u - kenar1) * (u - kenar2) * (u - kenar3);
            alan = Math.Sqrt(alankare);

            if (alankare > 0)
            {
                Console.WriteLine(alan);
            }
            else
            {
                Console.WriteLine("Bu kenarlar üçgen oluþturmuyor");
            }

            return alan;
        }


        public override double CevreHesapla()
        {
            cevre = kenar1 + kenar2 + kenar3;
            Console.WriteLine(cevre);
            return cevre;
        }
    }

    public class Daire : GeometrikSekiller
    {
        public double yaricap { get; set; }

        public override double AlanHesapla()
        {
            alan = Math.PI * yaricap * yaricap;
            Console.WriteLine(alan);
            return alan;
        }

        public override double CevreHesapla()
        {
            cevre = 2 * Math.PI * yaricap;
            Console.WriteLine(cevre);
            return cevre;
        }
    }
}