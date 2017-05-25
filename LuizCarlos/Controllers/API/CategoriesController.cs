using Model.Tables;
using Newtonsoft.Json;
using Persistence.Contexts;
using Service.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace LuizCarlos.Controllers.API
{
    public class CategoriesController : ApiController
    {
        public EFContexts context = new EFContexts();

        private CategoryService categoryService = new CategoryService();

        private async Task<ActionResult>GetViewCategoryById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category item = null;

            var resp = await FromApi(id.Value, response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserialezeObject<Category>(result);
                }
            });

            if (!resp.IsSucessStatusCode)
                return new HttpStatusCodeResult(resp.StatusCode);
            if (item == null)
                return HttpNotFound();

            return View(item);

        }

      /*  // GET: api/Categories
        public IEnumerable<Category> Get()
        {
            return (context.Categories.OrderByDescending(categ => categ.Name));
        }

        // GET: api/Categories/5
        public Category Get(int id)
        {
            return service.ById(id);
        }

        // POST: api/Categories
        public void Post([FromBody] Category value)
        {
            service.Save(value);
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody] Category value)
        {
            Service.Save(value);
        }

        // DELETE: api/Categories/5
        public Category Delete(int id)
        {
            return dal.Delete(id);
           
        }*/
    }
}
