using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
    public class EverydayAccount : Account
    {
        //private int accountId;
        /*public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        private string accountType;
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        private float balance;
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }*/
        /*public override string CheckBalance()
        {
            Console.WriteLine("the balance is: $" + Balance);
            string a = AccountType + " " + AccountId + "; balance $" + Balance;
            return a;
        }*/
        public EverydayAccount(Customer c, int accountId, float balance)
        {
            this.AccountId = accountId;
            this.customer = c;
            this.Balance = balance;
        }

        
        //public override void CalculateInterest() { Console.WriteLine("Interest isn't authorised for this type of account"); }
    }
}
