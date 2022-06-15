using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeton_CashFlowManager
{

    public interface IPayable : ILedgerType
    {
        decimal GetPayableAmount();
        int GetQuantity();
        decimal GetPrice();
        string GetName();        
        string GetPartNumber();
        string GetSSN();
        decimal GetHourlyWage();
        decimal GetHours();
        public void CurrentType(ILedgerType.LedgerType type);


    }
}
