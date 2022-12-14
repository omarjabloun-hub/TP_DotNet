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

        [HttpGet("Course/Details/{course}")]
        public IActionResult Details(string course)
        {
            var contextoptions = new DbContextOptionsBuilder<UniversityContext>().UseSqlite("DataSource=university.db");

            StudentRepository srepo = new StudentRepository(new UniversityContext(contextoptions.Options));
            List<Student> students = (List<Student>)srepo.GetStudents();
            List<Student> studentsInCourse = new List<Student>();
            foreach (var student in students)
            {
                if (student.course == course)
                {
                    studentsInCourse.Add(student);
                }
            }
            return View(studentsInCourse);
        }
    }
}
