using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JeromeLecky.Api.Models;
using JeromeLecky.WebUI.Enums;

namespace JeromeLecky.WebUI.Models {
    public class ProductListViewModel {
        public IEnumerable<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public ProductListState State { get; set; }

        
        public string SelectedStockFilter { get; set; }
    }
}