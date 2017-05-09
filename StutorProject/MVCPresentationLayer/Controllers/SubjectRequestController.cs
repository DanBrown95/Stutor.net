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
    [Authorize]
    public class SubjectRequestController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        InterfaceManager intMgr;

        // GET: /SubjectRequest/
        public ActionResult Index()
        {
            intMgr = new InterfaceManager();
            List<SubjectRequest> allRequests = intMgr.GetAllSubjectRequests();
            return View(allRequests);
        }
        
        // GET: /SubjectRequest/Create
        public ActionResult Create()
        {
            intMgr = new InterfaceManager();
            List<SubjectArea> subjectAreas = intMgr.getListSubjectArea();
            ViewBag.subjectAreas = subjectAreas;
            return View();
        }

        // POST: /SubjectRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectRequestID,subjectAreaName,subjectName")] SubjectRequest subjectrequest)
        {
            if (ModelState.IsValid)
            {
                //db.SubjectRequests.Add(subjectrequest);
                //db.SaveChanges();

                InterfaceManager intMgr = new InterfaceManager();
                try
                {
                    intMgr.AddSubjectRequest(subjectrequest.subjectAreaName, subjectrequest.subjectName);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
                return RedirectToAction("Index","Home");
            }

            return View("Create");
        }
        
        // GET: /SubjectRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            intMgr = new InterfaceManager();
            SubjectRequest subjectrequest = intMgr.GetAllSubjectRequests().Find(x => x.SubjectRequestID == id);
            if (subjectrequest == null)
            {
                return HttpNotFound();
            }
            return View(subjectrequest);
        }

        // POST: /SubjectRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            intMgr = new InterfaceManager();
            SubjectRequest subjectrequest = intMgr.GetAllSubjectRequests().Find(x => x.SubjectRequestID == id);

            try
            {
                if (false == intMgr.DeleteSubjectRequest(subjectrequest.SubjectRequestID))
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return RedirectToAction("Index");
        }

        // GET: /SubjectRequest/Approve/5
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            intMgr = new InterfaceManager();
            SubjectRequest subjectrequest = intMgr.GetAllSubjectRequests().Find(x => x.SubjectRequestID == id);
            if (subjectrequest == null)
            {
                return HttpNotFound();
            }
            return View(subjectrequest);
        }

        // POST: /SubjectRequest/Approve/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            intMgr = new InterfaceManager();
            SubjectRequest subjectrequest = intMgr.GetAllSubjectRequests().Find(x => x.SubjectRequestID == id);
            int subjectAreaID = intMgr.GetSubjectAreaIdWithSubjectAreaName(subjectrequest.subjectAreaName);
            try
            {
                if (false == intMgr.AddNewSubject(subjectAreaID, subjectrequest.subjectName))
                {
                    return HttpNotFound();
                }
                else
                {
                    
                    intMgr.DeleteSubjectRequest(subjectrequest.SubjectRequestID);
                }
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return RedirectToAction("Index");
        }

        

    }
}
