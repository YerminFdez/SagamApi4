using Data;
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

        DbContext context;
        public FamiliesController()
        {
            context = ConnectionHelper.GetContext();
        }

        // GET api/<controller>
        public IEnumerable<FamilyModel> Get(string q)
        {
            try
            {
                using (context)
                {
                    var famSrv = new FamilyService(context);
                    List<FamilyModel> data = new List<FamilyModel>();
                    if (string.IsNullOrWhiteSpace(q))
                        data = famSrv.GetAll();
                    else if (q.StartsWith("s:"))
                    {
                        data = famSrv.GetFamiliesBySection(q.Substring(2));
                    }

                    return data;
                }
            }
            catch (Exception)
            {

                throw;
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