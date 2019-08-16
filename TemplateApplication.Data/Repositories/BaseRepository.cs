using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TemplateApplication.Data.Context;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Repositories.Interfaces;

namespace TemplateApplication.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
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
            this.context.Entry(obj).State = EntityState.Modified;

            this.context.Update(obj);
            this.context.SaveChanges();
        }

        public void Update(List<T> objs)
        {
            foreach (var obj in objs)
            {
                this.context.Entry(obj).State = EntityState.Modified;
                this.context.Update(obj);
                this.context.SaveChanges();
            }

        }

        public T FindById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public List<T> ListActives()
        {
            IQueryable<T> query = this.context.Set<T>();
                //.Where(w => w.Active == "A");
            return query.ToList();
        }
    }
}
