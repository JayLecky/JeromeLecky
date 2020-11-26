using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace JeromeLecky.Api.Enums {
    public enum StockStatus {
        [Description("In Stock")] inStock = 1,
        [Description("Discontinued")] discontinued = 2,
        [Description("Back Order")] backOrder = 3
    }
}