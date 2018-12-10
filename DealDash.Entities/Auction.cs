using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Entities
{
    public class Auction :BaseEntity
    {
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Minimum length should be 15 characters.")]
        [MaxLength(150)] //nvarchar(150)
        public string Title { get; set; }
        [Required]
        [MinLength(30, ErrorMessage = "Description length should be 250 characters.")]
        [MaxLength(255)] //nvarchar(150)
        public string Description { get; set; }
        [Required]
        [Range(100, 1000000, ErrorMessage = "Actual Amount must be within 100 - 1000000.")]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public Nullable<DateTime> EndingTime { get; set; }

        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    }
}
