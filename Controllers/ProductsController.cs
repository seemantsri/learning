using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController
    {
        Products[] products = new Products[]
        {
            new Products {Code = "014600301", Description = "BARILLA FARINA 1 KG", Um = "PZ", PcCart = 24, NetWeight = 1, Price = 1.09 },
            new Products {Code = "013500121", Description = "BARILLA PASTA GR.500 N.70 1/2 PENNE", Um = "PZ", PcCart = 30, NetWeight = 0.5, Price = 1.3 },
            new Products {Code = "007686402", Description = "FINDUS FIOR DI NASELLO 300 GR", Um = "PZ", PcCart = 8, NetWeight = 0.3, Price = 6.46 },
            new Products {Code = "057549001", Description = "FINDUS CROCCOLE 400 GR", Um = "PZ", PcCart = 12, NetWeight = 0.4, Price = 5.97 }
        };

        [HttpGet]
        public IEnumerable<Products> ListAllProducts()
        {
            return products;
        }

        [HttpGet("code/{codart}")]
        public IEnumerable<Products> ListProductsByCode(string codart)
        {
             IEnumerable<Products> retVal =
                from g in products 
                where g.Code.Equals(codart) 
                select g;

            return retVal;

        }

        [HttpGet("description/{desart}")]
        public IEnumerable<Products> ListProductsByDescription(string desart)
        {
            IEnumerable<Products> retVal = 
                from g in products
                where g.Description.ToUpper().Contains(desart.ToUpper())
                orderby g.Code
                select g;
                
            return retVal;
            
        }
    }
}