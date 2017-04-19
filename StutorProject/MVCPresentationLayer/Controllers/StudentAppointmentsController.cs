﻿using System;
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
    public class StudentAppointmentsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        TutorManager tutorMgr;
        User currentUser = new User() { userID = 100000, firstname = "Daniel", lastname = "Brown", role = "Tutor", email = "daniel_brown4@student.kirkwood.edu", active = true, passwordHash = "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e" };

        // GET: /StudentAppointments/
        public ActionResult Index()
        {
            //return View(db.StudentAppointments.ToList());
            tutorMgr = new TutorManager();
            return View(tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(currentUser.userID)));
        }

        // GET: /StudentAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentappointments = db.StudentAppointments.Find(id);
            tutorMgr = new TutorManager();
            StudentAppointments studentappointments = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(currentUser.userID)).Find(x => x.TutoringRequestID == (int)id);
            if (studentappointments == null)
            {
                return HttpNotFound();
            }
            return View(studentappointments);
        }

        //// GET: /StudentAppointments/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /StudentAppointments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ID,Day,Time,SubjectName,StudentFirstname,StudentLastname,Status,TutoringRequestID")] StudentAppointments studentappointments)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentAppointments.Add(studentappointments);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(studentappointments);
        //}

        // GET: /StudentAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentappointments = db.StudentAppointments.Find(id);
            tutorMgr = new TutorManager();
            StudentAppointments studentAppointment = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(currentUser.userID)).Find(x => x.TutoringRequestID == (int)id);
            
            if (studentAppointment == null)
            {
                return HttpNotFound();
            }
            return View(studentAppointment);
        }

        // POST: /StudentAppointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,Time,SubjectName,StudentFirstname,StudentLastname,Status,TutoringRequestID")] StudentAppointments studentappointments)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(studentappointments).State = EntityState.Modified;
                //db.SaveChanges();
                tutorMgr = new TutorManager();
                try
                {
                    tutorMgr.AcceptStudentAppointment(studentappointments.TutoringRequestID);
                }
                catch (Exception)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            return View(studentappointments);
        }

        // GET: /StudentAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentappointments = db.StudentAppointments.Find(id);
            tutorMgr = new TutorManager();
            StudentAppointments studentAppointment = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(currentUser.userID)).Find(x => x.TutoringRequestID == (int)id);
            if (studentAppointment == null)
            {
                return HttpNotFound();
            }
            return View(studentAppointment);
        }

        // POST: /StudentAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //StudentAppointments studentappointments = db.StudentAppointments.Find(id);
            //db.StudentAppointments.Remove(studentappointments);
            //db.SaveChanges();

            tutorMgr = new TutorManager();
            try
            {
                tutorMgr.DeleteStudentApplication(id);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            
            return RedirectToAction("Index");
        }

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