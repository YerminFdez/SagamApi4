using System.Collections.Generic;
using System.Linq;
using Data;
using SagamApi4.Models;

namespace SagamApi4.Services
{
    public class CustomerService : Repository<CustomerModel>
    {
        public CustomerService(DbContext context):base(context)
        {
        }
        public List<CustomerModel> GetCustomers()
        {
            const string command = "select * from f_cli";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            return GetData(ExecuteReader2(command), CustomerModel.Create).ToList();
        }
        public CustomerModel GetCustomer(int id)
        {
            const string command = "select * from f_cli where codcli=@id";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            return GetData(ExecuteReader2(command), CustomerModel.Create).FirstOrDefault();
        }
    }
}