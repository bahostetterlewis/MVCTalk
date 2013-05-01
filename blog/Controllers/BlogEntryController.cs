using System.Web.Mvc;
using blog.Models;
using blog.Models.Entities;
using blog.Models.Repositories;

namespace blog.Controllers
{
    public class BlogEntryController : Controller
    {
        private readonly IUnitOfWork context;
        private readonly IGenericRepository<Entry> entryRepository;

        public BlogEntryController()
            : this(new BlogContext())
        {
        }

        public BlogEntryController(IUnitOfWork context)
        {
            this.context = context;
            this.entryRepository = context.EntryRepository;
        }

        //
        // GET: /BlogEntry/

        public ActionResult Index()
        {
            return View(entryRepository.All);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            entryRepository.InsertOrUpdate(ref entry, entry.EntryId);
            context.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(entryRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            var real_entry = entryRepository.Find(entry.EntryId);
            real_entry.Body = entry.Body;
            real_entry.Title = entry.Title;
            entryRepository.InsertOrUpdate(ref real_entry, real_entry.EntryId);
            context.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(entryRepository.Find(id));
        }

        public ActionResult Delete(int id)
        {
            return View(entryRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            entryRepository.Delete(id);
            context.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}