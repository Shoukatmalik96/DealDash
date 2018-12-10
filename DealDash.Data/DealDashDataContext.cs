using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Data
{
    public class DealDashDataContext:DbContext
    {
        public DealDashDataContext():base("name=DealDashConnectionString")
        {

        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionPicture> AuctionPicture { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
    }

}
