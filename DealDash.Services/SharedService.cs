using DealDash.Data;
using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Services
{
    public class SharedService
    {
        public int SavePicture(Pictures picture)
        {
            DealDashDataContext context = new DealDashDataContext();
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }
    }
}
