using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ElectronicStore.Controllers
{
    public class ShopController : Controller
    {
        private ElectronicStoreContext _db { get; set; }
        private UserManager<User> UserManager { get; set; }

        public ShopController(ElectronicStoreContext db, UserManager<User> userManager)
        {
            _db = db;
            UserManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddShoppingCart(int productId)
        {
            if (!_db.Products.Any(p => p.Id == productId)) return Json(false);
            
            Shop shop = new Shop(UserManager.GetUserId(User),productId);
            await _db.Shops.AddAsync(shop);
            await _db.SaveChangesAsync();
            ViewBag.ControlPanel = true;
            return Json(true);
        }

        public async Task<IActionResult> ControlPanel()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }
    }
}