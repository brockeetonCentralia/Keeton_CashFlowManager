using System;

//Broc Keeton
//IT112
//NOTES:
//BEHAVIORS NOT IMPLEMENTED AND WHY: 

namespace Keeton_CashFlowManager
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            Salaried salaried1 = new Salaried("John", "Smith", "111-111-1111", 800.50M);
            salaried1.CurrentType(IPayable.LedgerType.Salaried);
            Salaried salaried2 = new Salaried("Susan", "Mathews", "222-222-2222", 1110.00M);
            salaried2.CurrentType(IPayable.LedgerType.Salaried);
            Hourly hourly1 = new Hourly("Karen", "Williams", "444-444-444", 16.75M, 40.00M);
            hourly1.CurrentType(IPayable.LedgerType.Hourly);
            Hourly hourly2 = new Hourly("Carol", "Walsh", "333-333-3333", 19.50M, 42.00M);
            hourly2.CurrentType(IPayable.LedgerType.Hourly);
            Invoice invoice1 = new Invoice("Part Number", 2, "Flux Capacitor", 3655.66M);
            invoice1.CurrentType(IPayable.LedgerType.Invoice);
            Invoice invoice2 = new Invoice("Part Number", 3, "Flux Capacitor", 14.50M);
            invoice2.CurrentType(IPayable.LedgerType.Invoice);

            IPayable[] payables = new IPayable[100];
            AddToTotalCashFlow(salaried1 , payables);
            AddToTotalCashFlow(salaried2 , payables);
            AddToTotalCashFlow(hourly1, payables);
            AddToTotalCashFlow(hourly2, payables);
            AddToTotalCashFlow(invoice1, payables);
            AddToTotalCashFlow(invoice2 , payables);

            Console.WriteLine("To Add Items to Cash Flow Manager\nPress 1");
            string AddCashToList = Console.ReadLine();

            while (AddCashToList == "1")
            {
                Menu();
                Console.WriteLine("Please Pick an option");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string HourlyFirst = ""; string HourlyLast = ""; string HourlySSN = ""; decimal HourlyWage = 0; int HoursWorked = 0;
                        Console.WriteLine("What is the first name?");
                        HourlyFirst = Console.ReadLine();
                        Console.WriteLine("What is the last name?");
                        HourlyLast = Console.ReadLine();
                        Console.WriteLine("Enter the SSN ###-##-####");
                        HourlySSN = Console.ReadLine();
                        Console.WriteLine("How Many hours did they work?");
                        HoursWorked = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("What is their hourly pay?");
                        HourlyWage = Convert.ToDecimal(Console.ReadLine());

                        Hourly hourly = new Hourly(HourlyFirst, HourlyLast, HourlySSN, HoursWorked, HourlyWage);
                        AddToTotalCashFlow(hourly, payables);
                        hourly.CurrentType(IPayable.LedgerType.Hourly);

                        break;

                    case "2":
                        string SalariedFirst = ""; string SalariedLast = ""; string SalariedSSN = ""; decimal SalariedPay = 0;
                        Console.WriteLine("What is the first name?");
                        SalariedFirst = Console.ReadLine();
                        Console.WriteLine("What is the last name?");
                        SalariedLast = Console.ReadLine();
                        Console.WriteLine("Enter the SSN ###-##-####");
                        SalariedSSN = Console.ReadLine();
                        Console.WriteLine("What is their salary for the week?");
                        SalariedPay = Convert.ToDecimal(Console.ReadLine());

                        Salaried salary = new Salaried(SalariedFirst, SalariedLast, SalariedSSN, SalariedPay);
                        AddToTotalCashFlow(salary, payables);
                        salary.CurrentType(IPayable.LedgerType.Salaried);

                        break;
                    case "3":
                        string PartNumber = ""; int Quantity = 0; string PartName = ""; decimal Price = 0;
                        PartNumber = "PartNumber";
                        Console.WriteLine("What is the part description?");
                        PartName = Console.ReadLine();
                        Console.WriteLine("How many parts?");
                        Quantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How much does each one cost?");
                        Price = Convert.ToDecimal(Console.ReadLine());

                        Invoice invoice = new Invoice(PartNumber, Quantity, PartName, Price);
                        AddToTotalCashFlow(invoice, payables);
                        invoice.CurrentType(IPayable.LedgerType.Invoice);

                        break;
                    case "4":
                        decimal InvoiceTotal = 0; decimal SalariedTotal = 0; decimal HourlyTotal = 0; decimal TotalPayout = 0;
                        for (int i = 0; i < payables.Length; i++)
                        {
                            if (payables[i] != null)
                            {
                                if (payables[i] is Hourly)
                                {


                                    Console.WriteLine("Hourly Employee: " + payables[i].GetName());
                                    Console.WriteLine("SSN: " + payables[i].GetSSN());
                                    Console.WriteLine("Hourly wage Salary: " + payables[i].GetHourlyWage().ToString("$0.00"));
                                    Console.WriteLine("Hours Worked: " + payables[i].GetHours());
                                    Console.WriteLine("Earned: " + payables[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    HourlyTotal += payables[i].GetPayableAmount();
                                }

                                if (payables[i] is Salaried)

                                {

                                    Console.WriteLine("Salaried Employee: " + payables[i].GetName());
                                    Console.WriteLine("SSN: " + payables[i].GetSSN());
                                    Console.WriteLine("Weekly Salary: " + payables[i].GetPayableAmount().ToString("$00.00"));
                                    Console.WriteLine("Earned: " + payables[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    SalariedTotal += payables[i].GetPayableAmount();

                                }

                                if (payables[i] is Invoice)
                                {
                                    Console.WriteLine("Invoice");
                                    Console.WriteLine(payables[i].GetPartNumber());
                                    Console.WriteLine("Quantity: " + payables[i].GetQuantity());
                                    Console.WriteLine("Part Description: " + payables[i].GetName());
                                    Console.WriteLine("Unit Price: " + payables[i].GetPrice().ToString("$00.00"));
                                    Console.WriteLine("Extened Price: " + payables[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    InvoiceTotal += payables[i].GetPayableAmount();
                                }
                            }
                        }
                        TotalPayout = InvoiceTotal + SalariedTotal + HourlyTotal;

                        Console.WriteLine("Total Weekly Payout: " + TotalPayout.ToString("$0.00") + "\n");
                        Console.WriteLine("Category Breakdown:");
                        Console.WriteLine("Invoices: " + InvoiceTotal.ToString("$0.00"));
                        Console.WriteLine("Salaried Payroll: " + SalariedTotal.ToString("$0.00"));
                        Console.WriteLine("Hourly Payroll: " + HourlyTotal.ToString("$0.00") + "\n");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Please select a number from the List.");
                        Menu();
                        break;

                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("1 : Add Salaried Employee");
            Console.WriteLine("2 : Add Hourly Employee");
            Console.WriteLine("3 : Add Invoice of Item");
            Console.WriteLine("4 : Display Cash Flow");
            Console.WriteLine("0 : Exit");
        }
        public static bool AddToTotalCashFlow(IPayable payable, IPayable[] list)
        {
            for(int i = 0; i < 100; i++)
            {
                if (list[i] == null)
                {
                    list[i] = payable;
                    return true;
                }
            }
            return false;
        }
    }
}

