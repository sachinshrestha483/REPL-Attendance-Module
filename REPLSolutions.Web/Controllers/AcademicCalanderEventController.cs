using REPLSolutions.Web.Models;
using REPLSolutions.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REPLSolutions.Web.Controllers
{
    public class AcademicCalanderEventController : Controller
    {


        private readonly ApplicationDbContext _context;

        public AcademicCalanderEventController()
        {
            _context = new ApplicationDbContext();
        }



        // GET: AcademicCalanderEvent
        public ActionResult Index()
        {
            AcademicCalanderEventsIndexViewModel objvm=new AcademicCalanderEventsIndexViewModel();
            objvm.AcademicCalanderEvents = _context.AcademicCalanderEvents.ToList();
            return View(objvm);
        }

       [HttpPost]
        public ActionResult AddEvent(AcademicCalanderEventsIndexViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));

            }

            _context.AcademicCalanderEvents.Add(obj.AcademicCalanderEvent);

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));

        }


        public ActionResult UpdateEvent(int id)
        {
            var obj = _context.AcademicCalanderEvents.FirstOrDefault(a => a.Id == id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index));

            }
                AcademicCalanderEventsIndexViewModel objvm = new AcademicCalanderEventsIndexViewModel();
            objvm.AcademicCalanderEvents = _context.AcademicCalanderEvents.ToList();
            objvm.AcademicCalanderEvent = obj;
            return View(objvm);

        }

        [HttpPost]
        public ActionResult UpdateEvent(AcademicCalanderEventsIndexViewModel obj)
        {

            if (!ModelState.IsValid)
            {
                AcademicCalanderEventsIndexViewModel objvm = new AcademicCalanderEventsIndexViewModel();
                objvm.AcademicCalanderEvents = _context.AcademicCalanderEvents.ToList();
                return View(objvm);
            }

            var academicCalanderEvent = _context.AcademicCalanderEvents.FirstOrDefault(c => c.Id == obj.AcademicCalanderEvent.Id);


            if (academicCalanderEvent == null)
            {
                return RedirectToAction(nameof(Index));
            }


            academicCalanderEvent.Name = obj.AcademicCalanderEvent.Name;
            academicCalanderEvent.show = obj.AcademicCalanderEvent.show;
            academicCalanderEvent.AcademicCalanderRule = obj.AcademicCalanderEvent.AcademicCalanderRule;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult ShowOrHideEvent(int id)
        {
            var eventobj = _context.AcademicCalanderEvents.FirstOrDefault(e => e.Id == id);


            if (eventobj == null)
            {
                return RedirectToAction (nameof(Index));
            }

            eventobj.show = !eventobj.show;
            _context.SaveChanges();


                return RedirectToAction (nameof(Index));



        }

    }
}