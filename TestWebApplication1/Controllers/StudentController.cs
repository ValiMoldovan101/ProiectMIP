using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestWebApplication1.Models;

namespace TestWebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private StudentDbContext dbCtx = new StudentDbContext();
        // GET: Message
        public ActionResult Index()
        {
            return View(dbCtx.Students.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            StudentModel std = new StudentModel();
            std.Nume = "Nume";
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel std)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Students.Add(std);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(std);
        }
    }
}