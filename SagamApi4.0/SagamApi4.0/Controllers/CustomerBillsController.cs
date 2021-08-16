using SagamApi4.Models;
using SagamApi4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SagamApi4.Controllers
{
    public class CustomerBillsController : ApiController
    {

        readonly CustomerBillService custBillSrv;
        public CustomerBillsController()
        {
            custBillSrv = new CustomerBillService(ConnectionHelper.GetContext());
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {           
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public List<CustomerBillModel> Get(int id)
        {
            var bills = custBillSrv.GetPendienteBills(id);
            return bills;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}