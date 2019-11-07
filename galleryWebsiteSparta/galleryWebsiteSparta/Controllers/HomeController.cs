using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using galleryWebsiteSparta.Models;

namespace galleryWebsiteSparta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LoggedIn = false;
            List<Product> products = new List<Product>();
            using (var db = new GalleryWebsiteDbModel())
            {
                products = db.Products.ToList();
            }
            return View(products);
        }

        [HttpGet]
        public ActionResult Products(int? id)
        {
            List<Product> products = new List<Product>();
            //gets all the products
            if (id == null)
            {
                using (var dbc = new GalleryWebsiteDbModel())
                {
                    products = dbc.Products.ToList();
                }
            }
            //gets one
            else
            {
                using (var dbc = new GalleryWebsiteDbModel())
                {
                    Product product = dbc.Products.Find(id);

                    if (product != null)
                    {

                        products.Add(product);
                    }
                    else
                    {
                        products = null;
                    }
                }
            }

            return View(products);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            string message = "";

            using (var db = new GalleryWebsiteDbModel())
            {
                var ExisitingUser = db.Users.Where(u => u.Email == login.UserEmail).FirstOrDefault();
                if (ExisitingUser != null)
                {
                    string roles = "";
                    var rememberMe = false;

                    int timeout = rememberMe ? 525600 : 30;
                    var ticket = new FormsAuthenticationTicket(1, login.UserEmail, DateTime.Now, DateTime.Now.AddMinutes(timeout), rememberMe, roles);
                    //var ticket = new FormsAuthenticationTicket(login.UserEmail, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    FormsAuthentication.SetAuthCookie(login.UserEmail, rememberMe);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    Session["AttemptFrom"] = null;
                    Session["Attempts"] = null;
                    Session["LoggedIn"] = true;
                }
            }

            ViewBag.Email = login.UserEmail;
            ViewBag.Password = login.UserPassword;
            ViewBag.Message = message;
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}