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


        // GET: /RequestATutor/SendRequest/5
        public ActionResult SendRequest(int? id, int subjectId)
        {
            UserManager usrmgr = new UserManager();
            currentUser = usrmgr.GetIndividualStudent(email);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            InterfaceManager intMgr = new InterfaceManager();
            var subjectName = intMgr.GetSubjectNameWithSubjectId(subjectId);
            ClassTutor classTutor = intMgr.getClassTutors(subjectName, currentUser.userID).Find(x => x.userID == id);
             

            if (classTutor == null)
            {
                return HttpNotFound();
            }
            return View(classTutor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendRequest(ClassTutor classTutor)
        {
            if (ModelState.IsValid)
            {
                UserManager usrmgr = new UserManager();
                currentUser = usrmgr.GetIndividualStudent(email);

                TutorManager tutMgr = new TutorManager();
                
                try
                {
                    var tutorId = tutMgr.GetTutorIDFromUserID(classTutor.userID);

                    tutMgr.CreateTutoringRequest(currentUser.userID, tutorId, classTutor.subjectID, classTutor.Date, classTutor.Time);
                    return RedirectToAction("Index", "TutorAppointments");
                }catch(Exception){

                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                
            }

            return View();
        }


    }
}
