using MVCPresentationLayer.Models;
using StutorDataObjects;
using StutorLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class BecomeATutorController : Controller
    {
        //
        // GET: /BecomeATutor/
        public ActionResult Index()
        {
            InterfaceManager intMgr = new InterfaceManager();
            //List<SubjectArea> subjectAreas = intMgr.getListSubjectArea();

            List<SubjectArea> subjectA = new List<SubjectArea>();
            subjectA.Add(new SubjectArea() { SubjectAreaID = 100001, SubjectAreaName = "Science" });
            subjectA.Add(new SubjectArea() { SubjectAreaID = 100002, SubjectAreaName = "Math" });
            subjectA.Add(new SubjectArea() { SubjectAreaID = 100003, SubjectAreaName = "English" });

            List<Subject> subjects = new List<Subject>();
            subjects.Add(new Subject() { SubjectAreaID = 100001, SubjectID = 100001, SubjectName = "Sci101" });
            subjects.Add(new Subject() { SubjectAreaID = 100001, SubjectID = 100002, SubjectName = "Bio101" });
            subjects.Add(new Subject() { SubjectAreaID = 100002, SubjectID = 100001, SubjectName = "Algebra101" });
            subjects.Add(new Subject() { SubjectAreaID = 100002, SubjectID = 100002, SubjectName = "Trig102" });
            subjects.Add(new Subject() { SubjectAreaID = 100002, SubjectID = 100003, SubjectName = "Calc202" });

            AreaAndSubject complete = new AreaAndSubject() { SubjectAreas = subjectA, Subjects = subjects };
            
            return View(complete);
        }

        public ActionResult Request(string subjectName)
        {
            TutorManager tutMgr = new TutorManager();
            UserManager usrMgr = new UserManager();
            string email = System.Web.HttpContext.Current.User.Identity.Name;
            int userId = usrMgr.GetIndividualStudent(email).userID;
            
            try{
                tutMgr.manageTutorApplication(userId, subjectName);
            }catch(Exception){
                
            }

            return View();
        }



	}
}