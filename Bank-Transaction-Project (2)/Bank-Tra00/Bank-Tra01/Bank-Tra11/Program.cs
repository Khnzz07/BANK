using System;
using System.Security.Principal;
//using SplashKitSDK;
public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    transfer,
    Quit,
}
public class Program
{
    int account;
    private static MenuOption ReadUserOption()
    {
        int option;
        string inputText;
        do
        {
            Console.WriteLine("Choose an option [1-5]: ");
            inputText = Console.ReadLine();
            option = Convert.ToInt32(inputText);
        } while (option < 1 || option > 5);
        return (MenuOption)(option - 1);
    }
    private static void DoWithdraw(Account account)
    {
        string inputText;
        decimal myDecimal;
        Console.WriteLine("How much would you like to withdraw?");
        do
        {
            inputText = Console.ReadLine();
            myDecimal = Convert.ToDecimal(inputText);
            if (myDecimal <= account._balance)
                break;
        }
        while (myDecimal <= account._balance);
        WithdrawTransaction WithdrawTransaction = new WithdrawTransaction(account,
        myDecimal);
        WithdrawTransaction.Execute();
        WithdrawTransaction.Print();
    }
    private static void DoDeposit(Account account)
    {
        string inputText;
        decimal myDecimal;
        Console.WriteLine("How much would you like to deposit?");
        inputText = Console.ReadLine();
        myDecimal = Convert.ToDecimal(inputText);
        DepositTransaction transaction = new DepositTransaction(account, myDecimal);
        transaction.Execute();
        transaction.Print();
    }
    private static void DoTransfer(Account FromAccount, Account toAccount, Decimal
    Amount)
    {
        TransferTransaction TransferObject = new TransferTransaction(FromAccount, toAccount, Amount);
        TransferObject.Execute();
        TransferObject.Print();
    }
    private static void DoPrint(Account account)
    {
        account.Print();
    }
    public static void Main()
    {
         Account account1 = new Account("Jake's Account", 200000);
        // account1.Print();
        // account1.Deposit(100);
        // account1.Print();
        // account1.Withdraw(100);
        // account1.Print();
        Account account = new Account("Alton's Account", 100000);
        // account.Print();
        // account.Deposit(500);
        // account.Print();
        // account.Deposit(100);
        // account.Print();
        // account.Withdraw(400);
        // account.Print();
        // account.Withdraw(300);
        // account.Print();
        String AccountName;
        String AccountName2;
        Decimal OpeningAmount;
        Decimal AmountToBeTransferred;
        string inputText;
        Console.WriteLine("* 1 will Withdraw *");
        Console.WriteLine("* 2 will Deposit *");
        Console.WriteLine("* 3 will Print Account *");
        Console.WriteLine("* 4 will Transfer Between Accounts");
        Console.WriteLine("* 5 will Quit *");
        MenuOption userSelection;
        userSelection = ReadUserOption();
        Console.WriteLine(userSelection);
        do
        {
            userSelection = ReadUserOption();
            switch (userSelection)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;
                case MenuOption.Print:
                    DoPrint(account);
                    break;
                case MenuOption.transfer:
                    Console.WriteLine("Please Amount to be tranferred");
                    inputText = Console.ReadLine();
                    AmountToBeTransferred = Convert.ToDecimal(inputText);
                    Console.WriteLine("Please Enter Name of the Withdrawl Account");
                    AccountName = Console.ReadLine();
                    Console.WriteLine("Please Enter Name of the Deposit Account");
                    AccountName2 = Console.ReadLine();
                    DoTransfer(account, account1, AmountToBeTransferred);


                    break;
                case MenuOption.Quit:
                    Console.WriteLine("See you later!");
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }
}
