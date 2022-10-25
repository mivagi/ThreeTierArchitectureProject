using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DbObject
    {
        public static void Initial(AppDbContent content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.Add(new Category { Name = "Напитки"});
                content.Categories.Add(new Category { Name = "Хлебо-булочные изделия" });
            }
            content.SaveChanges();
            if (!content.Products.Any())
            {
                content.Products.Add(new Product { Name = "Яблочный сок", Price = 150, CategoryId = 1});
                content.Products.Add(new Product { Name = "Пиво", Price = 120, CategoryId = 1 });
                content.Products.Add(new Product { Name = "Хлеб ржаной", Price = 50, CategoryId = 2});
                content.Products.Add(new Product { Name = "Батон нарезной", Price = 40, CategoryId = 2});
            }
            content.SaveChanges();
        }
    }
}
