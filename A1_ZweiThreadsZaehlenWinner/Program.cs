using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
    static  int countA = 0;
    static int countB = 100;
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread t1 = new Thread(() => CountUpThreadA());
        Thread t2 = new Thread(() => CountDownThreadB());

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        
    }

    private static void CountUpThreadA()
    {
        for (int count = 0; count <= 100; count++)
        {
            countA = count;
            Thread.Sleep(100);
            if (countA == countB)
            {
                Console.WriteLine("Same number");
                break;
            }
        }
    }
    
    private static void CountDownThreadB()
    {
        for (int count = 100; count >= 0; count--)
        {
            countB = count;
            Thread.Sleep(100);
            if (countB == countA)
            {
                Console.WriteLine("Same number");
                break;
            }
        }
    }
}
