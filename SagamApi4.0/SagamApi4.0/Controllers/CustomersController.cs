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
    public class CustomersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CustomerModel> Get()
        {

            using (var custSrv = new CustomerService(ConnectionHelper.GetContext()))
            {
                var result = custSrv.GetCustomers();
                return result;
            }
        }

        // GET api/<controller>/5
        public CustomerModel Get(int id)
        {
            using (var custSrv = new CustomerService(ConnectionHelper.GetContext()))
            {
                var result = custSrv.GetCustomer(id);
                return result;
            }
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