using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class DeleteController : Controller
    {
        private TaskContext context;

        public DeleteController()
        {
            context = new TaskContext();
        }
        // GET: Delete
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var task = context.Task.Find(id);

            if (task != null)
            {
                context.Task.Remove(task);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
