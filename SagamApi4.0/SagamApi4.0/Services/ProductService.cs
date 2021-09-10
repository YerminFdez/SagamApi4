﻿using Data;
using SagamApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4.Services
{
    public class ProductService : BaseService
    {
        public ProductService(DbContext context):base(context)
        {

        }

        public List<ProductModel> GetProducts()
        {
            const string command = @"select top 200 codart,desart,isnull(prelta,0)'prelta' from f_art a 
                                    left join f_lta l on l.artlta=a.codart";
            parameters = new List<System.Data.SqlClient.SqlParameter>();            
            return GetData(ExecuteReader(command), ProductModel.Create).ToList();
        }
        public List<ProductModel> GetProducts(int id,int tarifaId)
        {
            const string command = @"select codart,desart,prelta from f_art a
                                     inner join f_lta l on l.artlta=a.codart where codart=@id and tarlta=@tarifaId";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            return GetData(ExecuteReader(command), ProductModel.Create).ToList();
        }
        public List<ProductModel> GetProductByBarcode(string barcode,int tarifaId)
        {
            const string command = @"select codart,desart,prelta from f_ean e 
                                        inner join f_art a on a.codart=e.artean
                                        inner join f_lta l on l.artlta=a.codart where eanean=@barcode and tarlta=@tarifaId";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@barcode", barcode));
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            return GetData(ExecuteReader(command), ProductModel.Create).ToList();
        }
        public List<ProductModel> GetProductsByDescription(string text,int tarifaId)
        {
            const string command = @"select top 250 codart,desart,prelta from f_art a 
                                    left join f_lta l on l.artlta=a.codart where a.desart like @text and tarlta=@tarifaId order by desart";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            var castTxt = "%" + text.Replace(" ", "%").Trim()+"%";
            parameters.Add(new System.Data.SqlClient.SqlParameter("@text", castTxt));
            return GetData(ExecuteReader(command), ProductModel.Create).ToList();
        }
        public ProductModel GetProduct(int productId,int tarifaId)
        {
            const string command = @"select codart,desart,prelta from f_art a 
                                    left join f_lta l on l.artlta=a.codart where a.codart=@productId and tarlta=@tarifaId";
            parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@productId", productId));
            parameters.Add(new System.Data.SqlClient.SqlParameter("@tarifaId", tarifaId));
            return GetData(ExecuteReader(command), ProductModel.Create).FirstOrDefault();
        }

    }
}