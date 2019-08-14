using System.Collections.Generic;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(T obj) 
        {
            this.repository.Add(obj);
        }

        public virtual void Add(List<T> objs)
        {
            this.repository.Add(objs);
        }

        public virtual void Update(T obj)
        {
            (obj as BaseEntity).EntityModified();
            this.repository.Update(obj);
        }

        public virtual void Update(List<T> objs)
        {
            foreach (var obj in objs)
            {
                (obj as BaseEntity).EntityModified();
            }

            this.repository.Update(objs);
        }

        public virtual T FindById(int id)
        {
            return this.repository.FindById(id);
        }

        public List<T> ListActives()
        {
            return this.repository.ListActives();
        }
    }
}
