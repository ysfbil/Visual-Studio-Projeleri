Console.WriteLine("Adınızı giriniz:");
string gelen = Console.ReadLine();
if (gelen != null)
    Console.WriteLine("Merhaba {0}", gelen);

int[] oyuncular = new int[25];
int[] cikanlar = new int[25];
int adet = 0;

Random uretec = new Random();
for (int i = 0; i < 25; i++)
{
    oyuncular[i] = 0;
}

while (adet < 24)
{
    int cikan = uretec.Next(1, 26); // 26 yani üst sınır dahil değil
    if (oyuncular[cikan - 1] == 0)
    {
        adet++;
        oyuncular[cikan - 1] = 1;
        cikanlar[adet - 1] = cikan;

    }

}

Console.WriteLine("Sırayla Oyundan Çıkanlar");
Console.WriteLine("--------------------------");
for (int i = 0; i < 24; i++)
{
    Console.WriteLine("{0} - {1}. Oyuncu", (i + 1), cikanlar[i].ToString());
}

Console.WriteLine();
Console.WriteLine("Oyunu Kazanan Oyuncu");
Console.WriteLine("----------------------");

for (int i = 0; i < 25; i++)
{
    if (oyuncular[i] == 0)
    {
        Console.WriteLine("{0}. Oyuncu Kazandı", i + 1);
    }
}
Console.ReadLine();