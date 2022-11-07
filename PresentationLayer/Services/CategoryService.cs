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
    public class CategoryService
    {
        private readonly DataManager dataManager;
        private readonly ProductService productService;

        public CategoryService(DataManager dataManager)
        {
            this.dataManager = dataManager;
            productService = new ProductService(dataManager);
        }
        public List<CategoryViewModel> CategoryListViewModel()
        {
            var categoryList = dataManager.Categories.AllCategories();
            var categoryViewModelList = new List<CategoryViewModel>();
            foreach(var category in categoryList)
            {
                categoryViewModelList.Add(CategoryDbToViewModelById(category.Id));
            }
            return categoryViewModelList;
        }
        public CategoryViewModel CategoryDbToViewModelById(int id)
        {
            var categoryDb = dataManager.Categories.GetOneCategory(id);
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Category = categoryDb;
            //var listProductViewModels = new List<ProductViewModel>();
            foreach(var product in categoryDb.Products)
            {
                categoryViewModel.ListProductViewModels.Add(productService.ProductDbToViewModelById(product.Id));
            }
            return categoryViewModel;
        }
        public CategoryEditModel GetCategoryEditModel(int id = 0)
        {
            var categoryEditModel = new CategoryEditModel();
            if(id == 0)
            {
                return categoryEditModel;
            }
            else
            {
                Category category = dataManager.Categories.GetOneCategory(id);
                categoryEditModel.Id = category.Id;
                categoryEditModel.Name = category.Name;
                return categoryEditModel;
            }
        }
        public void SaveCategoryEditModelToDb(CategoryEditModel categoryEditModel)
        {
            Category category;
            if(categoryEditModel.Id == 0)
            {
                category = new Category();
            }
            else
            {
                category = dataManager.Categories.GetOneCategory(categoryEditModel.Id);
            }
            category.Name = categoryEditModel.Name;
            dataManager.Categories.CreateCategory(category);
        }
    }
}
