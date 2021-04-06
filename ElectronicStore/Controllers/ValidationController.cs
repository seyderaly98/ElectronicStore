using System.Threading.Tasks;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Controllers
{
    public class ValidationController
    {
        private ElectronicStoreContext _db;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public ValidationController(ElectronicStoreContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<bool> CheckEmail(string email)
        {
            return !await _db.Users.AnyAsync(u => u.Email == email);
        }
        
    }
}