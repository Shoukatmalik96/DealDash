using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Entities
{
    public class AuctionPicture:BaseEntity
    {
        public int AuctionID { get; set; }
        public int PictureID { get; set; }
        public virtual Pictures Picture { get; set; }
    }
}
