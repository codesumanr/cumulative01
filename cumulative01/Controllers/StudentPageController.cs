using Microsoft.AspNetCore.Mvc;
using cumulative01.Models;

namespace cumulative01.Controllers 
{
    public class StudentPageController : Controller
    {
        // Currently relying on the API to retrieve student information
        // This is a simplified example. In practice, both the StudentAPI and StudentPage controllers
        // should rely on a unified "Service", with an explicit interface
        private readonly StudentAPIController _api;

        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }

        // GET : StudentPage/List
        public IActionResult List()
        {
            List<Student> Students = _api.ListStudents();
            return View(Students);
        }

        // GET : StudentPage/Show/{id}
        public IActionResult Show(int id)
        {
            Student SelectedStudent = _api.FindStudent(id);
            ViewData["Id"] = id;
            return View(SelectedStudent);
        }
    }
}
