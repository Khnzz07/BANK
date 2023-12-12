using System;
public class Account
{
    public decimal _balance;
    public string _name;
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }
    public bool Deposit(decimal amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _balance += amountToAdd;
            return true;
        }
        return false;
        //_balance = _balance + amountToAdd;
    }
    public bool Withdraw(decimal amountToDeduct)
    {
        if (amountToDeduct > 0)
        {
            _balance = _balance - amountToDeduct;
            return true;
        }
        return false;
    }
    public string Name
    {
        get { return _name; }
    }
    public decimal Amount
    {
        get { return _balance; }
    }
    public void Print()
    {
        Console.WriteLine("This is " + _name + " and your balance is " + _balance);
    }
    public static implicit operator string(Account v)
    {
        throw new NotImplementedException();
    }
}
