using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestWebApplication1.Models;

namespace TestWebApplication1.Controllers
{
    public class MessageController : Controller
    {

        private MessageDbContext dbCtx = new MessageDbContext();
        // GET: Message
        public ActionResult Index()
        {
            return View(dbCtx.Messages.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            MessageModel msg = new MessageModel();
            msg.UserName = "Test";
            return View(msg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageModel msg)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Messages.Add(msg);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(msg);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            MessageModel msg = dbCtx.Messages.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        [HttpPost]
        public ActionResult Edit(MessageModel msg)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Entry(msg).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(msg);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            MessageModel msg = dbCtx.Messages.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                MessageModel msg = dbCtx.Messages.Find(id);
                dbCtx.Messages.Remove(msg);
                dbCtx.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            MessageModel msg = dbCtx.Messages.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }

            return View(msg);
        }

    }
}