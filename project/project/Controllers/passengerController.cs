using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
    public class passengerController : Controller
    {
        Model1 db = new Model1();
        // GET: passenger
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(passenger p)
        {
            //if (p.password == p.confpassword) { 
            db.passengers.Add(p);
            db.SaveChanges();
            return RedirectToAction("login");
            //}
            //else
            //    {
            //    ViewBag.status = "the passwards is not simelar";
            //    return View();
            //}
        }

        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(userlogin u)
        {
            passenger p = db.passengers.Where(n => n.email == u.email && n.password == u.password).FirstOrDefault();
            if (p != null)
            {
                Session.Add("id", p.id);
                return RedirectToAction("profile");

            }
            else
            {
                ViewBag.status = "incorrect username or password";
                return View();


            }

        }
        public ActionResult profile()
        {
            int id = (int)Session["id"];
            passenger u = db.passengers.Where(n => n.id == id).SingleOrDefault();

            return View(u);
        }
        public ActionResult logout()
        {
            Session["id"] = null;
            return RedirectToAction("index", "Home");
        }

        public ActionResult editprofile(int id)
        {
            //int uid = (int)Session["id"];
            passenger s = db.passengers.Where(n => n.id == id).SingleOrDefault();


            return View(s);
        }
        [HttpPost]
        public ActionResult editprofile(passenger s)
        {
            //db.Entry(s).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


            return RedirectToAction("profile");
        }


        //public ActionResult remove(int id)
        //{
        //    passenger s = db.passengers.Where(n => n.id == id).SingleOrDefault();
        //    db.passengers.Remove(s);
            
        //    db.SaveChanges();
        //    return RedirectToAction("login");
        //}


        public ActionResult hotels()
        {
            return View();
        }
        public ActionResult map()
        {
            return View();
        }

    }



    }
