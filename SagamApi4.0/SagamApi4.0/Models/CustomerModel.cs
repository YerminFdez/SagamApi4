using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4._0.Models
{
    public class CustomerModel : BaseModel
    {
        public string ComercialName { get; set; }
        public string FiscalName { get; set; }
        public string Telephone { get; set; }
        public string Contact { get; set; }
    }
}