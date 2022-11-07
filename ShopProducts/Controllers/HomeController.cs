using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer;
using ShopProducts.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProducts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;
        private ServiceManager serviceManager;
        public HomeController(ILogger<HomeController> logger, DataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
            serviceManager = new ServiceManager(dataManager);
        }

        public IActionResult Index()
        {
            //var dir = dataManager.Categories.AllCategories();
            var cat = serviceManager.CategoryService.CategoryListViewModel();
            return View(cat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
