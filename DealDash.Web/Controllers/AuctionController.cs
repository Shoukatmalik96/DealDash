﻿using DealDash.Entities;
using DealDash.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDash.Web.Controllers
{
    public class AuctionController : Controller
    {
        AutionsService auctionService = new AutionsService();

     
        public ActionResult Index()
        {
            var allAuctions = auctionService.GetAllAuctions();
           
            if (Request.IsAjaxRequest())
            {
                return PartialView(allAuctions);
            }
            else
            {
                return View(allAuctions);
            }
        }

        public ActionResult Listing()
        {
            var allAuctions = auctionService.GetAllAuctions();
            return View(allAuctions);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            auctionService.SaveAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var auction = auctionService.GetAuctionByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            auctionService.UpdateAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var auction = auctionService.GetAuctionByID(ID);
            return View(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            auctionService.DeleteAuction(auction);
            return RedirectToAction("Listing");
        }
        public ActionResult Details(int ID)
        {
            var auction = auctionService.GetAuctionByID(ID);
            return View(auction);
        }
    }
}