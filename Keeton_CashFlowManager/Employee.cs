using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeton_CashFlowManager
{
    public abstract class Employee : IPayable
    {        
        private string FirstName;
        private string LastName;
        private string SSN;
        protected decimal Amount;

        public Employee (string _FirstName, string _LastName, string _SSN)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            SSN = _SSN;
        }
        public string GetName()
        {
            return FirstName + " " + LastName;
        }
        public string GetSSN()
        {
            return SSN;
        }
        public virtual decimal GetPayableAmount()
        {
            return Amount;
        }
        public void CurrentType(ILedgerType.LedgerType Type)
        {

        }
        public int GetQuantity()
        {
            return 0;
        }
        public decimal GetPrice()
        {
            return 0;
        }
        public string GetPartNumber()
        {
            return "";
        }
        public virtual decimal GetHourlyWage()
        {
            return 0;
        }
        public virtual decimal GetHours()
        {
            return 0;
        }
    }
}
