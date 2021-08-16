using Data;
using SagamApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4.Services
{
    public class ProductService : Repository<ProductModel>
    {
        public ProductService(DbContext context):base(context)
        {

        }

        public List<ProductModel> GetProducts()
        {
            const string command = @"select top 200 codart,desart,isnull(prelta,0)'prelta' from f_art a 
                                    left join f_lta l on l.artlta=a.codart";
            parameters = new List<System.Data.SqlClient.SqlParameter>();            
            return GetData(ExecuteReader2(command), ProductModel.Create).ToList();
        }
        public List<ProductModel> GetProducts(int tarifaId)
        {
            const string command = @"select top 200 codart,desart,prelta from f_art a 
                                    left join f_lta l on l.artlta=a.codart where tarlta=@tarifaId";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            return GetData(ExecuteReader2(command), ProductModel.Create).ToList();
        }
        public ProductModel GetProduct(int productId,int tarifaId)
        {
            const string command = @"select codart,desart,prelta from f_art a 
                                    left join f_lta l on l.artlta=a.codart where a.codart=@productId and tarlta=@tarifaId";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@productId", productId));
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            return GetData(ExecuteReader2(command), ProductModel.Create).FirstOrDefault();
        }


    }
}