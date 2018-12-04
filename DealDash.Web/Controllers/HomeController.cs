using DealDash.Services;
using DealDash.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDash.Web.Controllers
{
    public class HomeController : Controller
    {
        ActionViewModel vModel = new ActionViewModel();
        AutionsService auctionService = new AutionsService();

        public ActionResult Index()
        {

            var allauctions = auctionService.GetAllAuctions();
            var promotedAuctions =auctionService.PromotedAuctions();
            vModel.AllAuctions = allauctions;
            vModel.PromotedAuctions = promotedAuctions;
            
            return View(vModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}