using System;

namespace Keeton_CashFlowManager
{
    public class Invoice : IPayable
    {
        public string PartNumber;
        public string PartNumber1;
        public string PartNumber2;
        public int Quantity;
        public string PartDescription;
        public decimal Price;



        public Invoice(string _PartNumber, int _Quantity, string _PartDescription, decimal _Price)
        {
            GetPartNumber();
            PartNumber = _PartNumber;
            Quantity = _Quantity;
            PartDescription = _PartDescription;
            Price = _Price;           
        }
        public string GetPartNumber()
        {
            Random r1 = new Random();
            for (int x = 0; x < 999999; x++)
            {
                PartNumber1 = r1.Next(999999).ToString();
            }
            Random r2 = new Random();
            for (int x = 0; x < 9999; x++)
            {
                PartNumber2 = r2.Next(9999).ToString();
            }

            PartNumber = PartNumber1 + "_" + PartNumber2;
            return PartNumber;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public string GetName()
        {
            return PartDescription;
        }
        public decimal GetPrice()
        {
            return Price;
        }
        public decimal GetPayableAmount()
        {
            return Quantity * Price;
        }
        public void CurrentType(ILedgerType.LedgerType CurrentType)
        {
            CurrentType = ILedgerType.LedgerType.Invoice;
        }
        public decimal GetHours()
        {
            return 0;
        }
        public decimal GetHourlyWage()
        {
            return 0;
        }
        public string GetSSN()
        {
            return "";
        }
    }
}
