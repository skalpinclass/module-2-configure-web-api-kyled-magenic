using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private BlogContext db;
        public BlogController(BlogContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Entities.Blog>> Get()
        {
            return db.Blogs.Include(x => x.Posts).ToList();
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public void Post([FromBody] Entities.Blog value)
        {
            db.Blogs.Add(value);
            db.SaveChanges();
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public void Put(int id, [FromBody] Entities.Blog value)
        {
            db.Blogs.Update(value);
            db.SaveChanges();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public void Delete(int id)
        {
            var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog != null)
            {
                db.Blogs.Remove(db.Blogs.FirstOrDefault(x => x.BlogId == id));
                db.SaveChanges();
            }
        }

    }
}