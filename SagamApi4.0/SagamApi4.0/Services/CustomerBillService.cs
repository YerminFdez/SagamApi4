using Data;
using SagamApi4.Models;
using System.Collections.Generic;
using System.Linq;

namespace SagamApi4.Services
{
    public class CustomerBillService: BaseService
    {
        public CustomerBillService(DbContext context):base(context){}

        public List<CustomerBillModel>GetPendienteBills(int customerId)
        {
            const string command = @"select codfac,clifac,fecfac,((brtfac-dtofac)+iimfac) as totfac, isnull(SUM(c.MONCOB),0) 'pagfac'
                                    from f_fac f left join f_cob c on c.faccob=f.codfac 
                                    where clifac=@customerId and estfac in('0','2')
                                    group by codfac,clifac,fecfac,((brtfac-dtofac)+iimfac)";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@customerId", customerId));
            return GetData(ExecuteReader(command),CustomerBillModel.Create).ToList();
        }
    }
}