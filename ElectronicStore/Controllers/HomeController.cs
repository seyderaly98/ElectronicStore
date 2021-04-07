using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using ElectronicStore.ViewModel;
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
        
        public async Task<IActionResult> Shop(int page = 1)
        {
            int pageSize = 9; // количество объектов на страницу
            List<Product> phonesPerPages= await _db.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems= _db.Products.Count()};
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = phonesPerPages };
            ViewBag.Categories  = _db.Categories.ToList();
            return View(ivm);
        }
        
        [HttpPost] // Рефакторинг
        public async Task<IActionResult> ShopAjax(int page = 1, string category = "все",string subcategory = "все")
        {
            List<Product> products;
            if (category.Contains("все") && subcategory.Contains("все"))
                products = await _db.Products.ToListAsync();
            else
            {
                if (subcategory.Contains("все"))
                    products = await _db.Products.Where(p => p.Category.Name.ToLower().Contains(category.ToLower())).ToListAsync();
                else
                    products = await _db.Products.Where(p => p.Subcategory.Name.ToLower().Contains(subcategory.ToLower())).ToListAsync();
            }
            
            int pageSize = 9; // количество объектов на страницу
            List<Product> phonesPerPages=  products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems= products.Count()};
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = phonesPerPages };
            return PartialView("Partial/PartialShopTable",ivm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}