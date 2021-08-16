using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SagamApi4.Models
{
    public class CustomerModel : BaseModel
    {
        public string ComercialName { get; set; }
        public string FiscalName { get; set; }
        public string Telephone { get; set; }
        public string Contact { get; set; }

        public CustomerModel()
        {
            FiscalName = ComercialName = Telephone = Contact = string.Empty;
        }

        public static CustomerModel Create(IDataRecord record)
        {
            var cust = new CustomerModel();
            cust.ID = Convert.ToInt32(record["CODCLI"]);
            cust.ComercialName = Convert.ToString(record["NOCCLI"]);
            cust.FiscalName = Convert.ToString(record["NOFCLI"]);
            cust.Telephone = Convert.ToString(record["TELCLI"]);
            cust.Contact = Convert.ToString(record["CONCLI"]);
            return cust;
        }
    }
}