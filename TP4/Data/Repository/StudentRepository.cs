using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Data.Repository
{
    public class StudentRepository 
    {
        internal UniversityContext context;
        internal DbSet<Student> dbSet;

        public StudentRepository(UniversityContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Student>();
        }
        
        public IEnumerable<Student> GetStudents()
        {
            return dbSet.ToList();
        }

        public Student GetStudentByID(int id)
        {
            return dbSet.Find(id);
        }

        public void InsertStudent(Student student)
        {
            dbSet.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = dbSet.Find(studentID);
            dbSet.Remove(student);
            
        }

        public void UpdateStudent(Student student)
        {
            dbSet.Attach(student);
            context.Entry(student).State = EntityState.Modified;
        }
        
    }
}
