using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class CategoryEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<ProductViewModel> ListProductViewModels { get; set; }
        public CategoryViewModel()
        {
            ListProductViewModels = new List<ProductViewModel>();
        }
    }
}
