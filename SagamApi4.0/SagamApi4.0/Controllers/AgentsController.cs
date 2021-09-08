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
    public class AgentsController : ApiController
    {
        // GET api/<controller>/5
        public AgentModel Get(int id)
        {            
            try
            {
                using(var ageSrv=new AgentService(ConnectionHelper.GetContext()))
                {
                    var agent = ageSrv.GetAgent(id); 
                    return agent;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}