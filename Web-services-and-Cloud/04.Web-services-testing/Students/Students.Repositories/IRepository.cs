using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        T Add(T item);

        void Delete(int id);

        void Delete(T item);

        void Update(int id, T item);

        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
