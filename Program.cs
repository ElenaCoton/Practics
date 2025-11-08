using System;

namespace BankAccount
{
    public enum AccountType { Checking, Deposit};
    public struct BankAccount
    {
        public string accNo;
        public decimal accBal;
        public AccountType accType;
    };
    public struct Distance
    {
        public long pound;
        public long inch;
    };
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание и использование структуры
            AccountType goldAccount, platinumAccount;
            goldAccount = AccountType.Checking;
            platinumAccount = AccountType.Deposit;
            Console.WriteLine("The Customer Account Type is {0}",
                                goldAccount);
            Console.WriteLine("The Customer Account Type is {0}",
                                platinumAccount);

            //Создание и использование структуры
            BankAccount goldBankAccount;
            Console.Write("Enter account number: ");
            goldBankAccount.accNo =  Console.ReadLine();
            Console.Write("Enter balance: ");
            goldBankAccount.accBal = decimal.Parse( Console.ReadLine()) ;
            goldBankAccount.accType = AccountType.Checking;
            Console.WriteLine($"Your account is {goldBankAccount.accNo} with balance {goldBankAccount.accBal}, tipe is {goldBankAccount.accType}\n");

            //Реализация структуры Distance
            Console.WriteLine("--------Реализация структуры Distance------");
            Distance firstDistance, secondDistance, resultDistance;
            Console.WriteLine("Enter pounds for the first distance:");
            firstDistance.pound = long.Parse( Console.ReadLine()) ;
            Console.WriteLine("Enter inches for then first distance:");
            firstDistance.inch = long.Parse( Console.ReadLine()) ;

            Console.WriteLine("Enter pounds for the second distance:");
            secondDistance.pound = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter inches for then second distance:");
            secondDistance.inch = long.Parse(Console.ReadLine());

            resultDistance.inch = (firstDistance.inch + secondDistance.inch) %12 ;
            resultDistance.pound = firstDistance.pound + secondDistance.pound + (int)(firstDistance.inch + secondDistance.inch) / 12;
            Console.WriteLine($"The sum of two distanse is {resultDistance.pound}' {resultDistance.inch}''");
        }
    }
}
