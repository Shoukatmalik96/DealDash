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

        public List<Auction> serchAuctions(int? categoryID, string searchTerm, int? pageNo,int pageSize)
        {
            var auctions = context.Auctions.AsQueryable();

            if (categoryID.HasValue && categoryID.Value>0)
            {
                auctions = context.Auctions.Where(x => x.CategoryID == categoryID.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
               auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            //pageNo = pageNo.HasValue ? pageNo.Value : 1;

            //Skip Auctions Record
            var skipCount = (pageNo.Value - 1) * pageSize;

            // we want to show latest on the top so we apply Order by descending
            return auctions.OrderByDescending(x=>x.CategoryID).Skip(skipCount).Take(pageSize).ToList();
        }

        public List<Auction> PromotedAuctions()
        {
            return context.Auctions.Take(4).ToList();
        }
        public int GetAutionCount()
        {
            return context.Auctions.Count();
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
