using Data;
using SagamApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4.Services
{
    public class AgentService : BaseService
    {
        public AgentService(DbContext context):base(context){}
        public AgentModel GetAgent(int id)
        {
            const string command = "select * from f_age where codage=@id";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            return GetData(ExecuteReader(command), AgentModel.Create).FirstOrDefault();
        }
    }
}