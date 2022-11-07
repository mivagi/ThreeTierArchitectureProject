using BusinessLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class ServiceManager
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;

        public ServiceManager(DataManager dataManager)
        {
            categoryService = new CategoryService(dataManager);
            productService = new ProductService(dataManager);
        }
        public CategoryService CategoryService { get { return categoryService; } }
        public ProductService ProductService { get { return productService; } }
    }
}
