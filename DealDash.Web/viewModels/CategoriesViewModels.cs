using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDash.Web.viewModels
{
    public class CategoriesListingViewModel : PageViewModel
    {
        public List<Category> categories { get; set; }
    }
}