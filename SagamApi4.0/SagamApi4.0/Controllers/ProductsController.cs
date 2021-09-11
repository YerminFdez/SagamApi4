using Data;
using SagamApi4.Models;
using SagamApi4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SagamApi4.Controllers
{
    public class ProductsController : ApiController
    {
        readonly DbContext context;
        public ProductsController()
        {
            context = ConnectionHelper.GetContext();
        }

        [HttpGet]
        [ActionName("FindProduct")]
        public List<ProductModel> FindProduct(string q)
        {
            using (context)
            {
                try
                {
                    string[] cmd = { "c", "b", "d","f" };
                    List<ProductModel> data = new List<ProductModel>();
                    string p1, p2;
                    int indxP1 = q.IndexOf(":");
                    int indxP2 = q.IndexOf("?");
                    p1 = q.Substring(indxP1 + 1, indxP2 - indxP1 - 1);
                    p2 = q.Substring(indxP2 + 1);

                    var prodSrv = new ProductService(context);

                    if (q.StartsWith(cmd[0]))//c = codigo interno
                        data = prodSrv.GetProducts(Convert.ToInt32(p1), Convert.ToInt32(p2));
                    else if (q.StartsWith(cmd[1]))//b = codigo de barras 
                        data = prodSrv.GetProductByBarcode(p1, Convert.ToInt32(p2));
                    else if (q.StartsWith(cmd[2]))//d = descripcion del producto
                        data = prodSrv.GetProductsByDescription(p1, Convert.ToInt32(p2));
                    else if (q.StartsWith(cmd[3]))//f = familia del producto
                        data = prodSrv.GetProductsByFamily(Convert.ToInt32(p1), Convert.ToInt32(p2));

                    return data;
                }
                catch
                {
                    int code = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                    throw ErrMsg.GetErr(code);
                }
            }
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
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                context.Dispose();
        }
    }
}