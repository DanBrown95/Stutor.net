using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPresentationLayer.Models;
using StutorDataObjects;
using StutorLogicLayer;

namespace MVCPresentationLayer.Controllers
{
    [Authorize(Roles = "Tutor, Student")]
    public class TutorAppointmentsController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        //User currentUser = SOMEHOW GET THE CURRENT USER

        UserManager usrMgr = new UserManager();
        string email = System.Web.HttpContext.Current.User.Identity.Name;
        User currentUser = null;

        public TutorAppointmentsController()
        {
            currentUser = usrMgr.GetIndividualStudent(email);
        }
        

        // GET: TutorAppointments
        public ActionResult Index()
        {
            TutorManager tutorMgr = new TutorManager();
            return View(tutorMgr.GetListTutorAppointments(currentUser.userID));
        }

        // GET: TutorAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentAppointments = db.StudentAppointments.Find(id);
            TutorManager tutorMgr = new TutorManager();
            var appointment = tutorMgr.GetListTutorAppointments(currentUser.userID).Find(x => x.TutoringRequestID == (int)id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //// GET: TutorAppointments/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StudentAppointments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Day,Time,SubjectName,StudentFirstname,StudentLastname,Status,TutoringRequestID")] StudentAppointments studentAppointments)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentAppointments.Add(studentAppointments);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(studentAppointments);
        //}

        // GET: StudentAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentAppointments = db.StudentAppointments.Find(id);
            TutorManager tutorMgr = new TutorManager();
            TutorAppointments appointment = tutorMgr.GetListTutorAppointments(currentUser.userID).Find(x => x.TutoringRequestID == (int)id);

            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: StudentAppointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,Time,SubjectName,StudentFirstname,StudentLastname,Status,TutoringRequestID")] TutorAppointments newAppointment)
        {

            if (ModelState.IsValid)
            {
                //db.Entry(studentAppointments).State = EntityState.Modified;
                //db.SaveChanges();

                TutorManager tutorMgr = new TutorManager();
                var oldAppointment = tutorMgr.GetListTutorAppointments(currentUser.userID).Find(x => x.TutoringRequestID == newAppointment.TutoringRequestID);
                try
                {
                    if (tutorMgr.EditTutorAppointment(oldAppointment, newAppointment) == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                    }
                }
                catch (Exception)
                {

                    return View(oldAppointment);
                }

            }
            return View("Edit");
        }

        // GET: StudentAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //StudentAppointments studentAppointments = db.StudentAppointments.Find(id);
            TutorManager tutorMgr = new TutorManager();
            TutorAppointments appointment = tutorMgr.GetListTutorAppointments(currentUser.userID).Find(x => x.TutoringRequestID == (int)id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: StudentAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //StudentAppointments studentAppointments = db.StudentAppointments.Find(id);

            TutorManager tutorMgr = new TutorManager();

            if (true == tutorMgr.DeleteStudentApplication(id))
            {
                return View("Index");
            }

            //db.StudentAppointments.Remove(studentAppointments);
            //db.SaveChanges();

            return HttpNotFound();
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
