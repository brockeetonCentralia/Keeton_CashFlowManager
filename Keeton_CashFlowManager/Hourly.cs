using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeton_CashFlowManager
{
    public class Hourly : Employee
    {
        private decimal HourlyWage;
        private decimal HourlyWage2; //time and a half
        private decimal TotalOvertime;
        private decimal HoursWorked;
        decimal round;

        public Hourly(string _FirstName, string _LastName, string _SSN, decimal _HourlyWage, decimal _HoursWorked) : base (_FirstName, _LastName, _SSN)
        {
            HourlyWage = _HourlyWage;
            HoursWorked = _HoursWorked;
        }

        public override decimal GetHourlyWage()
        {
            return HourlyWage;
        }
        public override decimal GetHours()
        {
            return HoursWorked;
        }
        public override decimal GetPayableAmount()
        {
            if (HoursWorked > 40)
            {
                HourlyWage2 = HourlyWage + (HourlyWage / 2);
                TotalOvertime = (HoursWorked - 40) * HourlyWage2;
                Amount = (HoursWorked * HourlyWage) + TotalOvertime;
                round = Decimal.Round(Amount, 2);
                return Amount;
            }
            else
            {
                Amount = HoursWorked * HourlyWage;
                round = Decimal.Round(Amount, 2);
                return Amount;
            }
        }
        public new void CurrentType(ILedgerType.LedgerType CurrentType)
        {
            CurrentType = ILedgerType.LedgerType.Hourly;
        }
    }
}
