using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbSchoolRepository :IRepository<School>
    {
        DbContext context;
        DbSet<School> entitySet;

        public DbSchoolRepository(DbContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<School>();
        }

        public IQueryable<School> All()
        {
            return this.entitySet;
        }

        public School Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public School Add(School item)
        {
            this.entitySet.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(School item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, School item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<School> Find(System.Linq.Expressions.Expression<Func<School, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
