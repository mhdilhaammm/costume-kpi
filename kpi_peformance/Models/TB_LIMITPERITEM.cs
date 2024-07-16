using System;
using System.ComponentModel.DataAnnotations;

namespace LogKPI.Models
{
    public class TB_LIMITPERITEM
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Create_DatePerItem { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
    }
}