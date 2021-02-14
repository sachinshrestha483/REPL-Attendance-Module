using REPLSolutions.Web.Models;
using REPLSolutions.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REPLSolutions.Web.Controllers
{
    public class AcademicCalanderController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AcademicCalanderController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: AcademicCalander
        public ActionResult Index()
        {
            var vm = new AcademicCalanderViewModel() {
                CalanderRules = _context.AcademicCalander.ToList(),
                 AcademicCalanderEvents=_context.AcademicCalanderEvents.ToList()
            };


            return View(vm);
        }

        [HttpPost]
        public ActionResult AddRules(AcademicCalanderViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", obj);
            }

            if (obj.AcademicCalander.StartDate > obj.AcademicCalander.EndDate)
            {
                ModelState.AddModelError("RangeError", "Date Range Not Correct");
                return View("Index", obj);

            }

            // if attendance already exists......

            







            _context.AcademicCalander.Add(obj.AcademicCalander);

            _context.SaveChanges();






            return RedirectToAction(nameof(Index));
        }


        [HttpPost]

        public ActionResult DeleteRule(int id)
        {

            var rule = _context.AcademicCalander.FirstOrDefault(a => a.Id == id);
            if (rule == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var startDate = rule.StartDate;
            var endDate = rule.EndDate;

            // here doublt about the overriding Rules.....
            // if that attendace dont come under the 

            bool isThisRuleUsed = false;
            // Covering  some Edge Cases
            // check if some attendace is taken during that date time
            var dates = new List<DateTime>();


            dates.Add(startDate);
           
                while (dates[dates.Count() - 1] != endDate)
                {
                    startDate=startDate.AddDays(1);
                dates.Add(startDate);
                }
            

            var allRules = _context.AcademicCalander.ToList();

            foreach (var date in dates)
            {

                var attendanceondate = _context.Attendances.FirstOrDefault(a => a.AttendanceOfDate == date);

                if (attendanceondate != null)
                {

                    var rules = allRules.Where(r=>r.StartDate<=date&&r.EndDate>=date);
                    // finding rule for it

                    var rulesList = rules.ToList();
                    //var latestRule = rulesList[rulesList.Count() - 1];
                    //Applying The First Rule..in Array
                    var latestRule = rulesList[0];


                    var flaggedRuleList = rules.Where(r => r.flag == true).ToList();

                    if (flaggedRuleList.Count >= 1)
                    {
                        if (flaggedRuleList.Count == 1)
                        {
                            latestRule = flaggedRuleList[0];
                        }

                        else
                        {
                            latestRule = flaggedRuleList[flaggedRuleList.Count() - 1];

                        }
                    }

                    if (latestRule.Id == rule.Id)
                    {
                        isThisRuleUsed = true;
                    }


                }

                //  var appliedRuleId= _context.AcademicCalander.fir
            }





            if (isThisRuleUsed==false)
            {

                _context.AcademicCalander.Remove(rule);
                _context.SaveChanges();

            }


            else
            {
                ModelState.AddModelError("WrongDelete","Cant Delete Rule As Attendace Is There For It ");

                var vm = new AcademicCalanderViewModel()
                {
                    CalanderRules = _context.AcademicCalander.ToList()
                };



                return View(nameof(Index),vm);


            }

            //var attendance = _context.Attendances.Where(a => );

            return RedirectToAction(nameof(Index));
        }




        [HttpPost]
        public ActionResult FlagUnflagRule(int ?id)
        {
            var rule = _context.AcademicCalander.FirstOrDefault(c => c.Id == id);
            
            if (rule == null)
            {
                return RedirectToAction(nameof(Index));
            }

            rule.flag = !rule.flag;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));






        }




    }
}