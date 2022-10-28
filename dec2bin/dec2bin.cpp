

#include <iostream>
#include <stdio.h>
using namespace std;

void print_binary(unsigned int number)
{
    if (number >> 1) {
        print_binary(number >> 1);
    }
    putc((number & 1) ? '1' : '0', stdout);
}

int main()
{
    cout << "Bir sayi giriniz: ";
    int sayi;
    cin >> sayi;
    printf("%d", sayi);
    printf(" sayisinin ikili karsiligi: ");
    print_binary(sayi);
    printf("\n");
    printf("Sayinin 1e tumleyen ile negatifi:  ");
    print_binary(~sayi);
    printf("\n onlu karsiligi: %d", ~sayi);
    printf("\n");
    printf("Sayinin 2e tumleyen ile negatifi:  ");
    print_binary(~sayi + 1);
    printf("\n onlu karsiligi: %d", ~sayi + 1);


    return 0;
}
