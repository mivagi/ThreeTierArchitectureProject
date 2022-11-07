using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Services;

namespace ShopProducts.Controllers
{
    public class EditController : Controller
    {
        private ServiceManager serviceManager;
        public EditController(DataManager dataManager)
        {
            serviceManager = new ServiceManager(dataManager);
        }
        public IActionResult IndexEdit()
        {
            return View();
        }
    }
}
