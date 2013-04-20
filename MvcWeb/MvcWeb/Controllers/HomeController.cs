using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

using MvcWeb.Filters;
using MvcWeb.Models;
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

        public HomeController(IProductService productService, IWidgetService widgetService, IGizmoService gizmoService)
        {
            _productService = productService;
            _widgetService = widgetService;
            _gizmoService = gizmoService;
        }

        //=========== Products
        public ActionResult Products()
        {
            ViewBag.SyncOrAsync = Synchronous;

            var model = _productService.GetProducts();

            //int count = Enumerable.Range(1, 10).Select(x => _productService.GetProducts()).Count();

            return View(model);
        }

        public async Task<ActionResult> ProductsAsync()
        {
            ViewBag.SyncOrAsync = Asynchronous;

            var model = await _productService.GetProductsAsync();

            //IEnumerable<Task<List<Product>>> count = Enumerable.Range(1, 10).Select(x => _productService.GetProductsAsync());

            //Task<List<Product>>[] items = count.ToArray();

            //await Task.WhenAll(items);

            return View("Products", model);
        }


        //============= Gizmos
        public ActionResult Gizmos()
        {
            ViewBag.SyncOrAsync = Synchronous;

            var model = _gizmoService.GetGizmos();

            return View(model);
        }

        public async Task<ActionResult> GizmosAsync()
        {
            ViewBag.SyncOrAsync = Asynchronous;

            var model = await _gizmoService.GetGizmosAsync();

            return View("Gizmos", model);
        }

        [AsyncTimeout(150)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimeoutError")]
        public async Task<ActionResult> GizmosCancelAsync(CancellationToken cancellationToken)
        {
            ViewBag.SyncOrAsync = Asynchronous;

            var model = await _gizmoService.GetGizmosAsync(cancellationToken);

            return View("Gizmos", model);
        }


        //========== Widgets
        public ActionResult Widgets()
        {
            ViewBag.SyncOrAsync = Synchronous;

            var model = _widgetService.GetWidgets();

            return View(model);
        }

        public async Task<ActionResult> WidgetsAsync()
        {
            ViewBag.SyncOrAsync = Asynchronous;

            var model = await _widgetService.GetWidgetsAsync();

            return View("Widgets", model);
        }


        //========= Combination
        public ActionResult PWG()
        {
            ViewBag.SyncOrAsync = Synchronous;

            var widgets = _widgetService.GetWidgets();
            var products = _productService.GetProducts();
            var gizmos = _gizmoService.GetGizmos();

            var model = new ProdGizWidgetVM(widgets, products, gizmos);

            return View(model);
        }

        [AsyncTimeout(50)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimeoutError")]
        public async Task<ActionResult> PWGAsync()
        {
            ViewBag.SyncOrAsync = Asynchronous;

            Task<List<Widget>> widgetTask = _widgetService.GetWidgetsAsync();
            Task<List<Product>> productTask = _productService.GetProductsAsync();
            Task<List<Gizmo>> gizmoTask = _gizmoService.GetGizmosAsync();

            await Task.WhenAll(widgetTask, productTask, gizmoTask);

            var model = new ProdGizWidgetVM(widgetTask.Result, productTask.Result, gizmoTask.Result);

            return View("PWG", model);
        }



        private const string Synchronous = "Synchronous";
        private const string Asynchronous = "Asynchronous";
    }
}
