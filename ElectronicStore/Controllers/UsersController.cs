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
            if (User.IsInRole(Convert.ToString(RoleInitializer.Roles.Admin)))
                return  RedirectToAction("ControlPanel","Users");
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
    }
}