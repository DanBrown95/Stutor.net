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
using StutorLogicLayer;

namespace MVCPresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        List<Tutors> _activeTutorList;
        TutorManager _tutorMgr;
        InterfaceManager _intMgr;

        [Authorize(Roles="Administrator")]
        // GET: /Employee/
        public ActionResult Index()
        {
            _intMgr = new InterfaceManager();
            _activeTutorList = _intMgr.getAllTutors();

            return View(_activeTutorList);
        }

        //GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tutors tutors = db.Tutors.Find(id);
            _tutorMgr = new TutorManager();
            _intMgr = new InterfaceManager();
            Tutors tutors = _intMgr.getAllTutors().Find(x => x.ID == (int)id);
            List<Class> classes = _tutorMgr.GetAllSubjectsTutoredByUserID((int)id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        //// GET: /Employee/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /Employee/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ID,UserID,TutorID,Firstname,Lastname,Email")] Tutors tutors)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Tutors.Add(tutors);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tutors);
        //}

        //// GET: /Employee/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tutors tutors = db.Tutors.Find(id);
        //    if (tutors == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tutors);
        //}

        //// POST: /Employee/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ID,UserID,TutorID,Firstname,Lastname,Email")] Tutors tutors)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tutors).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tutors);
        //}

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterfaceManager interfaceMgr = new InterfaceManager();
            Tutors tutors = interfaceMgr.getAllTutors().Find(x => x.TutorID == id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        //// POST: /Employee/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Tutors tutors = db.Tutors.Find(id);
        //    db.Tutors.Remove(tutors);
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
