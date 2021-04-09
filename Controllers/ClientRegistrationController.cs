using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogics;

namespace FinalProject.Controllers
{
    public class ClientRegistrationController : Controller
    {
        // GET: ClientRegistration

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult SignUp(ClientRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                /*If client already has an account and tries to sign up again*/
                HttpCookie cookie = new HttpCookie("UserInfo");
                int UserCredentialId = RegistrationProcessor.IsClientExists(model.Username, model.Password);
                if (UserCredentialId != 0) //If Client has an acount
                {
                    
                    return RedirectToAction("Login", "Login");
                    
                }

                else 
                {
                    int recordsCreated = RegistrationProcessor.CreateClient(model.Username, model.Password);
                    UserCredentialId = RegistrationProcessor.IsClientExists(model.Username, model.Password);
                    cookie["UserID"] = UserCredentialId.ToString();
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Create", "ClientProfile");
                }


            }
            return View();
        }
    }
}