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
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<ProductViewModel> ProductViewModel { get; set; }
        public CategoryViewModel()
        {
            ProductViewModel = new List<ProductViewModel>();
        }
    }
}
