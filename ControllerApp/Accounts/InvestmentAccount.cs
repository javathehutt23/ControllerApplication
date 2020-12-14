using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
    public class InvestmentAccount: Account
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
        public InvestmentAccount(Customer c, int accountId, float balance)
        {
            AccountId = accountId;
            customer = c;
            Balance = balance;
            InterestRate = 3;
            Fees = 10;
        }

        public float CalculateInterest()
        {
            Balance = Balance * ((InterestRate / 100) + 1);
            return Balance;
        }

        public override float Withdraw(float withdrawAmount)
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
    }
}
