namespace BugTracking.Data
{
    using BugTracking.Models;
    using System;
    
    public interface IUowData : IDisposable
    {
        IRepository<Bug> Bugs { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
