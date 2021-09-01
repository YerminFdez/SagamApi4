using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SagamApi4.Models
{
    public class AgentModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public static AgentModel Create(IDataRecord record)
        {
            var agent = new AgentModel();
            agent.ID = Convert.ToInt32(record["codage"]);
            agent.Username = Convert.ToString(record["useage"]);
            agent.Password = Convert.ToString(record["pasage"]);
            agent.Name = Convert.ToString(record["nomage"]);
            return agent;
        }
    }
}