using System;
using System.Threading;

namespace A2_RaceConditionBank;
public class BankAccount
{
    static object lockobject = new object();
    private int balance;


    public BankAccount(int initial)
    {
        balance = initial;
    }

    public void Deposit(int amount)
    {
        lock (lockobject)
        {
            balance = +amount;
        }
    }

    public void Withdraw(int amount)
    {
        lock (lockobject)
        {
            balance = -amount;
        }
    }

    public int GetBalance()
    {
        lock (lockobject)
        {
            return balance;
        }
    }
}
