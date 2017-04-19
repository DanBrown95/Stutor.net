using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StutorDataObjects;
using MVCPresentationLayer.Models;

namespace MVCPresentationLayer.Controllers
{
    public class RequestATutorController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        //// GET: /RequestATutor/
        //public ActionResult Index()
        //{
        //    return View(db.ClassTutors.ToList());
        //}

        //// GET: /RequestATutor/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassTutor classtutor = db.ClassTutors.Find(id);
        //    if (classtutor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classtutor);
        //}

        //// GET: /RequestATutor/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /RequestATutor/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="userID,subjectID,firstname,lastname,email")] ClassTutor classtutor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ClassTutors.Add(classtutor);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(classtutor);
        //}

        //// GET: /RequestATutor/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassTutor classtutor = db.ClassTutors.Find(id);
        //    if (classtutor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classtutor);
        //}

        //// POST: /RequestATutor/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="userID,subjectID,firstname,lastname,email")] ClassTutor classtutor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(classtutor).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(classtutor);
        //}

        //// GET: /RequestATutor/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassTutor classtutor = db.ClassTutors.Find(id);
        //    if (classtutor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classtutor);
        //}

        //// POST: /RequestATutor/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ClassTutor classtutor = db.ClassTutors.Find(id);
        //    db.ClassTutors.Remove(classtutor);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
