using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JeromeLecky.Api.Enums;

namespace JeromeLecky.Api.Models {
    public class Product {
        public Guid ProductId { get; set; }
        public string SkuCode { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public StockStatus StockStatus { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
    }
}