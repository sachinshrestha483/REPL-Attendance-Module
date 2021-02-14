using REPLSolutions.Web.Models;
using REPLSolutions.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace REPLSolutions.Web.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance

        private readonly ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var classAndSectionListVm = new ClassAndSectionListViewModel();
            classAndSectionListVm.classes = _context.Classes.ToList();
            classAndSectionListVm.sections = _context.Sections.ToList();
            classAndSectionListVm.Attendances = _context.Attendances.Include(a=>a.ClassRoom)
                .Include(a => a.ClassRoom.Class)
                .Include(a => a.ClassRoom.Section)



                .ToList();

            return View(classAndSectionListVm);
        }

        [HttpPost]
        public ActionResult AddAttendance(ClassAndSectionListViewModel obj)
        {

            var viewModel = new ClassAndSectionListViewModel
            {
                classes = _context.Classes.ToList(),
                sections = _context.Sections.ToList(),
                ClassAndSectionViewModel = obj.ClassAndSectionViewModel, 
                 Attendances= _context.Attendances.Include(a => a.ClassRoom)
                .Include(a => a.ClassRoom.Class)
                .Include(a => a.ClassRoom.Section)
                .ToList(),

        };




            if (obj.ClassAndSectionViewModel.classId == 0)
            {
                ////return RedirectToAction(nameof(Index));

                return View("Index", viewModel);

            }

            var classRoom = _context.ClassRooms.Include(c=>c.Class).Include(c=>c.Section).FirstOrDefault(c => c.ClassId == obj.ClassAndSectionViewModel.classId && c.SectionId == obj.ClassAndSectionViewModel.sectionId);

           


            if (classRoom==null)
            {
                ModelState.AddModelError("ClassDontExistError", "Class Room  Dont Exist With Give Class and Section " );
               
                return View("Index", viewModel);

            }



            var rules = _context.AcademicCalander.Where(c => c.StartDate <= obj.ClassAndSectionViewModel.attendanceDate && c.EndDate >= obj.ClassAndSectionViewModel.attendanceDate).ToList();

            if (rules.Count() == 0)
            {
                ModelState.AddModelError("WrongDate", "Cannot Make Attendance For This Date ");
               
                return View("Index", viewModel);
            }

            if (obj.ClassAndSectionViewModel.attendanceDate > DateTime.Now )
            {
                ModelState.AddModelError("WrongDate", "Cannot Make Attendance For Future ");
                return View("Index", viewModel);

            }

            if ((DateTime.Now - obj.ClassAndSectionViewModel.attendanceDate).TotalDays > 30)
            {
                ModelState.AddModelError("WrongDate", "Cannot Make Attendance before One Month ");
                return View("Index", viewModel);

            }

            var attobj = _context.Attendances.FirstOrDefault(a => a.AttendanceOfDate == obj.ClassAndSectionViewModel.attendanceDate && a.ClassRoomId == classRoom.Id);

            if (attobj!=null)
            {
                ModelState.AddModelError("WrongAttendance", "Attendance Alrerady Taken For This Date You Can Edit The Attendance"+attobj.Id);
                //  return View("Index", viewModel);
                return RedirectToAction(nameof(UpdateAttendance),new{ id=attobj.Id});

            }


            // check if Not Holiday on that day According to rule \

            var rulesList = rules.Select(s => s.AcademicCalanderRule).ToList();
            //var latestRule = rulesList[rulesList.Count() - 1];
          //Applying The First Rule..in Array
            var latestRule = rulesList[0];


            var flaggedRuleList = rules.Where(r => r.flag == true).Select(s => s.AcademicCalanderRule).ToList();

            if (flaggedRuleList.Count >= 1)
            {
                if (flaggedRuleList.Count == 1)
                {
                    latestRule = flaggedRuleList[0];
                }

                else
                {
                    latestRule = flaggedRuleList[flaggedRuleList.Count()-1];

                }
            }





            if ((AcademicCalanderRule)latestRule == AcademicCalanderRule.Holiday_on_Day)
            {
                ModelState.AddModelError("WrongAttendance", "Holiday OnThis Day");
                return View("Index", viewModel);
            }

            else if((AcademicCalanderRule)latestRule == AcademicCalanderRule.Holiday_on_Saturday_and_Sunday_Between_Selected_Days)
            {

                var attendanceDay = obj.ClassAndSectionViewModel.attendanceDate.DayOfWeek;

                if(attendanceDay==DayOfWeek.Saturday|| attendanceDay == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("WrongAttendance", "Holiday On This Day");
                    return View("Index", viewModel);
                }

            }

            else if((AcademicCalanderRule)latestRule == AcademicCalanderRule.Holiday_on_Saturday_Between_Selected_Days )
            {
                var attendanceDay = obj.ClassAndSectionViewModel.attendanceDate.DayOfWeek;


                if (attendanceDay == DayOfWeek.Saturday )
                {
                    ModelState.AddModelError("WrongAttendance", "Holiday On This Day");
                    return View("Index", viewModel);
                }

               
            }

            else if ((AcademicCalanderRule)latestRule == AcademicCalanderRule.Holiday_on_Sunday_Between_Selected_Days)
            {
                var attendanceDay = obj.ClassAndSectionViewModel.attendanceDate.DayOfWeek;


                if (attendanceDay == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("WrongAttendance", "Holiday On This Day");
                    return View("Index", viewModel);
                }


            }


            // 

            var students = _context.Admissions.Include(s=>s.Student).Where(s => s.ClassRoomId == classRoom.Id);

            var attendanceEntries = new List<AttendanceEntries>();


            foreach (var item in students)
            {
                AttendanceEntries attendanceEntry = new AttendanceEntries();

                attendanceEntry.Student = item.Student;
                attendanceEntry.Leave = false;
                attendanceEntry.Present = true;
                attendanceEntry.StudentId = item.Student.Id;
                


                attendanceEntries.Add(attendanceEntry);

            }

            var AddAttendancePageVm = new AddAttendancePageViewModel()
            {
                AttendanceEntries = attendanceEntries,
                classRoomId = classRoom.Id,
                AttendanceDate = obj.ClassAndSectionViewModel.attendanceDate,
                ClassRoom = classRoom,

            };



        return View(AddAttendancePageVm);

           
        }



        [HttpPost]
        public ActionResult SaveAttendancePage(AddAttendancePageViewModel obj)
        {


            var attendance = new Attendance()
            {
                 ClassRoomId=obj.classRoomId,
                  AttendanceOnDate=DateTime.Now,
                   AttendanceOfDate=obj.AttendanceDate,
                    Note=obj.Notes,
                     AcademicSessionId=1,
            };
            _context.Attendances.Add(attendance);

            _context.SaveChanges();
            foreach (var item in obj.AttendanceEntries)
            {
                item.AttendanceId = attendance.Id;


                if (item.Leave == true)
                {
                    item.Present =false;
                }

            }

            _context.AttendanceEnteries.AddRange(obj.AttendanceEntries);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public ActionResult UpdateAttendance(int ?id)
        {

            var attendance = _context.Attendances.Include(a=>a.ClassRoom).Include(a => a.ClassRoom.Class).Include(a => a.ClassRoom.Section).FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return RedirectToAction(nameof(Index));
            }


            var updateAttendancePageVm = new UpdateAttendancePageViewModel();

            updateAttendancePageVm.AttendanceEntries = _context.AttendanceEnteries.Include(a=>a.Student).Where(a=>a.AttendanceId==id).ToList();
            updateAttendancePageVm.Notes =attendance.Note;
            updateAttendancePageVm.AttendanceId = attendance.Id;
            updateAttendancePageVm.ClassRoom = attendance.ClassRoom;

            return View(updateAttendancePageVm);
        }

        [HttpPost]
        public ActionResult UpdateAttendance(UpdateAttendancePageViewModel obj)
        {

            var attedanceObj = _context.Attendances.FirstOrDefault(a => a.Id == obj.AttendanceId);


            if (attedanceObj == null)
            {
                return RedirectToAction(nameof(Index));
            }



            var attendanceEntries = _context.AttendanceEnteries.Where(a => a.AttendanceId == obj.AttendanceId);


            foreach (var attendance in attendanceEntries)
            {
                var present = obj.AttendanceEntries.FirstOrDefault(a => a.Id == attendance.Id).Present;
                var leave = obj.AttendanceEntries.FirstOrDefault(a => a.Id == attendance.Id).Leave;

                if (leave == true)
                {
                    present = true;
                }
                attendance.Present =  present;
                attendance.Leave = leave;

               






            }


            attedanceObj.Note= obj.Notes;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        }
}