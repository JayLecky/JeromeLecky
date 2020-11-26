using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JeromeLecky.Api.Models;

namespace JeromeLecky.Api.Abstract {
    // I use an interface which is expected to return an IEnumerable of Product objects,
    // meaning I am free to change the method of populating the datasource. I can quickly swap 
    // from using the traditional database retrieval method to an adhoc collection of Product 
    // objects for testing/mocking purposes
    public interface IProductRepository {
        IEnumerable<Product> Products { get; }

        bool Add(Product product);
        bool Update(Product product);
        bool Remove(Product product);
    }
}