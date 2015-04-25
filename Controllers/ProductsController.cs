using FootballOdds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballOdds.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        // GET: Products
        
        public ActionResult Index()
        {
            var repo = new ProductRepository();
            return View(repo.All());
        }
        [Route("{category}")]
        public string ShowCategory(string category) {

            return "this is the products in the "+category+" category";
        }
        [Route("{category}/{id:int}")]
        public string Details(string category,int id,string format = null) 
        {
            var repo = new ProductRepository();
            if (format == "json") 
            {
                Json("{name:'ers'}");
            }
            else if(format =="xml"){
           
            }
            return category;
        }
        [Route("~/for-sale/{category}")]
        public string cpu(string category) {
            return "this is the cpu : " + category;
        }
    }
}