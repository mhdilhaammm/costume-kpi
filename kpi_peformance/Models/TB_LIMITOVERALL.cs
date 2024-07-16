using System;
using System.ComponentModel.DataAnnotations;

namespace LogKPI.Models
{
    public class TB_LIMITOVERALL
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Create_DateOvr { get; set; }
        public string Name { get; set; }
        public float Limit_Ovr{ get; set; }
    }
}