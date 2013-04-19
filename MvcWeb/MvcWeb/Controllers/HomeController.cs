using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

using MvcWeb.Filters;
using MvcWeb.Service.Interfaces;

namespace MvcWeb.Controllers
{
    [UseStopwatch]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWidgetService _widgetService;
        private readonly IGizmoService _gizmoService;

        private const string Synchronous = "Synchronous";
        private const string Asynchronous = "Asynchronous";

        public HomeController(IProductService productService, IWidgetService widgetService, IGizmoService gizmoService)
        {
            _productService = productService;
            _widgetService = widgetService;
            _gizmoService = gizmoService;
        }

       public ActionResult Products()
       {
           ViewBag.SyncOrAsync = Synchronous;

           var model = _productService.GetProducts();

           return View(model);
       }
    }
}
