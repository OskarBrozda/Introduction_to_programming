using System;
using System.Xml.Linq;

namespace Bank
{
    public class Account : IAccount
    {
        //zmienne
        public string Name { get; }
        public decimal Balance { get; private set; }
        public bool IsBlocked { get; set; } = false;

        //konstruktor
        public Account(string name, decimal initialBalance = 0)
        {
            if (name == null || initialBalance < 0)
                throw new ArgumentOutOfRangeException();
            if (name.Trim().Length < 3)
                throw new ArgumentException();
            Name = name;
            Balance = Math.Round(initialBalance, 4);
        }             

        //metody (od)blokowania konta
        public void Block() => IsBlocked = true;        
        public void Unblock() => IsBlocked = false;
        
        //wpłata
        public bool Deposit(decimal amount)
        {
            if (IsBlocked == false && amount > 0)
            {
                Balance += Math.Round(amount, 4);
                return true;
            }
            else return false;            
        }

        //wypłata
        public bool Withdrawal(decimal amount)
        {
            if (IsBlocked == false && amount > 0 && Balance >= amount)
            {
                Balance -= Math.Round(amount, 4);
                return true;
            }
            else return false;
        }

        //wyświetlany rezultat        
        public override string ToString() => string.Format("Account name: {0}, balance: {1:N2}{2}", Name, Balance, IsBlocked ? ", blocked" : "");                
    }
}
