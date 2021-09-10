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
    public class FamiliesController : ApiController
    {        

        // GET api/<controller>
        public IEnumerable<FamilyModel> Get()
        {
            using (var context = ConnectionHelper.GetContext())
            {
                var famSrv = new FamilyService(context);
                var families = famSrv.GetAll(); 
                return families;
            }
           
        }

        // GET api/<controller>/5
        public FamilyModel Get(int id)
        {
            using (var context = ConnectionHelper.GetContext())
            {
                var famSrv = new FamilyService(context);
                var family = famSrv.GetFamily(id);
                return family;
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