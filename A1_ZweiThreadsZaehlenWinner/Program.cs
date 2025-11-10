using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
   
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread t1 = new Thread(CountUpThreadA);
        Thread t2 = new Thread(CountDownThreadB);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        
    }
    
    private static void CountUpThreadA()
    {
        int count1 = 0;
        for (int count = 0; count < 100; count++)
        {
            count1 = count;
        }
    }
    
    private static void CountDownThreadB()
    {
        int count1 = 100;
        for (int count = 100; count > 0; count++)
        {
            count1 = count;
        }
    }
}
