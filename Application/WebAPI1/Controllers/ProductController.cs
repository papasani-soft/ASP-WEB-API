using App.Data;
using AppService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI1.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService productService = new ProductService();
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return productService.GetProducts();
        }
        [HttpGet]
        [ActionName("GetProducts")]
        public IHttpActionResult GetProduct(int id)
        {
            var product= productService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
  
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
           var isSave= productService.SaveProduct(product);
            if (isSave == true)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            var isUpdated = productService.UpdateProduct(product.Id, product);
            if (isUpdated == true)
                return Ok();
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var isDeleted = productService.DeleteProduct(id);
            if (isDeleted == true)
                return Ok();
            return BadRequest();
        }

    }
}
