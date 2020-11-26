using JobBoardMVC.Models;
using JobBoardMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardMVC.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobsService jobsService = new JobsService();
        // GET: Jobs
        public ActionResult Index()
        {
            var model = jobsService.Get() ?? new List<Job>();
            return View(model);
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int id = 0)
        {
            var model = jobsService.Get(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            var model = new Job();
            return View(model);
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(Job value)
        {
            var model = jobsService.Post(value);
            if (model != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Job has not been created, please try again.";
                return View();
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id=0)
        {
            var model = jobsService.Get(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Job value)
        {
            value.Id = id;
            var model = jobsService.Put(value);
            if (model)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Job has not been saved, please try again.";
                return View(value);
            }
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id=0)
        {
            var model = jobsService.Get(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Job value)
        {
            var model = jobsService.Delete(id);
            if (model!=null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Job has not been deleted, please try again.";
                return View(value);
            }
        }
    }
}
