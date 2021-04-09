using DataLibrary.BusinessLogics;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ClientProfileController : Controller
    {
        // GET: ClientProfile
       /*public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult Create()
        {
            ViewBag.Message = "Client Profile is Created";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientProfileModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if(cookie != null)
                {
                    model.UserCredentialsID =Int32.Parse(cookie["UserID"]);
                    
                }
                ClientProfileProcessor.InsertClientInformation(model.FullName, model.Address1, model.Address2, model.City, model.State, model.Zipcode, model.UserCredentialsID);
                return RedirectToAction("Index","Client");
            }
            return View();
        }
    }
}