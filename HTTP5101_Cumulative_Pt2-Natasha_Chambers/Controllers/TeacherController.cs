using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        // POST: /Teacher/Delete/{id}
         [HttpPost]
         public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }
    }
}