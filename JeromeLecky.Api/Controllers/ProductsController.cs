using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JeromeLecky.Api.Abstract;
using JeromeLecky.Api.Data;
using JeromeLecky.Api.Models;
using Newtonsoft.Json;

namespace JeromeLecky.Api.Controllers {
    public class ProductsController : ApiController
    {
        private IProductRepository repo;

        public ProductsController() {
            this.repo = new ProductRepository();
        }

        // I can pass in an implementation of the product repository when the controller instantiated
        // instead of defining the method to retrieve data within controller, so that the dataset can be
        // injected as a dependency without needing to change the definition of the controller
        public ProductsController(IProductRepository productRepository) {
            this.repo = productRepository;
        }
        
        [HttpGet]
        public IHttpActionResult GetAll() {
            return Ok(repo.Products);
        }

        [HttpGet]
        public IHttpActionResult GetInStock() {
            return Ok(repo.Products.Where(p => p.StockStatus == Enums.StockStatus.inStock && p.StockQuantity > 0));
        }

        [HttpGet]
        public IHttpActionResult GetById(Guid id) {
            return Ok(repo.Products.Where(p => p.ProductId == id).SingleOrDefault());
        }

        [HttpPost]
        public IHttpActionResult Add(Product product) {
            // todo: Validate the incoming product object
            return Ok(repo.Add(product));
        }

        [HttpPut]
        public IHttpActionResult Change(Product product) {
            // todo: Validate the incoming product object
            return Ok(repo.Update(product));
        }

        [HttpDelete]
        public IHttpActionResult Remove(Guid id) {
            return Ok(repo.Remove(repo.Products.Where(p => p.ProductId == id).SingleOrDefault()));
        }

    }

    
}
