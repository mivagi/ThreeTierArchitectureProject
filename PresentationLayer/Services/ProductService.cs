using BusinessLayer;
using DataLayer.Models;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class ProductService
    {
        private readonly DataManager dataManager;

        public ProductService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public List<ProductViewModel> CategoryListViewModel()
        {
            var productList = dataManager.Products.AllProducts();
            var productViewModelList = new List<ProductViewModel>();
            foreach (var product in productList)
            {
                productViewModelList.Add(ProductDbToViewModelById(product.Id));
            }
            return productViewModelList;
        }
        public ProductViewModel ProductDbToViewModelById(int id)
        {
            var categoryDb = dataManager.Products.GetOneProduct(id);
            var categoryViewModel = new ProductViewModel();
            categoryViewModel.Product = categoryDb;
            return categoryViewModel;
        }
        public ProductEditModel GetProductEditModel(int id = 0)
        {
            ProductEditModel productEditModel = new ProductEditModel();
            if (id == 0)
            {
                return productEditModel;
            }
            else
            {
                Product product = dataManager.Products.GetOneProduct(id);
                productEditModel.Id = product.Id;
                productEditModel.Name = product.Name;
                productEditModel.Price = product.Price;
                productEditModel.CategoryId = product.CategoryId;
                return productEditModel;
            }
        }
        public void SaveProductEditModelToDb(ProductEditModel productEditModel)
        {
            Product product;
            if (productEditModel.Id == 0)
            {
                product = new Product();
            }
            else
            {
                product = dataManager.Products.GetOneProduct(productEditModel.Id);
            }
            product.Name = productEditModel.Name;
            product.Price = productEditModel.Price;
            product.CategoryId = productEditModel.CategoryId;
            dataManager.Products.CreateProduct(product);
        }
    }
}
