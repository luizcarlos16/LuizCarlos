using LuizCarlos.ExtensionMethods;
using Model.Tables;
using Persistence.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LuizCarlos.Controllers
{
    public class CategoriesController : Controller
    {
        private EFContexts context = new EFContexts();



        #region [ Actions ]

        #region [ Index ]

        // GET: Categories
        public ActionResult Index()
        {
            return View(context.Categories.OrderByDescending(categ => categ.Name));
        }

        #endregion

        #region [ CREATE ]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        #endregion

        #region [ Edit ]

        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = context.Categories.Where(f => f.CategoryID == id).Include("Products.Supplier").First();
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(category);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }

        #endregion

        #region [ Delete ]

        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = context.Categories.Where(f => f.CategoryID == id).Include("Products.Supplier").First();
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {

            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("index");

        }

        [HttpPost]
        public ActionResult BatchDelete(int[] deleteInputs)
        {

            if (deleteInputs != null && deleteInputs.Length > 0)
            {
                var categs = new List<Category>();
                foreach (var item in deleteInputs)
                    categs.Add(context.Categories.Find(item));


                context.Categories.RemoveRange(categs);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        #endregion

        #region [ Details ]

        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = context.Categories.Where(f => f.CategoryID == id).Include("Products.Supplier").First();
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        #endregion

        #endregion

        public string ContaPalavra(string word = "")
        {
            return string.Format("The '{0}' has '{1}' chars", word, word.WordCount());
        }
    }
}