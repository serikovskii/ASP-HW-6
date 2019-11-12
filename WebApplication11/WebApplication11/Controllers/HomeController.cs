using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        public Context context = new Context();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await context.Products.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            Product product = await context.Products.FindAsync(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Price,Description,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
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