using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ЛР_1.DAL.Data;
using ЛР_1.Extensions;
using ЛР_1.Models;

namespace ЛР_1.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private string cartKey = "Cart";
        private Cart _cart;
        public CartController(ApplicationDbContext context,Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Index()
        {

            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)

        {

            var item = _context.Students.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);  
            }
            return Redirect(returnUrl);
        }
        public IActionResult Delete(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
