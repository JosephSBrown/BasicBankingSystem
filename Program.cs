using System;
using System.Collections.Generic;
using System.Threading;

namespace BankingSystem
{

    class Customer
    {

        public string name;
        public string address;
        public Dictionary<int, Dictionary<string, string>> accounts = new Dictionary<int, Dictionary<string, string>>();
        public float withdrawn;
        public float depositIn;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        static void withdraw(float withdrawn)
        {
            Console.WriteLine("Amount: ");
            if (!float.TryParse(Console.ReadLine(), out withdrawn))
            {
                Console.WriteLine("No Valid Input...");
            };
        }

        static void deposit(float depositIn)
        {
            Console.WriteLine("Amount: ");
            if (!float.TryParse(Console.ReadLine(), out depositIn))
            {
                Console.WriteLine("No Valid Input...");
            };
        }

        public float checkBalance(float accountBalance)
        {
            return accountBalance;
        }

    }

    class Accounts
    {
        int accountNumber;
        float accountBalance;
        float interestRate;

        public float printBalance(float accountBalance)
        {
            return accountBalance;
        }

        public float updateBalance(float accountBalance, float withdrawn, float depositIn)
        {
            accountBalance = accountBalance + depositIn;
            accountBalance = accountBalance - withdrawn;
            return accountBalance;
        }

        public float acceptDeposit(float accountBalance, float depositIn)
        {
            accountBalance = accountBalance + depositIn;
            return accountBalance;
        }

        public float updateInterest(float interestRate)
        {
            if (!float.TryParse(Console.ReadLine(), out interestRate))
            {
                Console.WriteLine("No Valid Input...");
            };
            return interestRate;
        }

    }

    class Program
    {

        static bool MainMenu(Customer person)
        {
            Console.Clear();
            Console.WriteLine("1. Set Up New Account");
            Console.WriteLine("2. Check Account Balance");
            Console.WriteLine("3. Deposit Into Account");
            Console.WriteLine("4. Withdraw From Account");
            Console.WriteLine("X. Exit");
            Console.Write("Choose An Option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.Write("Please Enter a Name: ");
                    person.Name = Console.ReadLine();
                    Console.Write("Please Enter an Address: ");
                    person.Address = Console.ReadLine();
                    Random rnd = new Random();
                    Dictionary<string, string> nme = new Dictionary<string, string>();
                    nme.Add("Name", person.Name);
                    nme.Add("Address", person.Address);
                    int num = rnd.Next(100000, 999999);
                    person.accounts.Add(num, nme);
                    Console.WriteLine($"Account Created for {person.Name}... Account Number is: {num}");
                    Thread.Sleep(5000);
                    return true;
                case "2":
                    Console.Clear();
                    foreach (KeyValuePair<int, Dictionary<string, string>> kvp in person.accounts)
                    {
                        foreach (KeyValuePair<string, string> kvp2 in kvp.Value)
                        {
                            Console.WriteLine($"{kvp.Key}, {kvp2.Key}, {kvp2.Value}");
                        }
                    }
                    Thread.Sleep(20000);
                    return true;
                case "x":
                    Environment.Exit(0);
                    return false;
                default:
                    return true;

            }
        }

        static void Main(string[] args)
        {

            bool showmenu = true;
            Customer person = new Customer();

            while (showmenu)
            {
                showmenu = MainMenu(person);
            }

        }
    }

}