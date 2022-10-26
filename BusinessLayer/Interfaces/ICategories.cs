using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> AllCategories();
        Category GetOneCategory(int id);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
