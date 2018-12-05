using DealDash.Data;
using DealDash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDash.Services
{
    public class CategoriesService
    {
        DealDashDataContext context = new DealDashDataContext();

        public List<Category> GetAllCategories()
        {
            return context.Category.ToList();
        }
        public Category GetCategoryByID(int ID)
        {
            return context.Category.Find(ID);
        }
        public void SaveCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAuction(Category category)
        {
            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
