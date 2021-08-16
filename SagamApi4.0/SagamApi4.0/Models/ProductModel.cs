using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SagamApi4.Models
{
    public class ProductModel : BaseModel
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public static ProductModel Create(IDataRecord record)
        {
            var product = new ProductModel();
            product.ID = Convert.ToInt32(record["codart"]);
            product.Description = Convert.ToString(record["desart"]);
            product.Price = Convert.ToDouble(record["prelta"]);
            return product;
        }
    }
}