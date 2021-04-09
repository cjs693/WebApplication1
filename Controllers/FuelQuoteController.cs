using DataLibrary.BusinessLogics;
using DataLibrary.Module;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class FuelQuoteController : Controller
    {
        // GET: FuelQuote

        public ActionResult Generate()
        {

           // model.DeliveryAddress = ClientProfileProcessor.GetClientName(model.UserCredentialsID);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generate(FuelQuoteModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    model.UserCredentialsID = Int32.Parse(cookie["UserID"]);

                }
                model.DeliveryAddress = ClientProfileProcessor.GetClientAddress(model.UserCredentialsID);
                int RateHistory = FuelQuoteFormProcessor.IsQuoteExisted(model.UserCredentialsID);
                model.SuggestedPrice = PriceModule.PriceCalculation(1.5, ClientProfileProcessor.GetClientState
                (model.UserCredentialsID), RateHistory,model.Gallons);
                model.TotalAmountDue = model.SuggestedPrice * model.Gallons;
                FuelQuoteFormProcessor.InsertFuelQuoteInformation(model.Gallons, model.DeliveryAddress, 
                model.DeliveryDate, model.SuggestedPrice, model.TotalAmountDue, model.UserCredentialsID);
                
                return RedirectToAction("Index", "Client");
            }
            return View();
        }
        public ActionResult History()
        {
            return View();
        }
    }
}