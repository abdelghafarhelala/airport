using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class flightController : Controller
    {
        Model1 db = new Model1();
        // GET: flight
        public ActionResult add()
        {
           

            ViewBag.li = new SelectList(db.catloges.ToList(), "id", "name");
            ViewBag.lii = new SelectList(db.froms.ToList(), "id", "from1");
            ViewBag.liii = new SelectList(db.select_dir.ToList(), "id", "dir");
            return View();
        }
        [HttpPost]
        public ActionResult add(flight n )
        {
            n.p_id = (int)Session["id"];
            db.flights.Add(n);
            db.SaveChanges();
            return RedirectToAction("viewmyflights");
        }


        public ActionResult viewmyflights()
        {
            int uid = (int)Session["id"];
            List<flight> mn = db.flights.Where(n => n.p_id == uid ).ToList();
            return View(mn);
        }


        public ActionResult allflights()
        {

            List<flight> mn = db.flights.OrderByDescending(n => n.f_id).Take(10).ToList();
            return View("viewmyflights", mn);
        }


        public ActionResult removee(int id)
        {
            flight g = db.flights.Where(n => n.p_id == id).SingleOrDefault();
            db.flights.Remove(g);

            db.SaveChanges();
            return RedirectToAction("viewmyflights");
        }

        //public ActionResult edit( int id)
        //{
        //  //  int uid = (int)Session["id"];
        //    flight i = db.flights.Where(n => n.p_id == id ).FirstOrDefault();
        //    ViewBag.li = new SelectList(db.catloges.ToList(), "id", "name");
        //    ViewBag.lii = new SelectList(db.froms.ToList(), "id", "from1");
        //    ViewBag.liii = new SelectList(db.select_dir.ToList(), "id", "dir");

        //    return View(i);

        //}
        //[HttpPost]
        //public ActionResult edit(flight i)
        //{

        //    db.Entry(i).State = System.Data.Entity.EntityState.Modified;

        //    db.SaveChanges();
        //    return RedirectToAction("viewmyflights");
        //}

    }
   

}
