using TP4.Data;
using TP4.Models;

namespace TP4
{
    public class TestSingleton
    {
        private readonly UniversityContext _context;
        public TestSingleton(UniversityContext context)
        {
            _context = context;
        }
        public void Test()
        {
            var context1 = _context.InstantiateUniversityContext();
            var context2 = _context.InstantiateUniversityContext();
            if (context1 == context2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
            // Test the Get Students
            List<Student> s = context1.Student.ToList();
        }
    }
}
