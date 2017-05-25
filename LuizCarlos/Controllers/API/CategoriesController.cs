﻿using Model.Tables;
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
        public EFContext context = new EFContext();

        private async Task<HttpResponseMessage> FromApi(long? id, Action<HttpResponseMessage> action)
        {
            using (var client = new HttpClient())
            {
                var baseURL = string.Format("{0}://{1}"),
                    HttpContext.Request.Url.Scheme,
                HttpContext.Request.Url.Authority);
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "Api/Categories";
                if (id != null)
                    url = "Api/Categories/" + id;

                var request = await client.GetAsync(url);
                if (action.Invoke(request)) ;

                return request;
            }
        }

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