﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreMvcApplication.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        void Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}
