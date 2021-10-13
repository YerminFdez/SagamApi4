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
    public class SectionsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SectionModel> Get()
        {
            using (var context = ConnectionHelper.GetContext())
            {
                var service = new SectionService(context);
                var sections = service.GetAll();
                return sections;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "";
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