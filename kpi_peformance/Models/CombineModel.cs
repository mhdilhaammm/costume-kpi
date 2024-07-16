using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogKPI.Models
{
    public class CombineModel
    {
        public TB_KPI CreateKPI { get; set; }
        public TB_LIMITOVERALL CreateOverAll { get; set; }
        public TB_LIMITPERITEM CreatePerItem { get; set; }

        public List<TB_KPI> ListKPI { get; set; }
        public List<TB_LIMITOVERALL> ListOverAll { get; set; }
        public List<TB_LIMITPERITEM> ListPerItem { get; set; }
    }
}