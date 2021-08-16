using System;
using System.Data;

namespace SagamApi4.Models
{
    public class CustomerBillModel : BaseModel
    {
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double PendingAmount { get { return BillAmount - PaidAmount; } }

        public CustomerBillModel()
        {
            Date = DateTime.Today;
        }

        public static CustomerBillModel Create(IDataRecord record)
        {
            var bill = new CustomerBillModel();
            bill.ID = Convert.ToInt32(record["codfac"]);
            bill.InvoiceNumber = Convert.ToString(record["codfac"]);
            bill.CustomerId = Convert.ToInt32(record["clifac"]);
            bill.Date = Convert.ToDateTime(record["fecfac"]);
            bill.BillAmount = Convert.ToDouble(record["totfac"]);
            bill.PaidAmount = Convert.ToDouble(record["pagfac"]);
            return bill;
        }
    }
}