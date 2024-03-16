// See https://aka.ms/new-console-template for more information
namespace ConsoleApp1;
using System.Diagnostics.CodeAnalysis;
using System;

public class Program
{

    static void Main(string[] args)
    {
// EX 1
bool CheckDivision(int n)
{
    if (n % 2 == 0 && n % 3 == 0 && n % 5 != 0)
    {
        return true;
    }

    return false;
}

int n;
Console.WriteLine("Citeste nr n: ");
n = Convert.ToInt32(Console.ReadLine());
while(n != 0)
{
    Console.WriteLine(CheckDivision(n));
    Console.WriteLine("Citeste nr n: ");
    n = Convert.ToInt32(Console.ReadLine());

}




//Ex 2
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


// string prop = Console.ReadLine();
// string[] cuvinte = prop.Split(" ");
//
// for(int i = 0; i < cuvinte.Length-1; i++)
// {
//     for (int j = i+1; j < cuvinte.Length; j++)
//     {
//         if (cuvinte[i].Length < cuvinte[j].Length)
//         {
//             string aux = cuvinte[i];
//             cuvinte[i] = cuvinte[j];
//             cuvinte[j] = aux;
//         }
//     }
// }
// for (int i = 0; i < cuvinte.Length; i++)
// {
//     Console.WriteLine(cuvinte[i]);
// }


// EX 5


        int Search(int st, int dr, List<int> v, int x)
        {
            if (st > dr)
            {
                return 0;
            }
            else
            {
                int m = (st + dr) / 2;
                if (v[m] == x)
                    return m;
                if (v[m] > x)
                    return Search(1, m - 1, v, x);
                if (v[m] < x)
                    return Search(m + 1, dr, v, x);
                return 0;
            }
        }

        void ReadFromConsole(out int n, List<int> v)
        {
            Console.WriteLine("Citeste n: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Citeste cele n numere: ");
                int m = Convert.ToInt32(Console.ReadLine());
                v.Add(m);
            }
        }

        void prob5()
        {
            int n, m;
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            // ReadFromConsole(out n, x);
            // ReadFromConsole(out m, y);
            n = 7;
            m = 8;
            x = [0, 1, 2, 5, 6, 9, 10, 14];
            y = [0, 8, 14, 9, 14, 16, 15, 4, 2];
            for (int i = 1; i <= m; i++)
                if (Search(1, n, x, y[i]) != 0)
                    Console.WriteLine("1");
                else
                    Console.WriteLine("0");

        }

// prob5();

// EX 6
// Problem6.Prob6();

// EX7
// Problem7.Prob7();


    }

}






