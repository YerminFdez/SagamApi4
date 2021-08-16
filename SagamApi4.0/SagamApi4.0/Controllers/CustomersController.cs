using SagamApi4._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Domain.Service.Customer;
using Domain.Service.Customer.Models;

namespace SagamApi4._0.Controllers
{    
    public class CustomersController : ApiController
    {
        // GET api/values
        public List<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();
            var custApi = new CustomerApi();
            customers = custApi.GetCustomerByNameContain("");

            return customers;
        }      
        
        // GET api/values/5
        public Customer Get(int id)
        {
            var custApi = new CustomerApi();
            return custApi.GetCustomer(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}