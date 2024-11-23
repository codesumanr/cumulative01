using Microsoft.AspNetCore.Mvc;
using cumulative01.Models; 

namespace cumulative01.Controllers 
{
    public class CoursePageController : Controller
    {
        // Currently relying on the API to retrieve course information.
        // In practice, both the CourseAPI and CoursePage controllers
        // should rely on a unified "Service", with an explicit interface
        private readonly CourseAPIController _api;

        public CoursePageController(CourseAPIController api)
        {
            _api = api;
        }

        // GET : CoursePage/List
        public IActionResult List()
        {
            List<Course> Courses = _api.ListCourses();
            return View(Courses);
        }

        // GET : CoursePage/Show/{id}
        public IActionResult Show(int id)
        {
            Course SelectedCourse = _api.FindCourse(id);
            ViewData["Id"] = id;
            return View(SelectedCourse);
        }
    }
}
