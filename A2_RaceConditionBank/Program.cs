using System;
using System.Threading;

namespace A2_RaceConditionBank;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 2: Race Condition – Bankkonto");
        Console.WriteLine("==========================================\n");

        // Bankkonto mit Startwert 1000 EUR erstellen
        BankAccount account = new BankAccount(1000);
        Console.WriteLine($"Startkontostand: {account.GetBalance()} EUR\n");

        List<Thread> lthreads = new List<Thread>();

        for (int count = 0; count < 10; count++)
        {
            Thread thread = new Thread(() => PerformBankOperations(account));
            lthreads.Add(thread);
            thread.Start();
        }

        foreach (Thread t in lthreads)
        {
            t.Join();
            Console.WriteLine("new Thread");
        }
    }
    
    private static void PerformBankOperations(BankAccount account)
    {
        BankAccount accountt = new BankAccount(1000);
        accountt.Deposit(100);
        Thread.Sleep(100);
        accountt.Withdraw(150);
        Thread.Sleep(100);
        account.GetBalance();
    }
}

