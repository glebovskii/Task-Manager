using System;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Helpers;
using System.Collections.Generic;

namespace TaskManager.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private TaskContext context;

        public CreateController()
        {
            context = new TaskContext();
        }
        // GET: Update
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string content, string title, List<string> tags)
        {
            List<string> temp = CreateTagList.TagsList(tags);
            var task = new PersonalTask()
            {
                Title = title,
                Content = content,
                LastModified = DateTime.Now,
                Tags = temp
            };
            context.Task.Add(task);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
