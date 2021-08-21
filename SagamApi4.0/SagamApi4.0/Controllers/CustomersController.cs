using System.Collections.Generic;
using System.Web.Http;
using Data;
using SagamApi4.Models;
using SagamApi4.Services;

namespace SagamApi4.Controllers
{
    public class CustomersController : ApiController
    {
        readonly DbContext context;
        public CustomersController()
        {
            context = ConnectionHelper.GetContext();
        }

        // GET api/values
        public List<CustomerModel> Get()
        {
            var custSrv = new CustomerService(context);
            List<CustomerModel> customers = custSrv.GetCustomers();
            context.Dispose();
            return customers;
        }

        // GET api/values/5
        public CustomerModel Get(int id)
        {
            var custSrv = new CustomerService(context);
            return custSrv.GetCustomer(id);
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
                context.Dispose();
        }
    }
}