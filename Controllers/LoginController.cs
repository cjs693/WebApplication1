using DataLibrary.BusinessLogics;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            if(ModelState.IsValid)
            {
                int UserCredentialId = LoginProcessor.IsClientExists(model.Username, model.Password);
                if (UserCredentialId != 0)//if the user has an account we are going to the Client page
                {
                    cookie["UserID"] = UserCredentialId.ToString();
                    
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Client");
                }
                    
                else
                    return RedirectToAction("SignUp", "ClientRegistration");
                
            }
            return View();
        }
    }
}