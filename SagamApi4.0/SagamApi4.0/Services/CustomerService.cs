using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Data;
using SagamApi4.Models;

namespace SagamApi4.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService(DbContext context):base(context)
        {
        
        }
        [HttpGet]
        public List<CustomerModel> GetCustomers()
        {
            const string command = "select * from f_cli";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            return GetData(ExecuteReader(command), CustomerModel.Create).ToList();
        }
        [HttpGet()]        
        public CustomerModel GetCustomer(int id)
        {
            const string command = "select * from f_cli where codcli=@id";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            return GetData(ExecuteReader(command), CustomerModel.Create).FirstOrDefault();
        }
    }
}