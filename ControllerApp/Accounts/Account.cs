using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
    public abstract class Account
    {
        public Customer customer;

        private int accountId;
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        //private string accountType;
        /*public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }*/
        private float balance;
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public float Deposit(float depositAmount)
        {
            if (depositAmount <= 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }
            float newBalance = Balance + depositAmount;
            return newBalance;
        }
        public virtual float Withdraw(float withdrawAmount)
        {
            
            if (Balance < withdrawAmount)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (withdrawAmount <= 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }


            Balance -= withdrawAmount;
            return Balance;
        }
        //public abstract void CalculateInterest();
        //public abstract string CheckBalance();
    }
}
