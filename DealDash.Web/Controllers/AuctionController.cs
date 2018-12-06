using DealDash.Entities;
using DealDash.Services;
using DealDash.Web.viewModels;
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
        CategoriesService categoriesService = new CategoriesService();


        public ActionResult Index()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();
            model.PageTitle = "Auction";
            model.PageDescription = "Auction Listing Page";
            return View(model);
        }
       
        public ActionResult Listing()
        {
            AuctionsListingViewModel model =new AuctionsListingViewModel();
            model.Auctions = auctionService.GetAllAuctions();
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            model.categories = categoriesService.GetAllCategories();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
          
            Auction auction = new Auction();
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            //LINQ
            var pictureIDs = model.AuctionPictures
                                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(ID => int.Parse(ID)).ToList();

            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());

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
            AuctionDetailsViewModel model = new AuctionDetailsViewModel();

            model.Auction = auctionService.GetAuctionByID(ID);

            model.PageTitle = "Auctions Details: " + model.Auction.Title;
            model.PageDescription = model.Auction.Description.Substring(0, 10);
            return View(model);
        }
    }
}