using System.Data;
using MusicStore_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MusicStoreMvcApplication.Models
{
    public class DbRepository<T> : IRepository<T> where T:class
    {
        protected IDbSet<T> DbSet { get; set; }

        protected DbContext DbCon { get; set; }

        public DbRepository()
        {
            this.DbCon = new MusicStoreEntities();
            this.DbSet = this.DbCon.Set<T>();
            DbCon.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T item)
        {
            DbEntityEntry entry = this.DbCon.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }

            this.DbCon.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.DbCon.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }

            this.DbCon.SaveChanges();
        }
        
        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.DbCon.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;

            this.DbCon.SaveChanges();
        }
    }
}