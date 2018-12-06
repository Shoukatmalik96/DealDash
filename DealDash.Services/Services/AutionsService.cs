using DealDash.Data;
using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Services
{
    public class AutionsService
    {
        DealDashDataContext context = new DealDashDataContext();

        public List<Auction> PromotedAuctions()
        {
            return context.Auctions.Take(4).ToList();
        }
        public List<Auction> GetAllAuctions()
        {
            return context.Auctions.ToList();
        }
        public Auction GetAuctionByID(int ID)
        {
            return context.Auctions.Find(ID);
        }
        public void SaveAuction(Auction auction)
        {
            context.Auctions.Add(auction);
            context.SaveChanges();
        }
        public void UpdateAuction(Auction auction)
        {
            context.Entry(auction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAuction(Auction auction)
        {
            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
