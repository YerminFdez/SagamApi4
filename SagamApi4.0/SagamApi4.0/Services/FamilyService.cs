using Data;
using SagamApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4.Services
{
    public class FamilyService : BaseService
    {
        public FamilyService(DbContext context) : base(context) { }

        public List<FamilyModel> GetAll()
        {
            const string command = "select * from f_cat";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            return GetData(ExecuteReader(command), FamilyModel.Create).ToList();
        }
        public FamilyModel GetFamily(int id)
        {
            const string command = "select * from f_cat where codfam=@id";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            return GetData(ExecuteReader(command), FamilyModel.Create).FirstOrDefault();
        }
    }
}