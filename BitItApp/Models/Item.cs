using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitItApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? DueDate { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public string Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal FirstPrice { get; set; }
        public decimal SecondPrice { get; set; }
        public decimal ThirdPrice { get; set; }
        public int AskCID { get; set; }
    }
}