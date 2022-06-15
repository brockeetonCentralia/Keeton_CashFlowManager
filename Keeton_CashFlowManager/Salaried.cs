using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeton_CashFlowManager
{
    public class Salaried : Employee
    {
        public Salaried(string _FirstName, string _LastName, string _SSN, decimal _WeeklySalary) : base (_FirstName, _LastName, _SSN)
        {
            Amount = _WeeklySalary;
        }

        public override decimal GetPayableAmount()
        {
            return Amount;
        }
        public new void CurrentType(ILedgerType.LedgerType currentType)
        {
            currentType = ILedgerType.LedgerType.Salaried;
        }
    }
}
