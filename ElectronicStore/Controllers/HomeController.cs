using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ElectronicStoreContext _db { get; set; }

        public HomeController(ILogger<HomeController> logger, ElectronicStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Сontact()
        {
            return View();
        }
        
        public IActionResult Shop()
        {
            var products = _db.Products.Take(9).ToList();
            ViewBag.Categories  = _db.Categories.ToList();
            return View(products);
        }
        
        [HttpPost]
        public async Task<IActionResult> ShopAjax(string category = "все",string subcategory = "все")
        {
            List<Product> products;
            if (category.Contains("все") && subcategory.Contains("все"))
                products = await _db.Products.Take(9).ToListAsync();
            else
            {
                if (subcategory.Contains("все"))
                    products = await _db.Products.Where(p => p.Category.Name.ToLower().Contains(category.ToLower())).Take(9).ToListAsync();
                else
                    products = await _db.Products.Where(p => p.Subcategory.Name.ToLower().Contains(subcategory.ToLower())).Take(9).ToListAsync();
            }
            return PartialView("Partial/PartialShopTable",products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}