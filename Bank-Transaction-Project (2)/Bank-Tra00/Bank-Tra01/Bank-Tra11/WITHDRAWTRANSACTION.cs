using System;
public class WithdrawTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;
    private bool _fail = false;
    public bool Executed
    {
        get
        {
            return _executed;
        }
    }
    public bool Success
    {
        get
        {
            return _success;
        }
    }
    public bool Reversed
    {
        get
        {
            return _reversed;
        }
    }
    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already been executed.");
        }
        _executed = true;
        _success = _account.Withdraw(_amount);
    }
    public void Rollback()
    {
        if (_executed == false)
        {
            throw new Exception("Transaction has not been executed.");
        }
        if (_reversed == true)
        {
            throw new Exception("Transaction has not been reversed.");
        }
        _reversed = true;
        _success = true;
        _success = _account.Deposit(_amount);
        // {
        // return _reversed;
        // }
        // if ( _executed == false && _reversed == true )
        // {
        // _fail = true;
        // }
    }
    public void Print()
    {
        if (_executed == true)
        {
            Console.WriteLine("The withdrawal is succesfull.");
            Console.WriteLine($"Account:" + _account.Name);
            Console.WriteLine($"Withdrawal Amount: {_amount}");
        }
        else
        {
            Console.WriteLine("The amount was reversed");
        }
    }
}
