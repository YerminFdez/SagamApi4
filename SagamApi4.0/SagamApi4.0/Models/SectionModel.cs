using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SagamApi4.Models
{
    public class SectionModel 
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        
        public static SectionModel Create(IDataRecord record)
        {
            var section = new SectionModel();
            section.ID = Convert.ToInt32(record["codsec"]);
            section.Description = Convert.ToString(record["dessec"]);
            section.Abbreviation = Convert.ToString(record["abrsec"]);
            return section;
        }
    }
}