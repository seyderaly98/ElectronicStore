using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}