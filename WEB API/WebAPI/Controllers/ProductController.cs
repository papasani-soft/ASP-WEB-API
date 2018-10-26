using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private List<Product> products = new List<Product>()
        {
            new Product{ Id=1,Name="T shirt",Price=26.5M,Qty=5},
            new Product{ Id=2,Name="T shirt 2",Price=12.6M,Qty=2}
        };
        public IEnumerable<Product> Get()
        {
            return products.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var product = products.Where(x => x.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
