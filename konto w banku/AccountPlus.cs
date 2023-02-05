namespace Bank
{
    public class AccountPlus : Account, IAccountWithLimit
    {
        public AccountPlus(string name, decimal initialBalance = 0.00m, decimal initialLimit = 100.00m) : base(name, initialBalance)
        {
            if (initialLimit < 0) OneTimeDebetLimit = 0;
            else OneTimeDebetLimit = Math.Round(initialLimit,4);

            Balance = Math.Round(initialBalance, 4);
        }

        private decimal balance {get; set; }
        public new decimal Balance
        {            
            get
            {
                return balance < 0 ? 0 : balance;
            }
            set => balance = value;
        }

        //blokada
        public new void Unblock()
        {
            if (balance < 0) return;
                else IsBlocked = false;
        }        

        //możliwy debet
        private decimal oneTimeDebetLimit;
        public decimal OneTimeDebetLimit
        {
            get => oneTimeDebetLimit;
            set
            {
                if (IsBlocked == false) oneTimeDebetLimit = value;
                if (value < 0) return;
            }
        }

        //dostępne środki
        public decimal AvaibleFounds => Math.Round(balance, 4) + Math.Round(OneTimeDebetLimit, 4);

        //wpłata
        public new bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance = Math.Round(balance,4) + Math.Round(amount,4);
                if (Balance>=0) Unblock();
                return true;
            }
            else return false;
        }

        //wypłata
        public new bool Withdrawal(decimal amount)
        {
            if (IsBlocked == false && AvaibleFounds > amount && amount > 0)
            {
                Balance -= Math.Round(amount,4);                
                if (balance < 0) Block();
                return true;
            }
            else return false;
        }

        public override string ToString() => string.Format("Account name: {0}, balance: {1:N2}{2}, avaible founds: {3:N2}, limit: {4:N2}", Name, Balance, IsBlocked ? ", blocked" : "", AvaibleFounds, OneTimeDebetLimit);

    }

    class Project
    {
        static void Main(string[] args)
        {            
            //first test
            try
            {
                var account1 = new Account("Jim", -100.01m);
                Console.WriteLine(account1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Negative argument");
            }


            Console.WriteLine();
            //secont test
            try
            {
                var account2 = new Account("   Jo   ", 100.0m);
                Console.WriteLine(account2);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name is to short");
            }


            Console.WriteLine();
            //third test
            var account3 = new Account("John");
            account3.Deposit(100.2345m);
            account3.Deposit(10.2345m);
            Console.WriteLine(account3);


            Console.WriteLine();
            //4th test
            // scenariusz: wpłaty wypłaty, blokada konta
            // utworzenie konta plus z domyslnym limitem 100
            var john = new AccountPlus("John", initialBalance: 100.0m);
            Console.WriteLine(john);

            // wypłata - podanie kwoty ujemnej
            john.Withdrawal(-50.0m);
            Console.WriteLine(john);

            // wypłata bez wykorzystania debetu
            john.Withdrawal(50.0m);
            Console.WriteLine(john);

            // wypłata z wykorzystaniem debetu
            john.Withdrawal(100.0m);
            Console.WriteLine(john);

            // konto zablokowane, wypłata niemożliwa
            john.Withdrawal(10.0m);
            Console.WriteLine(john);

            // wpłata odblokowująca konto
            john.Deposit(80.0m);
            Console.WriteLine(john);

            // wpłata podanie kwoty ujemnej
            john.Deposit(-80.0m);
            Console.WriteLine(john);


            Console.WriteLine();
            //5th test
            // sytuacje specjalne
            // konto z zerowym stanem
            var account = new AccountPlus("Nathan", initialBalance: 0, initialLimit: 0);
            Console.WriteLine(account);
            account.Withdrawal(10);
            Console.WriteLine(account);

            // zerowe saldo, limit 50
            account.OneTimeDebetLimit = 50;
            Console.WriteLine(account);
            account.Withdrawal(0); // zerowa wypłata
            Console.WriteLine(account);
            account.Withdrawal(10); // wypłata w ramach debetu
            Console.WriteLine(account);
            account.Unblock(); // próba odblokowania konta
            Console.WriteLine(account);
            account.Deposit(10); // likwidacja debetu, zerowy bilans
            Console.WriteLine(account);
        }
        
    }
}