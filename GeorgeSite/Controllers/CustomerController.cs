using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeorgeSite.Models.Data;
using GeorgeSite.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeorgeSite.Controllers
{
    public class CustomerController : Controller
    {
        CartCollection CartCollection;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IRepositoryWrapper context;
        private string _role;
        private IConfiguration _configuration;

        public CustomerController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IRepositoryWrapper context, IConfiguration configuration)
        {
            CartCollection = new CartCollection();
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.context = context;
            _configuration = configuration;
        }

        public IActionResult Cart(int id)
        {
            if (User.Identity.Name == string.Empty)
            {
                return RedirectToAction("Account", "Register");
            }
            var i = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var cart = CartCollection.shoppingCarts.Where(s => s.UserId == i.Id).FirstOrDefault();
            if (cart == null)
            {
                cart = new ShoppingCart(i.Id, CartCollection.shoppingCarts);
            }
            var item = context.ItemRepository.GetById(id);
            cart.Items.Add(item);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            if (User.Identity.Name == string.Empty)
            {
                return RedirectToAction("Account", "Register");
            }
            var i = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var cart = CartCollection.shoppingCarts.Where(s => s.UserId == i.Id).FirstOrDefault();
            if (cart == null)
            {
                cart = new ShoppingCart(i.Id, CartCollection.shoppingCarts);
            }
            return View(cart);
        }

        //[HttpPost]
        //public IActionResult Checkout()
        //{
        //    return View();
        //}

       
        [HttpGet]
        public IActionResult ClearCart(int id)
        {

            var i = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var cart = CartCollection.shoppingCarts.Where(s => s.UserId == i.Id).FirstOrDefault();
            CartCollection.shoppingCarts.Remove(cart);
             return RedirectToAction("Checkout", "Customer");
        }
    }
}