using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LogKPI.Models
{
    public class TB_KPI
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        [Remote("IsDateUnique", "Validation", ErrorMessage = "The datetime is existing")]
        public DateTime Ship_date { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Input_Date { get; set; }
        public int Num_BL { get; set; }
        public int Num_Dec { get; set; }
        public int DE { get; set; }
        public int HS_CodeErr { get; set; }
        public int CO_Err { get; set; }
        public int Quantity { get; set; }
        public int Val_Err { get; set; }
        public float Sum_Err { get; set; }
        public int SUM { get; set; }
        public float CF { get; set; }
        public float TF { get; set; }
        public float OP { get; set; }
    }
}