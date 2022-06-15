using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeton_CashFlowManager
{
    public interface ILedgerType
    {
        public enum LedgerType
        {
            Salaried,
            Hourly,
            Invoice
        }
    }
}
