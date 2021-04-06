﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStore.Models;
using ElectronicStore.Models.Data;
using ElectronicStore.Services;
using ElectronicStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ElectronicStore.Controllers
{
    public class AccountController : Controller
    {
         #region поле 
        UserManager<User> _userManager { get; set; }
        RoleManager<IdentityRole> _roleManager { get; set; }
        SignInManager<User> _signInManager { get; set; }
        ElectronicStoreContext _db { get; set; }
        IHostEnvironment _environment { get; set; }
        
        #endregion

        #region конструктор
        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, ElectronicStoreContext db, IHostEnvironment environment)
         {
             _userManager = userManager;
             _roleManager = roleManager;
             _signInManager = signInManager;
             _db = db;
             _environment = environment;
         }
       
        #endregion
        
        #region actions
        
        /// <summary>
        /// Авторизация  
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }
        
        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                User userAuthorizing = _db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (userAuthorizing != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(userAuthorizing, model.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("","Неверный пароль или логин пользователя");
            }
            return View(model);
        }
        
        /// <summary>
        /// Регистрация 
        /// </summary>
        /// <returns></returns>
        public IActionResult Regist()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }
        
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model">Данные для регистрации пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Regist(Register model)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User(model);
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, Convert.ToString(RoleInitializer.Roles.Client));
                    await _db.SaveChangesAsync();
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(String.Empty, error.Description);
            }
            return View(model);
        }
        
        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
       
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        
        #endregion

    }
}