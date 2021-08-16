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
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public List<ProductModel> Products()
        {
            var prodSrv = new ProductService(ConnectionHelper.GetContext());
            return prodSrv.GetProducts();
        }

        public List<ProductModel> Products(int tarifaId)
        {
            var prodSrv = new ProductService(ConnectionHelper.GetContext());
            return prodSrv.GetProducts(tarifaId);
        }

        // GET api/<controller>/5
        public ProductModel Get(int id,int tarifaId)
        {
            var prodSrv = new ProductService(ConnectionHelper.GetContext());
            return prodSrv.GetProduct(id,tarifaId);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}