using System.IO;
using System.Threading.Tasks;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using ElectronicStore.Services;
using ElectronicStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        private ElectronicStoreContext _db { get; set; }
        private UserManager<User> UserManager { get; set; }
        private RoleManager<IdentityRole> RoleManager { get; set; }
        private IHostEnvironment _environment { get; set; }
        private UploadService UploadService { get; set; }

        public ProductController(ElectronicStoreContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IHostEnvironment environment, UploadService uploadService)
        {
            _db = db;
            UserManager = userManager;
            RoleManager = roleManager;
            _environment = environment;
            UploadService = uploadService;
        }

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Subcaegory = await _db.Subcategories.ToListAsync();
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct(ViewModelProduct model)
        {
            if (ModelState.IsValid) 
            {
                var path = Path.Combine(_environment.ContentRootPath + $"/wwwroot/images/{model.CategoryId}");
                var photoPath = $"images/{model.CategoryId}/{model.File.FileName}";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                await UploadService.Upload(path, model.File.FileName, model.File);

                #region временный

                var categoryId = await _db.Subcategories.FirstOrDefaultAsync(s => s.Id == model.SubcategoryId);
                model.CategoryId = categoryId.CategoryId;

                #endregion

                model.ImgPath = photoPath;
                model.AuthorId = UserManager.GetUserId(User);
                var product = new Product(model);
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("ControlPanel", "Users");
            }
            ViewBag.Subcaegory = await _db.Subcategories.ToListAsync();
            return View(model);
        }
    }
}