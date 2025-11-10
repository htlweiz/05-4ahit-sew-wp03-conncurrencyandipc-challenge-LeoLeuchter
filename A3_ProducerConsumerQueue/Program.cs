using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        // TODO
        ConcurrentQueue<int> randomnums = new ConcurrentQueue<int>();

        Console.WriteLine("Producer und Consumer gestartet...\n");
        Producer[] pros = new Producer[5];
        List<Producer> producers = new List<Producer>();
        for (int i = 0; i < 5; i++)
        {
            pros[i] = new Producer(i, randomnums);
            producers.Add(pros[i]);
        }

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        while (true)
        {
            if (randomnums.Count == 50)
            {
                foreach (Producer p in producers)
                {
                    p.Stop();
                }
            }
        }
        // TODO

        // Alle Producer stoppen


        // Consumer stoppen


    }
}
