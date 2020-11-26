using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace JeromeLecky.WebUI.Enums {
    public enum ProductListState {
        [Description("Read")] read = 0,
        [Description("Update")] update = 1,
        [Description("Create")] create = 2,
        [Description("Delete")] delete = 3,

    }
}