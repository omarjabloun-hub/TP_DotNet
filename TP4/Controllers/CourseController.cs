using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Data.Repository;
using TP4.Models;

namespace TP4.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            // extract all courses from students
            var contextoptions = new DbContextOptionsBuilder<UniversityContext>().UseSqlite("DataSource=university.db");
            
            StudentRepository srepo = new StudentRepository(new UniversityContext(contextoptions.Options));
            List<Student> students = (List<Student>)srepo.GetStudents();
            HashSet<string> courses = new HashSet<string>();
            foreach(var student in students)
            {
                courses.Add(student.course);
            }
            return View(courses);
        }
    }
}
