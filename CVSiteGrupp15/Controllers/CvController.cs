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
        public ActionResult Index(string search)
        {
            var user = User.Identity.GetUserId();

            // om man ej är inloggad
           if (User.Identity.Name == "")
            {
                if (!String.IsNullOrEmpty(search))
                {

                    //Hämta id från anvädaren som man söker på
                    var userid = (from n in db.Users
                                  where n.Name == search
                                  select n.Id).FirstOrDefault();

                    var userSearched = (from n in db.Users
                                        where n.Id == userid
                                        select n).FirstOrDefault();

                    // Om man inte är inloggad och söker på en privat profil så returneras inte deras cv
                    if (userSearched.PrivateProfile == true) 
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //Hämta det cv som är kopplat till det användarid som vi hämtade i den föregående queryn
                        var userQuery = (from F in db.Cvs
                                         where F.UserId == userid
                                         select F.UserId).FirstOrDefault();



                        //Index action method will return a view with a cv records based on what a user specify the value in textbox  
                        // Sök fram användares cv genom att ange id-hash
                        return View(db.Cvs.Where(x => x.UserId == userQuery).ToList());
                    }
                    


                }
                else
                {
                    //return View(db.Cvs.Where(x => x.Education.StartsWith(search) || search == null).ToList());
                    return View(db.Cvs.Where(x => x.UserId == user).ToList());
                }
            }
           else // om användaren är inloggad
            {
                if (!String.IsNullOrEmpty(search))
                {

                    //Hämta id från anvädaren som man söker på
                    var userid = (from n in db.Users
                                  where n.Name == search
                                  select n.Id).FirstOrDefault();

                    //Hämta det cv som är kopplat till det användarid som vi hämtade i den föregående queryn
                    var userQuery = (from F in db.Cvs
                                     where F.UserId == userid
                                     select F.UserId).FirstOrDefault();



                    //Index action method will return a view with a cv records based on what a user specify the value in textbox  
                    // Sök fram användares cv genom att ange id-hash
                    return View(db.Cvs.Where(x => x.UserId == userQuery).ToList());


                }
                else
                {
                    return View(db.Cvs.Where(x => x.UserId == user).ToList());
                }
            }
           

            
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
