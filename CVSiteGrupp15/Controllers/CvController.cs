using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Models;
using Microsoft.AspNet.Identity;

namespace CVSiteGrupp15.Controllers
{
    public class CvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cv
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cv/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Competence,Education,Experience")] Cv cv)
        {
            try
            {
                // TODO: Add insert logic here
                var user = User.Identity.GetUserId(); // Hämtar inloggad användare

                cv.UserId = user; // Tilldela cv propertyn UserId värdet på den inloggade användarens id
                
                db.Cvs.Add(cv);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cv/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cv/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
