using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Models;
using Microsoft.AspNet.Identity;

namespace CVSiteGrupp15.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        //public ActionResult Index()
        //{
        //    return View(db.Projects.ToList());
        //}

        public ActionResult Index(string option, string search)
        {
            

            if (option == "")
            {
                //Index action method will return a view with a project records based on what a user specify the value in textbox  
                return View(db.Projects.Where(x => x.Title == search || search == null).ToList());
            }
            else
            {
                return View(db.Projects.Where(x => x.Title.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newProject = new Project()

                    {
                        Title = project.Title,
                        Description = project.Description,
                        imageUrl = project.imageUrl,

                    };
                    db.Projects.Add(newProject);
                    db.SaveChanges();
                    var userProject = new ApplicationUserProject()
                    {
                        ApplicationUserId = User.Identity.GetUserId(),
                        ProjectId = newProject.Id,
                    };

                    db.ApplicationUserProjects.Add(userProject);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            

            catch
            {
                return View(project);
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Personal(string userid)
        {
            //ViewBag.NameTransfer = userid;

            var results = (from F in db.ApplicationUserProjects
                                   //join FT in db.ApplicationUserProjects on F.Id equals FT.ProjectId
                             where F.ApplicationUserId == userid
                           //select F.ProjectId
                           select F.ProjectId).FirstOrDefault();


           return View(db.Projects.Where(x => x.Id == results).ToList());
            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
