using Model.Registers;
using Service.Registers;
using Service.Tables;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LuizCarlos.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        private ActionResult GetViewProductById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.ById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #region [Details]

        public ActionResult Details(long? id)
        {
            return GetViewProductById(id);
        }
        #endregion [Details]

        private void PopularViewBag(Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.GetOrderedByName(),
                    "CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(supplierService.GetOrderedByName(),
                    "SupplierId", "Name");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoryService.GetOrderedByName(),
                    "CategoryId", "Name", product.CategoryID);
                ViewBag.S = new SelectList(supplierService.GetOrderedByName(),
                    "SupplierId", "Name", product.SupplierID);
            }
        }
        #region [ Edit ]
        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(productService.ById((long)id));
            return GetViewProductById(id);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            return Save(product);
        }

        #endregion [ Edit ]

        #region [Create]
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            return Save(product);
        }
        #endregion [Create]


        #region [Save]
        private ActionResult Save(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productService.Save(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
        #endregion [Save]

        #region [Delete]
        public ActionResult Delete(long? id)
        {
            return GetViewProductById(id);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product = productService.Delete(id);
                TempData["Message"] = "Produto	" + product.Name.ToUpper() + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion [Delete]

        // GET: Products
        public ActionResult Index()
        {
            return View(productService.GetOrderedByName());
        }


    }
}