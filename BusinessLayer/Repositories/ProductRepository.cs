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
    public class ProductRepository : IProducts
    {
        private readonly AppDbContent content;

        public ProductRepository(AppDbContent content)
        {
            this.content = content;
        }
        public IEnumerable<Product> AllProducts() => content.Products.Include(c => c.Category).ToList();
        public Product GetOneProduct(int id)
        {
            return content.Products.FirstOrDefault(c => c.Id == id);
        }
        public void CreateProduct(Product product)
        {
            if(product.Id == 0)
            {
                content.Products.Add(product);
            }
            else
            {
                content.Entry(product).State = EntityState.Modified;
            }
        }

        public void DeleteProduct(Product product)
        {
            content.Products.Remove(product);
        }
    }
}
