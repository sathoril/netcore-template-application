using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateApplication.Data.Context;
using TemplateApplication.Data.Entities;
using TemplateApplication.Domain.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TemplateApplication.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext context;

        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
            this.context.Set<T>();
        }

        public void Add(T obj)
        {
            this.Add(new List<T> { obj });
        }

        public void Add(List<T> objs)
        {
            foreach (var obj in objs)
            {
                this.context.Add(obj);
            }

            this.context.SaveChanges();
        }

        public void Update(T obj)
        {
            this.Update(new List<T> { obj });
        }

        public void Update(List<T> objs)
        {
            this.context.Entry(objs).State = EntityState.Modified;

            foreach (var obj in objs)
            {
                this.context.Update(obj);
            }

            this.context.SaveChanges();
        }

        public List<T> ListActives()
        {
            IQueryable<T> query = this.context.Set<T>().Where(w => w.Active == "A");
            return query.ToList();
        }
    }
}
