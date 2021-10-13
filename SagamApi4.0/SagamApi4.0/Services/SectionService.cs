using Data;
using SagamApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4.Services
{
    public class SectionService : BaseService
    {
        public SectionService(DbContext context) : base(context) { }

        public List<SectionModel> GetAll()
        {
            const string command = "select * from f_sec";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            return GetData(ExecuteReader(command), SectionModel.Create).ToList();
        }
        public SectionModel GetSection(int id)
        {
            const string command = "select * from f_sec where codsec=@id";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            return GetData(ExecuteReader(command), SectionModel.Create).FirstOrDefault();
        }
    }
}