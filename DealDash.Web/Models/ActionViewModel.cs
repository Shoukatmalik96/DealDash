using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDash.Web.Models
{
    public class ActionViewModel
    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }
    }
}