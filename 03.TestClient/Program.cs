using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split();
            var accountId = int.Parse(commandArgs[1]);
            switch (commandArgs[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        //var account = new BankAccount();
                        //account.Id = accountId;
                        //accounts.Add(accountId,account);
                        accounts.Add(accountId,new BankAccount{Id = accountId});
                    }
                    break;
                case "Deposit":
                    if (ValidateExistAccount(accountId, accounts))
                    {
                        accounts[accountId].Deposit(int.Parse(commandArgs[2]));
                    }
                    break;
                case "Withdraw":
                    if (ValidateExistAccount(accountId, accounts))
                    {
                        accounts[accountId].Withdraw(int.Parse(commandArgs[2]));
                    }
                    break;
                case "Print":
                    if (ValidateExistAccount(accountId, accounts))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    static bool ValidateExistAccount(int accountId, Dictionary<int, BankAccount> account)
    {
        if (account.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}

