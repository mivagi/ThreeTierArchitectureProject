using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> AllProducts();
        Product GetOneProduct(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
