using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;
        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Update(Category category)
        {
            repository.UpdateCategory(category);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return Ok();
        }

    }
}
