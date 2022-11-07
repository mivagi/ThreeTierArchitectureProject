using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class CategoryRepository : ICategories
    {
        private readonly AppDbContent content;

        public CategoryRepository(AppDbContent content)
        {
            this.content = content;
        }
        public IEnumerable<Category> AllCategories() => content.Categories.Include(p => p.Products).ToList();
        public Category GetOneCategory(int id)
        {
            return content.Categories.Include(p => p.Products).FirstOrDefault(c => c.Id == id);
        }
        public void CreateCategory(Category category)
        {
            if(category.Id == 0)
            {
                content.Categories.Add(category);
            }
            else
            {
                content.Entry(category).State = EntityState.Modified;
                //Category newCategory = content.Categories.FirstOrDefault(p => p.Id == category.Id);
                //newCategory.Name = category.Name;
                //newCategory.Products = category.Products;
            }
            content.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            content.Categories.Remove(category);
            content.SaveChanges();
        }
    }
}
