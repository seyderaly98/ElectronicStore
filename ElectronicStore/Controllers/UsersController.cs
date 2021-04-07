using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using ElectronicStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Controllers
{
    public class UsersController : Controller
    {
        private ElectronicStoreContext _db { get; set; }
        private UserManager<User> UserManager { get; set; }
        private RoleManager<IdentityRole> RoleManager { get; set; }

        public UsersController(ElectronicStoreContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        
        public async Task<IActionResult> ControlPanel(string category = "все",string subcategory = "все")
        {
            List<Product> products;
            if (category.Contains("все") && subcategory.Contains("все"))
                products = await _db.Products.ToListAsync();
            else
            {
                if (subcategory.Contains("все") )
                    products = await _db.Products.Where(p => p.Category.Name.ToLower().Contains(category.ToLower())).ToListAsync();
                else
                    products = await _db.Products.Where(p => p.Subcategory.Name.ToLower().Contains(subcategory.ToLower())).ToListAsync();
            }
            ViewBag.Categories = _db.Categories.ToList();
            return View(products);
        }
        
        [HttpPost]
        public async Task<IActionResult> ControlPanelAjax(string category = "все",string subcategory = "все",ShopStatus status = ShopStatus.None)
        {
            List<Product> products;
            if (status == ShopStatus.None)
            {
                if (category.Contains("все") && subcategory.Contains("все"))
                    products = await _db.Products.ToListAsync();
                else
                {
                    if (subcategory.Contains("все"))
                        products = await _db.Products.Where(p => p.Category.Name.ToLower().Contains(category.ToLower()))
                            .ToListAsync();
                    else
                        products = await _db.Products
                            .Where(p => p.Subcategory.Name.ToLower().Contains(subcategory.ToLower())).ToListAsync();
                }
            }
            else
            {
                if (category.Contains("все") && subcategory.Contains("все"))
                {
                    products = await _db.Shops.Where(p => p.Status == status).Select(p=>p.Product).ToListAsync();
                }
                else
                {
                    if (subcategory.Contains("все"))
                        products = await _db.Shops.Where(p => p.Status == status).Select(p=>p.Product).Where(p => p.Category.Name.ToLower().Contains(category.ToLower()))
                            .ToListAsync();
                    else
                        products = await _db.Shops.Where(p => p.Status == status).Select(p=>p.Product)
                            .Where(p => p.Subcategory.Name.ToLower().Contains(subcategory.ToLower())).ToListAsync();
                }
            }

            return PartialView("Partial/PartialControlPanel", products);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(string categoryName)
        {
            if (await _db.Categories.AnyAsync(c=>c.Name.ToLower() == categoryName.ToLower())) return Json(false);
            Category category = new Category() {Name = categoryName};
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return Json(true);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddSubcategory(int categoryId, string subcategoryName)
        {
            if (!await _db.Categories.AnyAsync(c=>c.Id == categoryId)) return Json(false);
            if (await _db.Subcategories.AnyAsync(c=>c.Name.ToLower() == subcategoryName.ToLower())) return Json(false);

            Subcategory subcategory = new Subcategory() {Name = subcategoryName,CategoryId = categoryId};
            await _db.Subcategories.AddAsync(subcategory);
            await _db.SaveChangesAsync();
            return Json(true);
        }

        
    }
}