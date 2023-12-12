using System;
public class TransferTransaction
{
    private Account _toAccount;
    private Account _fromAccount;
    private decimal _amount;
    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;
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
    public TransferTransaction(Account FromAccount, Account toAccount, decimal amount)
    {
        _fromAccount = FromAccount;
        _toAccount = toAccount;
        _amount = amount;
        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        _theDeposit = new DepositTransaction(_toAccount, _amount);
    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already been executed.");
        }
        _executed = true;
        _theWithdraw.Execute();
        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();
            _success = true;
        }
        else
        {
            throw new Exception("Cannot execute this transaction as the raw didn't go through");
        }
    }
    public void Rollback()
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has been executed.");
        }
        _executed = false;
        if (_reversed)
        {
            throw new Exception("Cannot reverse this transaction as it has eady been reversed.");
        }
        if (_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        if (_theDeposit.Success)
        {
            _theDeposit.Rollback();
        }
    }
    public void Print()
    {
        if (_success)
        {
            Console.WriteLine("Transferred " + _amount + " from " + _fromAccount.Name + "'s Account to " + _toAccount.Name + "'s Account ");
        }
        else if (_reversed)
        {
            Console.WriteLine("The transaction didn't go through");
        }
    }
}
