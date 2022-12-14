using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        // make this class singleton
        private static UniversityContext _instance;

        public DbSet<Student> Students { get; set; }
      

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        { }
        public UniversityContext InstantiateUniversityContext()
        {
            if (_instance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite("DataSource=university.db");
                _instance = new UniversityContext(optionsBuilder.Options);

            }
            return _instance;
        }

    }
}

