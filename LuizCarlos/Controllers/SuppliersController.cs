using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Registers;
using Persistence.Contexts;

namespace LuizCarlos.Controllers
{
    public class SuppliersController : Controller
    {

        private EFContexts context = new EFContexts();
//        private object dbEntityEntry;


        #region [ Action ]
        // GET: Suppliers
        //GET: Suppliers/Index
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(supplier => supplier.Name));
        }
        #endregion [ Action ]

        #region [ Create ]
        //GET: Supplier
        public ActionResult Create()
        {
            return View();
        }

        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion [ Create ]

        #region [ Edit ]
        //GET: Suppliers/Edit/S 
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Supplier supplier = context.Suppliers.Where(f => f.SupplierID == id).Include("Products.Category").First();
            //Supplier supplier = context.Suppliers.Find(id);

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }

        //POST: Suppliers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(supplier);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        #endregion [Edit]

        #region [Delete]
        //GET: Suppliers/Delete/S 
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Supplier supplier = context.Suppliers.Where(f => f.SupplierID == id).Include("Products.Category").First();

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }

        //POST: Suppliers/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Supplier supplier = context.Suppliers.Find(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            TempData["Message"] = "Fabricante	" + supplier.Name.ToUpper() + "	foi	removido";
            return RedirectToAction("Index");
        }

        #endregion[Delete]

        #region [Details]
        //GET: Suppliers/Edit/S 
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Supplier supplier = context.Suppliers.Where(f => f.SupplierID == id).Include("Products.Category").First();
        


            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }
        #endregion [Details]


    }
}