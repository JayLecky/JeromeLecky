using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using JeromeLecky.Api.Abstract;
using JeromeLecky.Api.Models;

namespace JeromeLecky.Api.Data {
    public class ProductRepository: IProductRepository {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products => context.Products;

        public bool Add(Product product) {
            try {
                context.Products.Add(product);
                if (context.SaveChanges() == 0) {
                    return true;
                }
            } catch(Exception exception) {
                Debug.WriteLine(exception);
            }
            return false;

        }

        public bool Update(Product product) {
            var entry = context.Products.Where(p => p.ProductId == product.ProductId).SingleOrDefault();

            try {
                if (entry != null) {
                    entry.Name = product.Name;
                    entry.BasePrice = product.BasePrice;
                    entry.SkuCode = product.SkuCode;
                    entry.StockQuantity = product.StockQuantity;
                    entry.StockStatus = product.StockStatus;
                    entry.Category = product.Category;

                    if (context.SaveChanges() == 0) {
                        return true;
                    }
                }
            }
            catch (Exception exception) {
                Debug.WriteLine(exception);
            }
            return false;
        }
        
        public bool Remove(Product product) {
            try {
                context.Products.Remove(product);
                if (context.SaveChanges() == 0) {
                    return true;
                }
            }
            catch (Exception exception) {
                Debug.WriteLine(exception);
            }
            return false;
        }
    }
}