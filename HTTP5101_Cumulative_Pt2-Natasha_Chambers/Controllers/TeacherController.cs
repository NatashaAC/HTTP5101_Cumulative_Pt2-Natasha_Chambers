using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using HTTP5101_Cumulative_Pt2_Natasha_Chambers.Models;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            // Instantiating 
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);

            return View(Teachers);
        }

        // GET: Teacher/Show
        public ActionResult Show(int id)
        {
            // Instantiating 
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        // POST: /Teacher/DeleteConfirmation/{id}
        public ActionResult DeleteConfirmation(int id)
        {
            // Instantiating 
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        // POST: /Teacher/Delete/{id}
        [HttpPost]
         public ActionResult Delete(int id)
        {
            // Instantiating 
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

        // GET: /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            // Checking that the method is running
            Debug.WriteLine("The create method is running!");

            // Checking that the inputs from the form has been received 
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            // Validating 
            if(TeacherFname == "" || TeacherLname == "" || EmployeeNumber == "")
            {
                return RedirectToAction("New");
            } 
            else
            {
                // New Teacher Object
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                // Instantiating 
                TeacherDataController controller = new TeacherDataController();
                controller.AddTeacher(NewTeacher);

                return RedirectToAction("List");
            }

        }
    }
}