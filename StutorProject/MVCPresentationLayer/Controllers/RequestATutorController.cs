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
using System.ComponentModel.DataAnnotations;

namespace MVCPresentationLayer.Controllers
{
    [Authorize]
    public class RequestATutorController : Controller
    {

        string email = System.Web.HttpContext.Current.User.Identity.Name;
        User currentUser;

        // GET: /RequestATutor/
        public ActionResult Index()
        {
            List<SubjectArea> subjectAreas = new List<SubjectArea>();
            InterfaceManager intMgr = new InterfaceManager();
            subjectAreas = intMgr.getListSubjectArea();

            return View(subjectAreas);
        }

        public ActionResult SelectSubject(string SubjectAreaName)
        {

            List<Subject> subjects = new List<Subject>();
            InterfaceManager intmgr = new InterfaceManager();
            subjects = intmgr.getListSubject(SubjectAreaName);

            return View(subjects);
        }

        public ViewResult ViewTutors(string subjectName)
        {
            
            UserManager usrmgr = new UserManager();
            currentUser = usrmgr.GetIndividualStudent(email);

            List<ClassTutor> tutors = new List<ClassTutor>();
            InterfaceManager intMgr = new InterfaceManager();
            
            tutors = intMgr.getClassTutors(subjectName, currentUser.userID);
            
            return View(tutors);
        }


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
