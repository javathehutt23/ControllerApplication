using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp.Accounts
{
    [Serializable()]
    public class OmniAccount: Account
    {
        private float interestRate;
        public float InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        private float fees;
        public float Fees
        {
            get { return fees; }
            set { fees = value; }
        }
        private float overdraftLimit;
        public float OverdraftLimit
        {
            get { return overdraftLimit; }
            set { overdraftLimit = value; }
        }

        public OmniAccount(Customer c, int accountId, float balance, float overdraft)
        {
            AccountId = accountId;
            customer = c;
            Balance = balance;
            InterestRate = 4;
            Fees = 10;
            OverdraftLimit = overdraft;
        }


        public float CalculateInterest()
        {
            Balance = Balance * ((InterestRate / 100) + 1);
            return Balance;
        }
    }
}
