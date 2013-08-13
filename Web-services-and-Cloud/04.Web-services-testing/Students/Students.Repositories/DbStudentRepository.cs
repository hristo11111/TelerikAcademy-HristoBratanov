using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbStudentRepository : IRepository<Student>
    {
        private DbContext context;
        private DbSet<Student> entitySet;

        public DbStudentRepository(DbContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<Student>();
        }

        public IQueryable<Student> All()
        {
            return this.entitySet;
        }

        public Student Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public Student Add(Student item)
        {
            this.entitySet.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Student item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> Find(System.Linq.Expressions.Expression<Func<Student, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
