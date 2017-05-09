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
    [Authorize(Roles="Employee")]
    public class EmployeeController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        List<Tutors> _activeTutorList;
        TutorManager _tutorMgr;
        InterfaceManager _intMgr;

        // GET: /Employee/
        public ActionResult Index()
        {
            _intMgr = new InterfaceManager();
            _activeTutorList = _intMgr.getAllTutors();

            return View(_activeTutorList);
        }

        //GET: /Employee/Details/5
        public ActionResult Classes(int? id)
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

        
    }
}
