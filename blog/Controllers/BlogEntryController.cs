using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog.Models;
using blog.Models.Entities;

namespace blog.Controllers
{
    public class BlogEntryController : Controller
    {
        private readonly BlogContext context;

        public BlogEntryController()
            : this(new BlogContext())
        {

        }

        public BlogEntryController(BlogContext context)
        {
            this.context = context;
            var e = new Entry
            {
                Title = "First",
                CreatedOn = DateTime.UtcNow,
                Body = "This is the body"
            };
            this.context.Entries.Add(e);
            this.context.SaveChanges();
        }
        //
        // GET: /BlogEntry/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Entry entry)
        {
            return View();
        }

        public ViewResult BlogEntry(int id)
        {
            return View();
        }
    }
}
