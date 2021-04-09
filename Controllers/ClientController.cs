using DataLibrary.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string UserCredentialsId = cookie["UserID"];
            String ClientName = ClientProfileProcessor.GetClientName(Int32.Parse(UserCredentialsId));
            ViewBag.Message = ClientName;

            return View();
        }


    }
}