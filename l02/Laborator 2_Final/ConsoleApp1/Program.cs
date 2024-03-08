// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("Hello, World!");

// ex 1
Console.Write("Numarul este: ");
int num = Convert.ToInt32(Console.ReadLine());

// if-else
if (num % 3 == 0)
{
    Console.WriteLine("DA!");
}
else
{
    Console.WriteLine("NU!");
}

// ?:
Console.WriteLine((num % 3 == 0) ? "DA!" : "NU!");
*/


//Ex 2
using System.Diagnostics.CodeAnalysis;
/*
bool primeNumber(int N)
{
    for(int i = 2; i<=Math.Sqrt(N);i++)
    {
        if (N % i == 0)
            return false;
    }
    return true;
}

Console.WriteLine("Citeste nr N: ");
int N = Convert.ToInt32(Console.ReadLine());
int[] v = new int[N];
int sum = 0;

for (int i = 0; i < N; i++)
{
    Console.WriteLine("Citeste nr " + (i+1));
    v[i] = Convert.ToInt32(Console.ReadLine());
    if (primeNumber(v[i]))
       sum += v[i];
}

Console.WriteLine("Suma este: " + sum);
*/

//ex 3
/*
int n, copyn, palind = 0;
n = int.Parse(Console.ReadLine());
copyn = n;
while(n > 0)
{
    palind = palind * 10 + n % 10;
    n = n / 10;
}

if (palind == copyn)
    Console.WriteLine("Este palindrom");
else
    Console.WriteLine("Nu este palindrom");
*/

//ex 4

/*
string prop = Console.ReadLine();
string[] cuvinte = prop.Split(" ");

for(int i = 0; i < cuvinte.Length-1; i++)
{
    for (int j = i+1; j < cuvinte.Length; j++)
    {
        if (cuvinte[i].Length < cuvinte[j].Length)
        {
            string aux = cuvinte[i];
            cuvinte[i] = cuvinte[j];
            cuvinte[j] = aux;
        }
    }
}
for (int i = 0; i < cuvinte.Length; i++)
{
    Console.WriteLine(cuvinte[i]);
}*/

// ex 5 & 6

Console.WriteLine("Dreptunghi");
Dreptunghi d = new(10, 5);
Console.WriteLine(d.calculeazaPerimetru());
Console.WriteLine(d.calculeazaArie());

Console.WriteLine("Patrat");
Patrat p = new(10);
Console.WriteLine(p.calculeazaPerimetru());
Console.WriteLine(p.calculeazaArie());

public class Dreptunghi
{
    private int lungime { get; set; }
    private int latime { get; set; }

    public Dreptunghi(int lungime, int latime)
    {
        this.lungime = lungime;
        this.latime = latime;
    }

    public virtual int calculeazaPerimetru()
    {
        return 2 * (lungime + latime);
    }

    public virtual int calculeazaArie()
    {
        return lungime * latime;
    }
}

public class Patrat : Dreptunghi
{

    public Patrat(int latura) : base(latura, latura)
    { }

}
