namespace BankAccount
{
    internal class Accounts
    {
        public enum AccountType { Checking, Deposit };
        public class BankAccount : IComparable<BankAccount>
        {
            private string accNo;
            private decimal accBal;
            private AccountType accType;
            private static long nextAccNo;
            private long accId;

            public void Populate(string acc, decimal bal)
            { 
                accNo = acc;
                accBal = bal;
                accType = AccountType.Checking;
                accId = NextNumber();
            }
            public string GetAcc()
            { 
                return accNo;
            }
            public decimal GetBal()
            {
                return accBal;
            }
            public AccountType GetAccountType()
            {
                return accType;
            }
            private static long NextNumber()
            {
                return nextAccNo++;
            }
            public decimal Deposit(decimal amount)
            {
                accBal += amount;
                return accBal;
            }

            public bool Withdraw(decimal amount)
            {
                bool sufficientFunds = accBal >= amount;
                if (sufficientFunds)
                {
                    accBal -= amount;
                }
                return sufficientFunds;
            }

            public int CompareTo(BankAccount other)
            {
                if (other == null) return 1;
                return accBal.CompareTo(other.accBal);
            }

        };

        static void Main(string[] args)
        {
            string acc;
            decimal bal;
            AccountType goldAccount, platinumAccount;
            goldAccount = AccountType.Checking;
            platinumAccount = AccountType.Deposit;
            Console.WriteLine("The Customer Account Type is {0}",
                                goldAccount);
            Console.WriteLine("The Customer Account Type is {0}",
                                platinumAccount);

            BankAccount goldBankAccount = new BankAccount();
            Console.Write("Enter account number: ");
            acc = Console.ReadLine();
            Console.Write("Enter balance: ");
            bal = decimal.Parse(Console.ReadLine());
            goldBankAccount.Populate(acc, bal);

            Console.WriteLine($"Your account is {goldBankAccount.GetAcc()} with balance {goldBankAccount.GetBal()}, tipe is {goldBankAccount.GetAccountType()}\n");

            BankAccount silverBankAccount = new BankAccount();
            silverBankAccount.Populate("1234567890", 100000);

            List<BankAccount> banks = new List<BankAccount>();
            banks.Add(goldBankAccount);
            banks.Add(silverBankAccount);
            banks.Sort();
            foreach (var item in banks)
            {
                Console.WriteLine($"{item.GetAcc()}: {item.GetBal()}");
            }

        }
    }
}
