using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using JeromeLecky.Api.Enums;
using JeromeLecky.Api.Models;
using JeromeLecky.WebUI.Enums;
using JeromeLecky.WebUI.Models;
using Newtonsoft.Json;

namespace JeromeLecky.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private string BaseUrl = "https://localhost:44313";
        ProductListViewModel model = new ProductListViewModel();

        public async Task<ActionResult> AllProducts() {            
            using (var client = new HttpClient()) {
                

                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await client.GetAsync($"api/Products/GetAll");
                //$"api/Products/GetInStock

                if (resp.IsSuccessStatusCode) {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    model.Products = JsonConvert.DeserializeObject<List<Product>>(result);
                    model.State = ProductListState.read;
                    model.SelectedStockFilter = "0";
                    TempData["StockFilter"] = 0;
                }

            };
            return View("ProductList", model);
        }

        public async Task<ActionResult> InStockProducts() {            
            using (var client = new HttpClient()) {
                //string stockStatus = 

                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await client.GetAsync($"api/Products/GetInStock");

                if (resp.IsSuccessStatusCode) {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    model.Products = JsonConvert.DeserializeObject<List<Product>>(result);
                    model.State = ProductListState.read;
                    model.SelectedStockFilter = "1";
                    TempData["StockFilter"] = 1;
                }

            };
            return View("ProductList", model);
        }

        public async Task<ActionResult> SelectProduct(Guid productId) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var route = (TempData["StockFilter"].ToString() == "0") ? $"api/Products/GetInstock" : $"api/Products/GetAll";

                HttpResponseMessage resp = await client.GetAsync(route);

                if (resp.IsSuccessStatusCode) {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    model.Products = JsonConvert.DeserializeObject<List<Product>>(result);
                    model.SelectedProduct = model.Products.Where(m => m.ProductId == productId).SingleOrDefault();
                    model.State = ProductListState.update;
                }

            };
            return View("ProductList", model);
        }

        // This method opens the Product Modal with a new instance of the Product object
        public async Task<ActionResult> NewProduct(Guid productId) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var route = (TempData["StockFilter"].ToString() == "0") ? $"api/Products/GetInstock" : $"api/Products/GetAll";
                HttpResponseMessage resp = await client.GetAsync(route);

                if (resp.IsSuccessStatusCode) {
                    Product newProduct = new Product();
                    newProduct.ProductId = productId;
                    var result = resp.Content.ReadAsStringAsync().Result;
                    model.Products = JsonConvert.DeserializeObject<List<Product>>(result);
                    model.SelectedProduct = newProduct;
                    model.State = ProductListState.create;
                }
            };
            return View("ProductList", model);
        }

        [System.Web.Http.HttpPut]
        public async Task<ActionResult> Update(ProductListViewModel model) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var data = new StringContent(JsonConvert.SerializeObject(model.SelectedProduct), Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await client.PutAsync($"api/Products/Change", data);

                if (resp.IsSuccessStatusCode) {
                    // I could do further processing based on the success of the update
                }
            };
            var action = (TempData["StockFilter"].ToString() == "1") ? "InStockProducts" : $"AllProducts";
            return RedirectToAction(action);
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Create(ProductListViewModel model) {
           using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //model.SelectedProduct.ProductId = 
                
                var data = new StringContent(JsonConvert.SerializeObject(model.SelectedProduct), Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await client.PostAsync($"api/Products/Add", data);

                if (resp.IsSuccessStatusCode) {
                    // I could do further processing based on the success of the update
                }

               
            };
            var action = (TempData["StockFilter"].ToString() == "1") ? "InStockProducts" : $"AllProducts";
            return RedirectToAction(action);
        }


        [System.Web.Http.HttpDelete]
        public async Task<ActionResult> Delete(Guid productId) {

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await client.DeleteAsync($"api/Products/Remove/{productId}");

                if (resp.IsSuccessStatusCode) {
                    // I could do further processing based on the success of the deletion
                }

            };
            var action = (TempData["StockFilter"].ToString() == "1") ? "InStockProducts" : $"AllProducts";
            return RedirectToAction(action);
        }

    }
}