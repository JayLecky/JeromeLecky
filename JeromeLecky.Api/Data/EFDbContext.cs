using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JeromeLecky.Api.Models;

namespace JeromeLecky.Api.Data {
    public class EFDbContext : DbContext {
        public DbSet<Product> Products { get; set; }
    }
}