using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SagamApi4.Models
{
    public class FamilyModel : BaseModel
    {
        public string Abbreviation { get; set; }
        public string Name { get; set; }

        public static FamilyModel Create(IDataRecord record)
        {
            var family = new FamilyModel();
            family.ID = Convert.ToInt32(record["codcat"]);
            family.Abbreviation = Convert.ToString(record["abrcat"]);
            family.Name = Convert.ToString(record["descat"]);
            return family;
        }
    }
}