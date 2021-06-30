using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelsLibrary;
using Project1.Models;
using RepositoryLayer;
using System.Web;
using Newtonsoft.Json;

namespace Project1.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;
        private readonly IMethods _methods;
        readonly Project1Db db = new();



        public AppController(IMethods methods, ILogger<AppController> logger)
        {
            this._methods = methods;
            this._logger = logger;
        }



       
        public IActionResult Create()
        {
            return View("CreateCustomer");
        }

        public IActionResult CreateCustomer(Customers c)
        {
            return View("VerifyCreateCustomer", c);
        }

        public IActionResult CreateNewCustomer(Customers c)
        {
            _methods.RegisterCustomer(c);

            HttpContext.Session.SetString("firstName", c.CustomerFirstName);
            HttpContext.Session.SetString("lastName", c.CustomerLastName);
            HttpContext.Session.SetInt32("id", c.CustomerID);

            return RedirectToAction("MainMenu", c); 
        }




        public IActionResult PreLogin()
        {
            return View("Login");
        }

        public IActionResult Login(Customers c)
        {
                var obj = db.Customers.Where(a => a.CustomerID.Equals(c.CustomerID)).FirstOrDefault(); 

                if(obj != null)
                {
                    HttpContext.Session.SetString("firstName", obj.CustomerFirstName);
                    HttpContext.Session.SetString("lastName", obj.CustomerLastName);
                    HttpContext.Session.SetInt32("id", obj.CustomerID);

                    return RedirectToAction("MainMenu", obj);
                }

            ModelState.AddModelError("Error", "Login Failed! If you need to create an account go back to the home screen and select Create A New Account");
            return View("Login");
        }







        public IActionResult MainMenu(Customers c)
        {
            return View(c);
        }






        public IActionResult LocationsListShop()
        {
           
            return View(db.Locations);
        }

        public IActionResult Store(int id)
        {
            HttpContext.Session.SetInt32("locationId", id);

            var join = db.Inventory.Join(db.Products, i => i.Product.ProductID, p => p.ProductID, (i, p) => new StoreModel
            { LocationID = i.Location.LocationID, ProductID = p.ProductID, ProductName = p.ProductName, ProductPrice = p.ProductPrice, ProductDescription = p.ProductDescription, InventoryAmount = i.InventoryAmount });

            //var obj = join.Where(a => a.LocationID.Equals(id)).FirstOrDefault();

            return View(join);

            //return View(db.Products);
        }





        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {

            var obj = db.Products.Where(a => a.ProductID.Equals(id)).FirstOrDefault();
            ShoppingCart.shoppingCartProductList.Add(obj);
            ShoppingCart.shoppingCartLocationList.Add((int)HttpContext.Session.GetInt32("locationId"));

            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            int index = _methods.FindProductIndex(id);
            ShoppingCart.shoppingCartProductList.RemoveAt(index);
            ShoppingCart.shoppingCartLocationList.RemoveAt(index);

            return RedirectToAction("Cart");
        }





        public IActionResult Checkout()
        {
            int i = (int)HttpContext.Session.GetInt32("id");
            _methods.CreateAndSaveOrder(i);
            ShoppingCart.shoppingCartProductList.Clear();

            return View("SuccessfulCheckout");
        }

        public IActionResult SuccessfulCheckout()
        {
            return View();
        }






        public IActionResult CustomerOrderHistory()
        {
            return View(db.Orders);
        }






        public IActionResult LocationsListHistory()
        {

            return View(db.Locations);
        }

        public IActionResult StoreHistory()
        {
            return View();
        }






        public async Task<IActionResult> CustomerSearch(string searchString)
        {
            var customers = from m in db.Customers
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerFirstName.Contains(searchString) || s.CustomerLastName.Contains(searchString));
            }

            return View(await customers.ToListAsync());
        }





        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            ShoppingCart.shoppingCartProductList.Clear();
            return View("SuccessfulLogout");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
